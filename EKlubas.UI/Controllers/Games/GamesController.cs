using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EKlubas.UI.Controllers.Games
{
    public class GamesController : Controller
    {
        public IActionResult GameList()
        {
            return View();
        }
    }
}