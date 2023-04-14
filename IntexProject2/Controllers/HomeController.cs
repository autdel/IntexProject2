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
        public IActionResult MummyPredict()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Burials(int pageNum = 1, string ageFilter = null, string hairColorFilter = null, string burialDepthFilter = null, string headDirectionFilter = null, string sexFilter = null)
        {
            int pageSize = 51;


            var burialView = new BurialViewModel
            {
                Burials = _burialsRepo.Burials
                    .Where(b => (string.IsNullOrEmpty(ageFilter) || b.Ageatdeath == ageFilter)
                         && (string.IsNullOrEmpty(hairColorFilter) || b.Haircolor == hairColorFilter)
                         && (string.IsNullOrEmpty(burialDepthFilter) || b.Depth == burialDepthFilter)
                         && (string.IsNullOrEmpty(headDirectionFilter) || b.Headdirection == headDirectionFilter)
                         && (string.IsNullOrEmpty(sexFilter) || b.Sex == sexFilter))
                    .OrderBy(b => b.Burialnumber)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                        (string.IsNullOrEmpty(ageFilter) &&
                            string.IsNullOrEmpty(hairColorFilter) &&
                            string.IsNullOrEmpty(burialDepthFilter) &&
                            string.IsNullOrEmpty(headDirectionFilter) &&
                            string.IsNullOrEmpty(sexFilter)) ? _burialsRepo.Burials.Count()
                        : _burialsRepo.Burials
                            .Where(b => (string.IsNullOrEmpty(ageFilter) || b.Ageatdeath == ageFilter)
                         && (string.IsNullOrEmpty(hairColorFilter) || b.Haircolor == hairColorFilter)
                         && (string.IsNullOrEmpty(burialDepthFilter) || b.Depth == burialDepthFilter)
                         && (string.IsNullOrEmpty(headDirectionFilter) || b.Headdirection == headDirectionFilter)
                         && (string.IsNullOrEmpty(sexFilter) || b.Sex == sexFilter))
                            .Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },

                AgeFilter = ageFilter,
                HairColorFilter = hairColorFilter,
                BurialDepthFilter = burialDepthFilter,
                HeadDirectionFilter = headDirectionFilter,
                SexFilter = sexFilter
            };
        

            return View(burialView);
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

        public ActionResult CreateEntry(int formID = 0)
        {
            ViewData["Form"] = formID;

            
            return View();
        }

        public ActionResult SelectEntry(int formID)
        {
            return RedirectToAction("CreateEntry", "Home", new { formID = formID });
        }

        public ActionResult EditEntry(int formID = 0)
        {
            ViewData["Form"] = formID;


            return View();
        }
    }
}
