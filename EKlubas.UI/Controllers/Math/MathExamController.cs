﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKlubas.Application;
using EKlubas.Common.Services;
using EKlubas.Core.Extensions;
using EKlubas.Domain;
using EKlubas.Persistence;
using EKlubas.UI.Services;
using EKlubas.UI.Services.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EKlubas.UI.Controllers
{
    [Authorize]
    public class MathExamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<EKlubasUser> _manager;

        public MathExamController(ApplicationDbContext context,
                                    UserManager<EKlubasUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: MathQuiz
        public async Task<IActionResult> MathExamCatalog()
        {
            IEnumerable<StudyTopic> examList = await _context.StudyTopics
                                                    .Where(st => st.IsExamPrepared == true)
                                                    .OrderByDescending(st => st.IsNew)
                                                    .ThenByDescending(st => st.CreatedTimestamp)
                                                    .ToListAsync();

            var highscore = await _context.RewardHistories
                                        .Where(rh => rh.ReceiveTime.Month == DateTime.Now.Month)
                                        .GroupBy(rh => rh.UserId)
                                        .Select(rh => new StudyHighScoreDto
                                        {
                                            UserName = rh.Key,
                                            RewardSum = rh.Sum(rhs => rhs.Reward)
                                        })
                                        .OrderByDescending(rh => rh.RewardSum)
                                        .Take(5)
                                        .ToListAsync();

            foreach(var score in highscore)
            {
                score.UserName = _manager.Users.SingleOrDefaultAsync(u => u.Id == score.UserName).Result.Nickname;
            }

            var scoreUserCount = highscore.Count;

            for (int i = 5; i > scoreUserCount; i--)
            {
                var studyHighScoreEmptyPlace = new StudyHighScoreDto()
                {
                    RewardSum = 0,
                    UserName = "-"
                };

                highscore.Add(studyHighScoreEmptyPlace);
            }

            var highscoreViewModel = new StudyHighScoreViewModel()
            {
                StudyHighScores = highscore,
                StudyTopics = examList
            };

            return View(highscoreViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> MathExam(int studyTopicId)
        {
            var user = await _manager.GetUserAsync(HttpContext.User);
            var studyTopic = await _context.StudyTopics.SingleOrDefaultAsync(st => st.Id == studyTopicId);
            var prepareExam = new PrepareMathExam();
            var examDto = await prepareExam.ExecuteAsync(studyTopic, user, _context, PrepareTaskFactory.GetPrepareTaskCommand(studyTopic.TaskName)); // TODO should take the string from StudyTopic table

            if(examDto == null)
                return RedirectToAction("MathExamCatalog", nameof(MathExamController).Replace("Controller", ""));

            return View(examDto);
        }

        [HttpPost]
        public async Task<IActionResult> MathExam(FinishedExamDto<MathDoneDto> finishedExam)
        {
            var exam = await _context.StudyExams
                            .Where(se => se.Id == finishedExam.ExamId)
                            .Include(se => se.StudyExamResults)
                            .SingleOrDefaultAsync();

            var user = await _manager.GetUserAsync(HttpContext.User);
            var evaluateExam = new EvaluateExam();
            var reward = 0;
            var score = 0;
            var finishedExamAnswers = finishedExam.ExamAnswers.ToList();
            finishedExamAnswers.ForEach(fea => fea.CorrectAnswer = exam.StudyExamResults.Where(ser => ser.Id == fea.TextAnswerId).SingleOrDefault().Answer); //TODO should be moved somewhere else. Problem when evaluating ex: 15.2 = 15.20. Needs size modification.

            score = evaluateExam.Exec(finishedExamAnswers, exam, EvaluationFactory.GetTaskEvaluationCommand(exam.TaskName)).Score;
            reward = RewardServices.CalculateCoinReward(score, exam.PassMark, exam.Reward, exam.IsNew);

            await AddRewardToUser(user, reward);
            _context.StudyExams.Remove(exam);
            await _context.SaveChangesAsync();

            TempData.Put("ExamAnswers", finishedExamAnswers);

            return RedirectToAction("MathExamResult", "MathExam", new { score, reward, passMark = exam.PassMark });
        }

        [HttpGet]
        public IActionResult MathExamResult(int score, int reward, int passMark)
        {
            ViewBag.ResultMessage = score >= passMark ? "Sveikiname!" : "Bandykite dar kartą..";
            ViewBag.PanelColor = score >= passMark ? "panel-success" : "panel-danger";
            ViewBag.Score = score;
            ViewBag.Reward = reward;

            var model = TempData.Get<List<MathDoneDto>>("ExamAnswers");

            if (model == null)
                return RedirectToAction("MathExamCatalog");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EqualityExam(int studyTopicId)
        {
            var user = await _manager.GetUserAsync(HttpContext.User);
            var studyTopic = await _context.StudyTopics.SingleOrDefaultAsync(st => st.Id == studyTopicId);
            var prepEqualityExam = new EqualityExam();

            if (studyTopic.DifficultyLevel < 1 || studyTopic.DifficultyLevel > 3)
                return RedirectToAction("MathExamCatalog", nameof(MathExamController).Replace("Controller", ""));

            EqualityExamDto<string> equalityTasks = await prepEqualityExam.PrepareExam(studyTopic, user, _context);

            return View(equalityTasks);
        }
        
        [HttpPost]
        public async Task<IActionResult> EqualityExam(FinishedExamDto<MathDoneDto> finishedExam)
        {
            var exam = await _context.StudyExams
                            .Where(se => se.Id == finishedExam.ExamId)
                            .Include(se => se.StudyExamResults)
                            .SingleOrDefaultAsync();

            var user = await _manager.GetUserAsync(HttpContext.User);
            var rewardHistory = new RewardHistory();
            var userCorrectAnswers = 0;
            var finishedExamAnswers = finishedExam.ExamAnswers.ToList();

            var examCorrectAnswers = exam.StudyExamResults.Where(ser => ser.Answer == "Ats: Teisinga").ToList();
            var examCorrectAnswersCount = examCorrectAnswers.Count();
            var userTotalAnswersCount = finishedExam.ExamAnswers.Count;
            var examTotalAnswersCount = exam.StudyExamResults.Count;

            try
            {
                finishedExamAnswers.Where(ea => examCorrectAnswers.Select(ec => ec.Id).Contains(ea.TextAnswerId)).ForEach(ea => ea.IsCorrect = true);
            }
            catch
            {

            }

            foreach (var correctAnswer in examCorrectAnswers)
            {
                foreach(var userAnswer in finishedExam.ExamAnswers)
                {
                    if(correctAnswer.Id == userAnswer.AnswerId)
                    {
                        userCorrectAnswers++;
                        break;
                    }
                }
            }

            var markCoefficient = CalculateMarkCoefficient(userCorrectAnswers,
                                                        examCorrectAnswersCount,
                                                        userTotalAnswersCount,
                                                        examTotalAnswersCount);

            var score = Convert.ToInt32(Math.Round(markCoefficient));
            var reward = RewardServices.CalculateCoinReward(score, exam.PassMark, exam.Reward, exam.IsNew);
            await AddRewardToUser(user, reward);
            _context.StudyExams.Remove(exam);
            await _context.SaveChangesAsync();

            TempData.Put("ExamAnswers", finishedExamAnswers);

            return RedirectToAction("EqualityExamResult", "MathExam", new { score, reward, passMark = exam.PassMark });
        }

        [HttpGet]
        public IActionResult EqualityExamResult(int score, int reward, int passMark)
        {
            ViewBag.ResultMessage = score >= passMark ? "Sveikiname!" : "Bandykite dar kartą..";
            ViewBag.PanelColor = score >= passMark ? "panel-success" : "panel-danger";
            ViewBag.Score = score;
            ViewBag.Reward = reward;

            var model = TempData.Get<List<MathDoneDto>>("ExamAnswers");

            if (model == null)
                return RedirectToAction("MathExamCatalog");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> FractionEqualityExam(int studyTopicId)
        {
            var user = await _manager.GetUserAsync(HttpContext.User);
            var studyTopic = await _context.StudyTopics.SingleOrDefaultAsync(st => st.Id == studyTopicId);
            var prepFractionEqualityExam = new FractionEqualityExam();
            EqualityExamDto<string> equalityTasks = null;

            if (user != null && studyTopic != null)
            {
                equalityTasks = await prepFractionEqualityExam.PrepareExam(studyTopic, user, _context);
            }
            else
            {
                return RedirectToAction("MathExamCatalog");
            }

            return View(equalityTasks);
        }

        [HttpPost]
        public async Task<IActionResult> FractionEqualityExam(FinishedExamDto<MathDoneDto> finishedExam)
        {
            var exam = await _context.StudyExams
                            .Where(se => se.Id == finishedExam.ExamId)
                            .Include(se => se.StudyExamResults)
                            .SingleOrDefaultAsync();

            var user = await _manager.GetUserAsync(HttpContext.User);
            var rewardHistory = new RewardHistory();
            var reward = 0;
            var userCorrectAnswers = 0;
            var score = 0;
            var finishedExamAnswers = finishedExam.ExamAnswers.ToList();

            var examCorrectAnswers = exam.StudyExamResults.Where(ser => ser.Answer == "Teisinga").ToList();
            var examCorrectAnswersCount = examCorrectAnswers.Count();
            var userTotalAnswersCount = finishedExam.ExamAnswers.Count;
            var examTotalAnswersCount = exam.StudyExamResults.Count;

            try
            {
                finishedExamAnswers.Where(ea => examCorrectAnswers.Select(ec => ec.Id).Contains(ea.TextAnswerId)).ForEach(ea => ea.IsCorrect = true);
            }
            catch
            {

            }

            foreach (var correctAnswer in examCorrectAnswers)
            {
                foreach (var userAnswer in finishedExam.ExamAnswers)
                {
                    if (correctAnswer.Id == userAnswer.AnswerId)
                    {
                        userCorrectAnswers++;
                        break;
                    }
                }
            }

            var markCoefficient = CalculateMarkCoefficient(userCorrectAnswers,
                                                        examCorrectAnswersCount,
                                                        userTotalAnswersCount,
                                                        examTotalAnswersCount);
            score = Convert.ToInt32(Math.Round(markCoefficient));
            reward = RewardServices.CalculateCoinReward(score, exam.PassMark, exam.Reward, exam.IsNew);
            await AddRewardToUser(user, reward);
            _context.StudyExams.Remove(exam);
            await _context.SaveChangesAsync();

            TempData.Put("ExamAnswers", finishedExamAnswers);

            return RedirectToAction("EqualityExamResult", "MathExam", new { score, reward, passMark = exam.PassMark });
        }

        [HttpGet]
        public async Task<IActionResult> FractionFigEqualityExam(int studyTopicId)
        {
            var user = await _manager.GetUserAsync(HttpContext.User);
            var studyTopic = await _context.StudyTopics.SingleOrDefaultAsync(st => st.Id == studyTopicId);
            var prepFractionEqualityExam = new FractionFigEqualityExam();
            EqualityExamDto<AnswerFormsDto> equalityTasks = null;

            if (user != null && studyTopic != null)
            {
                equalityTasks = await prepFractionEqualityExam.PrepareExam(studyTopic, user, _context);
            }
            else
            {
                return RedirectToAction("MathExamCatalog");
            }

            return View(equalityTasks);
        }

        [HttpPost]
        public async Task<IActionResult> FractionFigEqualityExam(FinishedExamDto<MathDoneDto> finishedExam)
        {
            var exam = await _context.StudyExams
                            .Where(se => se.Id == finishedExam.ExamId)
                            .Include(se => se.StudyExamResults)
                            .SingleOrDefaultAsync();

            var user = await _manager.GetUserAsync(HttpContext.User);
            var reward = 0;
            var userCorrectAnswers = 0;
            var score = 0;
            var finishedExamAnswers = finishedExam.ExamAnswers.ToList();

            var examCorrectAnswers = exam.StudyExamResults.Where(ser => ser.Answer == "Teisinga").ToList();
            var examIncorrectAnswers = exam.StudyExamResults.Where(ser => ser.Answer == "Neteisinga").ToList();
            var examCorrectAnswersCount = examCorrectAnswers.Count();
            var userTotalAnswersCount = finishedExam.ExamAnswers.Where(ea => ea.AnswerId != Guid.Empty).Count();
            var examTotalAnswersCount = exam.StudyExamResults.Count;

            try
            {
                finishedExamAnswers.Where(ea => examCorrectAnswers.Select(ec => ec.Id).Contains(ea.TextAnswerId)).ForEach(ea => ea.IsCorrect = true);
            }
            catch
            {

            }
            

            foreach (var correctAnswer in examCorrectAnswers)
            {
                foreach (var userAnswer in finishedExam.ExamAnswers)
                {
                    if (correctAnswer.Id == userAnswer.AnswerId)
                    {
                        userCorrectAnswers++;
                        break;
                    }
                }
            }

            var markCoefficient = CalculateMarkCoefficient(userCorrectAnswers,
                                                        examCorrectAnswersCount,
                                                        userTotalAnswersCount,
                                                        examTotalAnswersCount);
            score = Convert.ToInt32(Math.Round(markCoefficient));
            reward = RewardServices.CalculateCoinReward(score, exam.PassMark, exam.Reward, exam.IsNew);

            await AddRewardToUser(user, reward);
            _context.StudyExams.Remove(exam);
            await _context.SaveChangesAsync();

            TempData.Put("ExamAnswers", finishedExamAnswers);

            return RedirectToAction("FractionFigEqualityExamResult", "MathExam", new { score, reward, passMark = exam.PassMark });
        }

        [HttpGet]
        public IActionResult FractionFigEqualityExamResult(int score, int reward, int passMark)
        {
            ViewBag.ResultMessage = score >= passMark ? "Sveikiname!" : "Bandykite dar kartą..";
            ViewBag.PanelColor = score >= passMark ? "panel-success" : "panel-danger";
            ViewBag.Score = score;
            ViewBag.Reward = reward;

            var model = TempData.Get<List<MathDoneDto>>("ExamAnswers");

            if (model == null)
                return RedirectToAction("MathExamCatalog");

            return View(model);
        }

        private async Task AddRewardToUser(EKlubasUser user, int reward)
        {
            var rewardHistory = new RewardHistory();

            if (reward != 0)
            {
                rewardHistory.ReceiveTime = DateTime.Now;
                rewardHistory.Reward = reward;
                rewardHistory.User = user;

                user.Coins += reward;

                await _context.RewardHistories.AddAsync(rewardHistory);
                await _manager.UpdateAsync(user);
            }
        }

        private decimal CalculateMarkCoefficient(decimal userCorrectAnswersCount,
                                                 decimal examCorrectAnswersCount,
                                                 decimal userTotalAnswersCount,
                                                 decimal examTotalAnswersCount)
        {
            decimal markCoef = (userCorrectAnswersCount / examCorrectAnswersCount);
            markCoef = (markCoef - (userTotalAnswersCount - userCorrectAnswersCount) / examTotalAnswersCount) * 100;

            markCoef = markCoef <= 0 ? 0 : markCoef;

            return markCoef;
        }
    }
}