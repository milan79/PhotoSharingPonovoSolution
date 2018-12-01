using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoSharingPonovo1.Models;
namespace PhotoSharingPonovo1.Controllers
{
    public class PrikazListeController : Controller
    {
        G1_PhotoSharingDBEntities context = new G1_PhotoSharingDBEntities();
        // GET: PrikazListe
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Prikaz(string ime)
        {
            var slike = (from k in context.Photos
                         where k.Title == ime
                         select k).ToList();
            if (slike == null)
                return HttpNotFound();
            else
                return View("Prikaz", slike);
        }
    }
}