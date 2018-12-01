using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoSharingPonovo1.Models;

namespace PhotoSharingPonovo1.Controllers
{
    public class CommentController : Controller
    {
        private G1_PhotoSharingDBEntities1 context = new G1_PhotoSharingDBEntities1();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        //[ChildActionOnly]
        public PartialViewResult CommentsForPhoto(int id)
        {
            List<Comment> comments = new List<Comment>();
            comments = (from a in context.Comments
                        where a.PhotoID == id
                        select a).ToList();
            return PartialView("CommentsForPhoto", comments);
        }
    }
}