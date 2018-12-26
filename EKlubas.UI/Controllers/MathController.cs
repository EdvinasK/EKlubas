using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKlubas.Domain.POCO.Tasks.Math;
using Microsoft.AspNetCore.Mvc;

namespace EKlubas.UI.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Equality(int difficultyLevel = 1)
        {
            var mathTask = new Equation();

            if (difficultyLevel < 1 || difficultyLevel > 3)
                return RedirectToAction("MathTasks", nameof(HomeController).Replace("Controller", ""));

            ViewBag.TopicTheme = "Lygu, daugiau arba mažiau";

            return View(mathTask.GetEqualityTaskAndResult(difficultyLevel));
        }

        public IActionResult EqualityWithVariable(int difficultyLevel = 1)
        {
            var mathTask = new Equation();

            if (difficultyLevel < 1 || difficultyLevel > 3)
                return RedirectToAction("MathTasks", nameof(HomeController).Replace("Controller", ""));

            ViewBag.TopicTheme = "Lygybės su vienu kintamuoju";

            return View("Equality", mathTask.GetEqualityTaskAndResult(difficultyLevel, true));
        }

        public IActionResult Equation(int difficultyLevel = 1)
        {
            var mathTask = new Equation();

            if (difficultyLevel < 1 || difficultyLevel > 3)
                return RedirectToAction("MathTasks", nameof(HomeController).Replace("Controller", ""));

            ViewBag.TopicTheme = "Lygtys su vienu kintamuoju";

            return View("Equality", mathTask.GetEqualityTaskAndResult(difficultyLevel, true, false));
        }
    }
}