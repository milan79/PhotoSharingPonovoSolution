using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoSharingPonovo1.Models;

namespace PhotoSharingPonovo1.Controllers
{
    public class BezVezeController : Controller
    {
        // GET: BezVeze
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HandleError(ExceptionType =typeof(Exception), View ="ErrorTags")]
        public string Vrati(FormCollection fc)
        {
            string ime = fc["zoran"];
            string rezultat = "Vraceno ime je " + ime.ToString();
            return rezultat;
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ViewResult Vrati1(List<string> ime)
        {
            return View(ime);
        }

        public ViewResult Vrati2()
        {
            List<string> marko = new List<string>() { "Zoran", "Pera" };
            return View("Vrati2", marko);
        }

        public ActionResult Index3()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult Vrati3(FormCollection fc)
        {
            string ime1 = fc["ime1"];
            string ime2 = fc["ime2"];
            List<string> marko = new List<string>() { ime1, ime2 };
            return View("Vrati3", marko);
        }
    }
}