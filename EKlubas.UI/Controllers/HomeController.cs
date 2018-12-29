using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EKlubas.UI.Models;
using System.Text;
using EKlubas.Domain;
using EKlubas.Domain.DTO;
using EKlubas.UI.Controllers.Math;
using EKlubas.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EKlubas.UI.Controllers
{
    public class HomeController : Controller
    {
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

        public IActionResult MathTasks()
        {
            var taskTopics = new List<MathTopic>
            {
                new MathTopic()
                {
                    Name = "Lygu, daugiau arba mažiau",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 1,
                    Link = nameof(MathController.Equality),
                    DurationInMinutes = 5
                },

                new MathTopic()
                {
                    Name = "Lygu, daugiau arba mažiau",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 2,
                    Link = nameof(MathController.Equality),
                    DurationInMinutes = 10
                },

                new MathTopic()
                {
                    Name = "Lygu, daugiau arba mažiau",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai be kintamųjų",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 3,
                    Link = nameof(MathController.Equality),
                    DurationInMinutes = 15
                },
                new MathTopic()
                {
                    Name = "Lygtys su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 1,
                    Link = nameof(MathController.Equation),
                    DurationInMinutes = 5
                },

                new MathTopic()
                {
                    Name = "Lygtys su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 2,
                    Link = nameof(MathController.Equation),
                    DurationInMinutes = 10
                },

                new MathTopic()
                {
                    Name = "Lygtys su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygčių uždaviniai su vienu kintamuoju x",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 3,
                    Link = nameof(MathController.Equation),
                    DurationInMinutes = 15
                },
                new MathTopic()
                {
                    Name = "Lygybės su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 1,
                    Link = nameof(MathController.EqualityWithVariable),
                    DurationInMinutes = 5
                },

                new MathTopic()
                {
                    Name = "Lygybės su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 2,
                    Link = nameof(MathController.EqualityWithVariable),
                    DurationInMinutes = 10
                },

                new MathTopic()
                {
                    Name = "Lygybės su vienu kintamuoju",
                    Description = "Įvairaus sudėtingumo lygybių uždaviniai su vienu kintamuoju x",
                    Topic = nameof(MathController).Replace("Controller", ""),
                    DifficultyLevel = 3,
                    Link = nameof(MathController.EqualityWithVariable),
                    DurationInMinutes = 15
                }
            };

            ViewBag.TopicTheme = "Temos";

            return View(taskTopics);
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
