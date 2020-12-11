using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practicum.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OTMS()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OTMS(otmsInput oI)
        {          
            otmsCalc oC = new otmsCalc();
            ViewBag.Ho = oI.Ho;
            ViewBag.Ylist = oC.calc(oI).Ylist;
            ViewBag.explist = oC.calc(oI).explist;
            ViewBag.ulist = oC.calc(oI).ulist;
            ViewBag.mexplist = oC.calc(oI).mexplist;
            ViewBag.olist = oC.calc(oI).olist;
            ViewBag.tlist = oC.calc(oI).tlist;
            ViewBag._Tlist = oC.calc(oI)._Tlist;
            ViewBag.Templist = oC.calc(oI).Templist;
            return View();
        }

        public IActionResult KURS()
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
