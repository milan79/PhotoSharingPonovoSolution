using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using PhotoSharingPonovo1.Models;

namespace PhotoSharingPonovo1.Controllers
{
    public class LoginController : Controller
    {
        TestEntities context = new TestEntities();
        private G1_PhotoSharingDBEntities context1 = new G1_PhotoSharingDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logovanje(FormCollection fc)
        {
            //Procedura.Procedura proc = new Procedura.Procedura();
            //string ime = fc["ime"];
            //string password = fc["password"];
            //int r = proc.Login(ime, password);
            //if (r == 100)
            //    return RedirectToAction("Index", "Photo");
            //else if (r == 200)
            //    return RedirectToAction("Create", "Photo");
            //else
            //    return View("Index");



            //var Admin = context.LoginTests.SqlQuery("EXEC Admin @ime @password", new SqlParameter("ime", fc["ime"]), new SqlParameter("password", fc["password"])).ToList();
            //var Other = context.LoginTests.SqlQuery("EXEC Other @ime @password", new SqlParameter("ime", fc["ime"]), new SqlParameter("password", fc["password"])).ToList();
            //if (Admin == null)
            //    return RedirectToAction("Index", "Photo");
            //else if (Other != null)
            //    return RedirectToAction("Create", "Photo");
            //else
            //    return View("Index"); //OVAJ DEO NE RADI, PRVI I TRECI RADE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            string ime = fc["ime"];
            //var Admin = context.LoginTests.SqlQuery("EXEC Admin1 @ime", new SqlParameter("ime", ime)).ToList();
            //var Other = context.LoginTests.SqlQuery("EXEC Other1 @ime", new SqlParameter("ime", fc["ime"])).FirstOrDefault();
            //if (Admin == null)
            //    return RedirectToAction("Index", "Photo");
            //else if (Other != null)
            //    return RedirectToAction("Create", "Photo");
            //else
            //    return View("Index");

            var photos = context1.Photos.SqlQuery("VratiListu @name", new SqlParameter("@name", ime)).FirstOrDefault();
            if (photos == null)
                return RedirectToAction("Index", "Photo");
            //else if (Other != null)
            //    return RedirectToAction("Create", "Photo");
            else
                return View("Index");

            //string ime = fc["ime"];
            //string password = fc["password"];
            //var Admin = (from i in context.LoginTests
            //             where (i.ime == ime && i.password == password && i.admin == true)
            //             select i).FirstOrDefault();
            //var Other = (from i in context.LoginTests
            //             where (i.ime == ime && i.password == password && i.admin == false)
            //             select i).FirstOrDefault();
            //if (Admin != null)
            //    return RedirectToAction("Index", "Photo");
            //else if (Other != null)
            //    return RedirectToAction("Create", "Photo");
            //else
            //    return View("Index");
        }
    }
}
//photos = context.Photos.SqlQuery("[dbo].[_PhotoGallery] @broj", new SqlParameter("broj", broj)).ToList();