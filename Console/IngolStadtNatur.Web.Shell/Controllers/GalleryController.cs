using System;
using System.Web.Mvc;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select_Shots()
        {
            throw new NotImplementedException();
        }
    }
}