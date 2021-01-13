using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practicum.Models;
using Practicum.Models.Kurs;
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

        public IActionResult OTMSeasteregg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KURSOutput(KursInput ki)
        {
            KursPIP pip = new KursPIP();   
            KursPP pp = new KursPP();
            KursIS iis = new KursIS();
            KursEconomiser econ = new KursEconomiser();
            Output op = econ.EconomiserCount(ki, pip, pp, iis);
            ViewBag.error = "error";
            ViewBag.KU = ki.KUcount;
            ViewBag.ParoProisvod = Math.Round(op.ParoProisvod,4);
            ViewBag.Qvip = Math.Round(op.Qvip, 4);
            ViewBag.Qpp = Math.Round(op.Qpp, 4);
            ViewBag.Ekv = Math.Round(op.Ekv, 4);
            ViewBag.Epv = Math.Round(op.Epv, 4);
            ViewBag.Enp = Math.Round(op.Enp, 4);
            ViewBag.EppR = Math.Round(op.EppR, 4);
            ViewBag.EppT = Math.Round(op.EppT, 4);
            ViewBag.PogRech = Math.Round(op.PogRech, 4);
            var Temperatureslists = new List<double>() { Math.Round(pip.PIPCalc(ki), 4), Math.Round(pp.PPCalc(ki, pip), 4), Math.Round(iis.ISCalc(ki, pp, pip), 4), Math.Round(op.OutputTdk, 4) };
            ViewBag.Temperatures = Newtonsoft.Json.JsonConvert.SerializeObject(Temperatureslists);
            if(ki.tdn == 0 || ki.tpv == 0 || ki.CO2+ki.H2O+ki.N2+ki.O2 != 100 || ki.Vd0 == 0)
            {
                return View("KURS", ViewBag.error);
            }
            else
            {
                return View();
            }                    
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
