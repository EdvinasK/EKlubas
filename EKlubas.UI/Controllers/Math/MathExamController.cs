using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKlubas.Application;
using EKlubas.Domain;
using EKlubas.Persistence;
using EKlubas.UI.Services.Math.Equality;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EKlubas.UI.Controllers.Math
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

            return View(examList);
        }

        [HttpGet]
        public async Task<ActionResult> EqualityExam(int difficultyLevel = 1)
        {
            var user = await _manager.GetUserAsync(HttpContext.User);
            var mathTask = new Equation();
            var equalityTasks = new List<EqualityExamDto>();
            var answerId = Guid.Empty;

            if (difficultyLevel < 1 || difficultyLevel > 3)
                return RedirectToAction("MathExamCatalog", nameof(MathExamController).Replace("Controller", ""));

            var equalityTasksAndResults = mathTask.GetEqualityTaskAndResult(difficultyLevel);

            foreach(var task in equalityTasksAndResults)
            {
                answerId = Guid.NewGuid();

                var userAnswer = new StudyExamAnswer()
                {
                    Id = answerId,
                    CreatedTime = DateTime.Now,
                    EndDate = DateTime.Now.AddMinutes(60),
                    User = user,
                    Answer = task.Result
                };

                equalityTasks.Add(new EqualityExamDto()
                {
                    AnswerId = answerId,
                    TaskDescription = task.Message
                });

                await _context.StudyExamAnswers.AddAsync(userAnswer);
                
            }

            await _context.SaveChangesAsync();

            return View(equalityTasks);
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
    }
}