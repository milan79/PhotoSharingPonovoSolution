using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using PhotoSharingPonovo1.Models;

namespace PhotoSharingPonovo1.Controllers
{
    public class PhotoController : Controller
    {
        private G1_PhotoSharingDBEntities context = new G1_PhotoSharingDBEntities();

        // GET: Photo
        public ViewResult Index()
        {
            return View("Index", context.Photos.ToList());
        }

        public ActionResult Details(int id)
        {
            Photo slika = context.Photos.Find(id);
            if (slika == null)
                return HttpNotFound();
            else
                return View("Details", slika);
        }

        public ViewResult Create()
        {
            Photo photo = new Photo();
            photo.CreatedDate = DateTime.Today;
            return View("Create", photo);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    photo.PhotoFile = new byte[image.ContentLength];
                    photo.ImageMimeType = image.ContentType;
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                }
                context.Photos.Add(photo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("Create", photo); //sta ako nema ovde photo nego sao create
        }

        public ActionResult Delete(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo == null)
                return HttpNotFound();
            else
                return View("Delete", photo);
        }

        [HttpPost]
        [ActionName("Delete")]
        public RedirectToRouteResult DeleteConfirmed(int id)
        {
            Photo photo = context.Photos.Find(id);
            context.Photos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetImage(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo == null)
                return HttpNotFound();
            else
                return File(photo.PhotoFile, photo.ImageMimeType);
        }

        //[ChildActionOnly]
        public PartialViewResult _PhotoGallery(int broj=0)
        {
            List<Photo> photos = new List<Photo>();
            if (broj == 0)
                photos = context.Photos.ToList();
            else
                //photos = (from a in context.Photos
                //          orderby a.PhotoID descending
                //          select a).Take(broj).ToList();
                photos = context.Photos.SqlQuery("[dbo].[_PhotoGallery] @broj", new SqlParameter("broj", broj)).ToList();
            return PartialView("_PhotoGallery", photos);
        }

        //public ActionResult DisplayByName(string name)
        //{
        //    var photo = (from a in context.Photos
        //                 where a.Title == name
        //                 select a).FirstOrDefault();
        //    if (photo == null)
        //        return HttpNotFound();
        //    else
        //        return View("Details", photo);                //ovde poziva postojeci view Details, vraca FirstOrDefault - primer kod rutiranja
        //}                                                     //ovde ne moze a vrati listu zato sto poziva pogled koji nema IEnumerable i foreach petlju

        //public ActionResult DisplayByName(string name)
        //{
        //    var photos = context.Photos.SqlQuery("VratiListu @name", new SqlParameter("@name", name)).ToList();
        //    if (photos == null)
        //        return HttpNotFound();
        //    else
        //        return View("DisplayByName", photos);         //isti primer kao dole samo ne koristi LINQ nego napisanu proceduru - primer kod rutiranja
        //}                                                     //obratiti paznju da kad varaca ceo upita mora .ToList na kraju !!!

        public ActionResult DisplayByName(string name)
        {
            var photos = (from i in context.Photos
                          where i.Title == name
                          select i).ToList();
            if (photos == null)
                return HttpNotFound();
            else
                return View("DisplayByName", photos);          //ovde vraca Listu (sa istim imenima), vraca svoj pogled DisplayByName - primer kod rutiranja
        }
    }
}