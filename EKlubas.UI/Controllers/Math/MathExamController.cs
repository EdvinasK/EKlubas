using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKlubas.Application;
using EKlubas.Application.Common;
using EKlubas.Common.Services;
using EKlubas.Domain;
using EKlubas.Persistence;
using EKlubas.UI.Services.MathExam;
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
        public async Task<ActionResult> MathExamCatalog()
        {
            IEnumerable<StudyTopic> examList = await _context.StudyTopics
                                                    .Where(st => st.IsTestPrepared == true)
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
        public async Task<ActionResult> EqualityExam(int studyTopicId)
        {
            var user = await _manager.GetUserAsync(HttpContext.User);
            var studyTopic = await _context.StudyTopics.SingleOrDefaultAsync(st => st.Id == studyTopicId);
            var prepEqualityExam = new EqualityExam();

            if (studyTopic.DifficultyLevel < 1 || studyTopic.DifficultyLevel > 3)
                return RedirectToAction("MathExamCatalog", nameof(MathExamController).Replace("Controller", ""));

            EqualityExamDto equalityTasks = await prepEqualityExam.PrepareEqualityExam(
                                                                            studyTopic.DifficultyLevel, 
                                                                            user, 
                                                                            _context,
                                                                            studyTopic.PassMark,
                                                                            studyTopic.Reward,
                                                                            studyTopic.DurationInMinutes);

            return View(equalityTasks);
        }

        
        [HttpPost]
        public async Task<ActionResult> EqualityExam(FinishedExamDto<Guid> finishedExam)
        {
            var exam = await _context.StudyExams
                            .Where(se => se.Id == finishedExam.ExamId)
                            .Include(se => se.StudyExamResults)
                            .SingleOrDefaultAsync();

            //if (finishedExam == null)
            //{
            //    _context.StudyExams.Remove(exam);

            //    await _context.SaveChangesAsync();

            //    return RedirectToAction("ExamResult", "Home", new { Score = 0, Reward = 0, PassMark = 0 });
            //}
                

            var user = await _manager.GetUserAsync(HttpContext.User);
            var rewardService = new RewardServices();
            var rewardHistory = new RewardHistory();
            var reward = 0;
            var userCorrectAnswers = 0;
            var score = 0;

            var examCorrectAnswers = exam.StudyExamResults.Where(ser => ser.Answer == "Ats: Teisinga").ToList();
            var examCorrectAnswersCount = examCorrectAnswers.Count();
            var userTotalAnswersCount = finishedExam.ExamAnswers.Count;
            var examTotalAnswersCount = exam.StudyExamResults.Count;

            foreach (var correctAnswer in examCorrectAnswers)
            {
                foreach(var userAnswer in finishedExam.ExamAnswers)
                {
                    if(correctAnswer.Id == userAnswer)
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

            reward = rewardService.CalculateCoinReward(score, exam.PassMark, exam.Reward);

            if(reward != 0)
            {
                rewardHistory.ReceiveTime = DateTime.Now;
                rewardHistory.Reward = reward;
                rewardHistory.User = user;

                user.Coins += reward;

                await _context.RewardHistories.AddAsync(rewardHistory);
                await _manager.UpdateAsync(user);
            }

            _context.StudyExams.Remove(exam);

            await _context.SaveChangesAsync();

            return RedirectToAction("ExamResult", "Home", new { Score = score, Reward = reward, exam.PassMark });
        }

        [HttpGet]
        public async Task<ActionResult> FractionEqualityExam(int studyTopicId)
        {
            var user = await _manager.GetUserAsync(HttpContext.User);
            var studyTopic = await _context.StudyTopics.SingleOrDefaultAsync(st => st.Id == studyTopicId);
            var prepFractionEqualityExam = new FractionEqualityExam();
            EqualityExamDto equalityTasks = null;

            if (user != null && studyTopic != null)
            {
                equalityTasks = await prepFractionEqualityExam.PrepareFractionEqualityExam(
                                                                            studyTopic.DifficultyLevel,
                                                                            user,
                                                                            _context,
                                                                            studyTopic.PassMark,
                                                                            studyTopic.Reward,
                                                                            studyTopic.DurationInMinutes);
            }
            else
            {
                return RedirectToAction("MathExamCatalog");
            }

            return View(equalityTasks);
        }

        [HttpPost]
        public async Task<ActionResult> FractionEqualityExam(FinishedExamDto<Guid> finishedExam)
        {
            var exam = await _context.StudyExams
                            .Where(se => se.Id == finishedExam.ExamId)
                            .Include(se => se.StudyExamResults)
                            .SingleOrDefaultAsync();

            var user = await _manager.GetUserAsync(HttpContext.User);
            var rewardService = new RewardServices();
            var rewardHistory = new RewardHistory();
            var reward = 0;
            var userCorrectAnswers = 0;
            var score = 0;

            var examCorrectAnswers = exam.StudyExamResults.Where(ser => ser.Answer == "Teisinga").ToList();
            var examCorrectAnswersCount = examCorrectAnswers.Count();
            var userTotalAnswersCount = finishedExam.ExamAnswers.Count;
            var examTotalAnswersCount = exam.StudyExamResults.Count;

            foreach (var correctAnswer in examCorrectAnswers)
            {
                foreach (var userAnswer in finishedExam.ExamAnswers)
                {
                    if (correctAnswer.Id == userAnswer)
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

            reward = rewardService.CalculateCoinReward(score, exam.PassMark, exam.Reward);

            if (reward != 0)
            {
                rewardHistory.ReceiveTime = DateTime.Now;
                rewardHistory.Reward = reward;
                rewardHistory.User = user;

                user.Coins += reward;

                await _context.RewardHistories.AddAsync(rewardHistory);
                await _manager.UpdateAsync(user);
            }

            _context.StudyExams.Remove(exam);

            await _context.SaveChangesAsync();

            return RedirectToAction("ExamResult", "Home", new { Score = score, Reward = reward, exam.PassMark });
        }

        [HttpGet]
        public async Task<ActionResult> FractionFigEqualityExam(int studyTopicId)
        {
            var fractionList = new List<FractionFigEqualityDto>();
            int numerator, denominator = 0;

            for(var i = 0; i < 30; i++)
            {
                numerator = MathServices.GetRandomNumber(1, 5);
                denominator = numerator + MathServices.GetRandomNumber(0, 5);
                var fraction = new Fraction(numerator, denominator);
                var drawingFraction = new Fraction(fraction.Numerator, fraction.Denominator);
                bool randomizeDenominator = MathServices.GetRandomNumber(0, 100)%2==0?true:false;
                if (randomizeDenominator)
                {
                    drawingFraction.Numerator = MathServices.GetRandomNumber(1, 7);
                    drawingFraction.Denominator = drawingFraction.Numerator + MathServices.GetRandomNumber(0, 5);
                }

                fractionList.Add(new FractionFigEqualityDto(fraction, drawingFraction));
            }

            return View(fractionList);
        }

        // GET: MathQuiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MathQuiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MathQuiz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(MathExamCatalog));
            }
            catch
            {
                return View();
            }
        }

        // GET: MathQuiz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MathQuiz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(MathExamCatalog));
            }
            catch
            {
                return View();
            }
        }

        // GET: MathQuiz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MathQuiz/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(MathExamCatalog));
            }
            catch
            {
                return View();
            }
        }

        private decimal CalculateMarkCoefficient(decimal userCorrectAnswersCount,
                                                 decimal examCorrectAnswersCount,
                                                 decimal userTotalAnswersCount,
                                                 decimal examTotalAnswersCount)
        {
            decimal markCoef = (userCorrectAnswersCount / examCorrectAnswersCount);
            markCoef = (markCoef - (userTotalAnswersCount - userCorrectAnswersCount) / examTotalAnswersCount) * 100;

            return markCoef;
        }
    }
}