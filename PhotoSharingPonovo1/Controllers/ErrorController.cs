using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoSharingPonovo1.Models;

namespace PhotoSharingPonovo1.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HandleError(ExceptionType =typeof(Exception), View ="ErrorView")]
        public ActionResult Index()
        {
            throw new Exception("Something get wrong.");
        }

        public ViewResult Index1()
        {
            return View("ErrorView1");
        }
    }
}