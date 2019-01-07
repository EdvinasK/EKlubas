using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using EKlubas.Domain;
using EKlubas.Domain.DTO;
using EKlubas.UI.Controllers.Math;
using EKlubas.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EKlubas.Application;

namespace EKlubas.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "EKlubas kontaktai";

            return View();
        }

        public async Task<IActionResult> MathTasks()
        {
            IEnumerable<StudyTopic> taskTopics = await _context.StudyTopics.ToListAsync();

            ViewBag.TopicTheme = "Temos";

            return View(taskTopics);
        }

        public IActionResult ExamResult(int Score)
        {
            ViewBag.ResultMessage = Score >= 50 ? "Sveikiname!" : "Bandykite dar kartą..";
            ViewBag.Score = Score;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
