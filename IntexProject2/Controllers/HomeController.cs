using IntexProject2.Models;
using IntexProject2.Repository;
using IntexProject2.Models.ViewModels;
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
        private IBurialsRepository burialsRepo;

        public HomeController(IBurialsRepository context)
        {
            burialsRepo = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MummyPredict()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Burials(int pageNum =1)
        {
            int pageSize = 51;

            var burial = new BurialViewModel
            {
                Burials = burialsRepo.Burials
                .OrderBy(b => b.Area)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (burialsRepo.Burials.Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(burial);
        }

        public IActionResult RepoTesting()
        {
            ViewBag.Burials = burialsRepo.GetAllBurialmain(); // List
            ViewBag.Bodyanalysis = burialsRepo.GetAllBodyanalysis(); // List
            ViewBag.SelectedBA = burialsRepo.GetBodyAnalysisByBodyAnalysisID(1); // 0 or 1 item
            ViewBag.Analysis = burialsRepo.GetAnalysisByTextileID(33495522228568350); // 0 or 1 item
            ViewBag.Colors = burialsRepo.GetColorsByTextileID(33495522228568069); // List if multiple
            ViewBag.Decoration = burialsRepo.GetDecorationByTextileID(33495522228568069); // 0 or 1 item
            ViewBag.Dimensions = burialsRepo.GetDimensionsByTextileID(33495522228568357); // List if multiple
            ViewBag.Photodata = burialsRepo.GetPhotoDataByTextileID(33495522228569209); // List if multiple
            ViewBag.Structures = burialsRepo.GetStructuresByTextileID(33495522228568403); // List if multiple
            ViewBag.Textilefunction = burialsRepo.GetTextileFunctionByTextileID(33495522228568370); // List if multiple
            ViewBag.Yarnmanipulation = burialsRepo.GetYarnManipulationByTextileID(33495522228568816); // List if multiple
            return View();
        }
        [HttpGet]
        public ActionResult CreateEntry(int formID = 0)
        {
            ViewData["Form"] = formID;

            
            return View();
        }
   
        [HttpPost]
        public ActionResult CreateEntry(Burialmain bm)
        {
            burialsRepo.AddtoDB(bm);
            return View("Confirmation",bm);
        }

        public ActionResult SelectEntry(int formID)
        {
            return RedirectToAction("CreateEntry", "Home", new { formID = formID });
        }
        [HttpGet]
        public ActionResult EditEntry(int formID = 0)
        {
            ViewData["Form"] = formID;


            return View();
        }

        [HttpPost]
        public ActionResult EditEntry(Burialmain bm)
        {
            return View("Confirmation",bm);
        }
    }
}
