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

        public IActionResult BurialInfo(long burialID)
        {
            ViewBag.BurialID = burialID;
            ViewBag.Burialmain = _burialsRepo.GetBurialmainByBurialID(burialID);
            ViewBag.Bodyanalysis = _burialsRepo.GetBodyanalysisByBurialID(burialID);
            ViewBag.Bodyanalysiskey = _burialsRepo.GetBodyanalysiskeyByBurialID(burialID);
            Textile textile = _burialsRepo.GetTextileByBurialID(burialID);
            ViewBag.Textile = textile;
            if (textile != null)
            {
                ViewBag.Analysis = _burialsRepo.GetAnalysisByTextileID(textile.Id);
                ViewBag.Color = _burialsRepo.GetColorByTextileID(textile.Id);
                ViewBag.Decoration = _burialsRepo.GetDecorationByTextileID(textile.Id); 
                ViewBag.Dimension = _burialsRepo.GetDimensionByTextileID(textile.Id); 
                ViewBag.Photodata = _burialsRepo.GetPhotoDataByTextileID(textile.Id);
                ViewBag.Structures = _burialsRepo.GetStructureByTextileID(textile.Id); 
                ViewBag.Textilefunction = _burialsRepo.GetTextileFunctionByTextileID(textile.Id);
                ViewBag.Yarnmanipulation = _burialsRepo.GetYarnManipulationByTextileID(textile.Id); 
            }
            return View();
        }
    }
}
