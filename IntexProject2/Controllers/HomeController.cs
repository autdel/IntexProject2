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
        public ActionResult Burials(int pageNum =1)
        {
            int pageSize = 50;

            var burial = new BurialViewModel
            {
                Burials = _burialsRepo.Burials
                .OrderBy(b => b.Area)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (_burialsRepo.Burials.Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(burial);
        }

        public IActionResult RepoTesting()
        {
            ViewBag.Burials = _burialsRepo.GetAllBurialmain(); // List
            ViewBag.Bodyanalysis = _burialsRepo.GetAllBodyanalysis(); // List
            ViewBag.SelectedBA = _burialsRepo.GetBodyAnalysisByBodyAnalysisID(1); // 0 or 1 item
            ViewBag.Analysis = _burialsRepo.GetAnalysisByTextileID(33495522228568350); // 0 or 1 item
            ViewBag.Colors = _burialsRepo.GetColorsByTextileID(33495522228568069); // List if multiple
            ViewBag.Decoration = _burialsRepo.GetDecorationByTextileID(33495522228568069); // 0 or 1 item
            ViewBag.Dimensions = _burialsRepo.GetDimensionsByTextileID(33495522228568357); // List if multiple
            ViewBag.Photodata = _burialsRepo.GetPhotoDataByTextileID(33495522228569209); // List if multiple
            ViewBag.Structures = _burialsRepo.GetStructuresByTextileID(33495522228568403); // List if multiple
            ViewBag.Textilefunction = _burialsRepo.GetTextileFunctionByTextileID(33495522228568370); // List if multiple
            ViewBag.Yarnmanipulation = _burialsRepo.GetYarnManipulationByTextileID(33495522228568816); // List if multiple
            return View();
        }
    }
}
