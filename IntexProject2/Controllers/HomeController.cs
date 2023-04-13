using IntexProject2.Models;
using IntexProject2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace IntexProject2.Controllers
{
    public class HomeController : Controller
    {
        private IBurialsRepository _burialsRepo;

        public HomeController(IBurialsRepository context)
        {
            _burialsRepo = context;
        }

        public IActionResult Index()
        {
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
        public ActionResult Burials()
        {
            ViewBag.Burials = _burialsRepo.GetAllBurialmain(); // List
            ViewBag.Bodyanalysis = _burialsRepo.GetAllBodyanalysis(); // List
            ViewBag.SelectedBA = _burialsRepo.GetBodyAnalysisByBodyAnalysisID(1); // 1 item
            ViewBag.Analysis = _burialsRepo.GetAnalysisByTextileID(33495522228568350);
            return View();
        }
    }
}
