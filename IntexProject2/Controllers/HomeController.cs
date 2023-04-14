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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace IntexProject2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;



        private IBurialsRepository _burialsRepo;

        public HomeController(IBurialsRepository context, IHttpContextAccessor httpContextAccessor)
        {
            _burialsRepo = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public PartialViewResult GetCookieConsentPartialView()
        {
            bool accepted = _httpContextAccessor.HttpContext.Request.Cookies["gdpr_cookie"] == "true";

            if (accepted)
            {
                return null;
            }

            return PartialView("_CookieConsentBanner");
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult MummyPredict()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public ActionResult Burials(int pageNum = 1, string squareNSFilter = null, string nsFilter = null, string squareEWFilter = null, string ewFilter = null, string burialNumFilter = null, string areaFilter = null,  string ageFilter = null, string hairColorFilter = null, string burialDepthFilter = null, string headDirectionFilter = null, string sexFilter = null)
        {
            int pageSize = 51;


            var burialView = new BurialViewModel
            {
                Burials = _burialsRepo.Burials
                    .Where(b => (string.IsNullOrEmpty(squareNSFilter) || b.Squarenorthsouth == squareNSFilter)
                         && (string.IsNullOrEmpty(nsFilter) || b.Northsouth == nsFilter)
                         && (string.IsNullOrEmpty(squareEWFilter) || b.Squareeastwest == squareEWFilter)
                         && (string.IsNullOrEmpty(ewFilter) || b.Eastwest == ewFilter)
                         && (string.IsNullOrEmpty(burialNumFilter) || b.Burialnumber == burialNumFilter)
                         && (string.IsNullOrEmpty(areaFilter) || b.Area == areaFilter)
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
                        (string.IsNullOrEmpty(squareNSFilter) &&
                            string.IsNullOrEmpty(ageFilter) &&
                            string.IsNullOrEmpty(nsFilter) &&
                            string.IsNullOrEmpty(squareEWFilter)&&
                            string.IsNullOrEmpty(ewFilter) &&
                            string.IsNullOrEmpty(burialNumFilter) &&
                            string.IsNullOrEmpty(areaFilter) &&
                            string.IsNullOrEmpty(hairColorFilter) &&
                            string.IsNullOrEmpty(burialDepthFilter) &&
                            string.IsNullOrEmpty(headDirectionFilter) &&
                            string.IsNullOrEmpty(sexFilter)) ? _burialsRepo.Burials.Count()
                        : _burialsRepo.Burials
                            .Where(b => (string.IsNullOrEmpty(squareNSFilter) || b.Squarenorthsouth == squareNSFilter)
                         && (string.IsNullOrEmpty(nsFilter) || b.Northsouth == nsFilter)
                         && (string.IsNullOrEmpty(squareEWFilter) || b.Squareeastwest == squareEWFilter)
                         && (string.IsNullOrEmpty(ewFilter) || b.Eastwest == ewFilter)
                         && (string.IsNullOrEmpty(burialNumFilter) || b.Burialnumber == burialNumFilter)
                         && (string.IsNullOrEmpty(areaFilter) || b.Area == areaFilter)
                         && (string.IsNullOrEmpty(ageFilter) || b.Ageatdeath == ageFilter)
                         && (string.IsNullOrEmpty(hairColorFilter) || b.Haircolor == hairColorFilter)
                         && (string.IsNullOrEmpty(burialDepthFilter) || b.Depth == burialDepthFilter)
                         && (string.IsNullOrEmpty(headDirectionFilter) || b.Headdirection == headDirectionFilter)
                         && (string.IsNullOrEmpty(sexFilter) || b.Sex == sexFilter))
                            .Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },
                SquareNSFilter = squareNSFilter,
                NSFilter = nsFilter,
                SquareEWFilter = squareEWFilter,
                EWFilter = ewFilter,
                BurialNumFilter = burialNumFilter,
                AreaFilter = areaFilter,
                AgeFilter = ageFilter,
                HairColorFilter = hairColorFilter,
                BurialDepthFilter = burialDepthFilter,
                HeadDirectionFilter = headDirectionFilter,
                SexFilter = sexFilter
            };
        

            return View(burialView);
        }

        [AllowAnonymous]
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
        [Authorize]
        public ActionResult CreateEntry(int formID = 0)
        {
            ViewData["Form"] = formID;

            return View();
        }
   
        [HttpPost]
        public ActionResult CreateEntry(Burialmain bm)
        {
            _burialsRepo.AddtoDB(bm);
            return View("Confirmation",bm);
        }

        public ActionResult SelectEntry(int formID)
        {
            return RedirectToAction("CreateEntry", "Home", new { formID = formID });
        }

        [Authorize]
        public ActionResult EditData(long id)
        {
            Burialmain bm = _burialsRepo.Edit(id);
            return RedirectToAction("EditEntry", bm);
        }
        [HttpGet]
        public ActionResult EditEntry(Burialmain bm)
        {
            ViewBag.Burialmain = bm;
            ViewData["Form"] = 1;
            return View();
        }
        [HttpPost]
        public IActionResult SavetoDB(Burialmain bm)
        {
            _burialsRepo.SaveToDB(bm);

            return View("Confirmation");
        }
    }
}
