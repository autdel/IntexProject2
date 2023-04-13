using IntexProject2.Models;
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

        private BurialDataContext _burials;

        public HomeController(BurialDataContext context)
        {
            _burials = context;
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
        public IActionResult Burials()
        {
            ViewBag.Burials = _burials.Burialmain.ToList();
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
