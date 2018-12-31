using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EKlubas.UI.Controllers.Math
{
    public class MathExamController : Controller
    {
        // GET: MathQuiz
        public ActionResult MathExamCatalog()
        {
            return View();
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