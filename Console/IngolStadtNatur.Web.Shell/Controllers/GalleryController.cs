using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using IngolStadtNatur.Services.NH.Media;
using IngolStadtNatur.Web.Shell.Models;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Private()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Public()
        {
            var shotManager = new ShotManager();
            var shots = shotManager.Shots.Where(s => s.IsPublic);

            return View(shots.AsEnumerable().Select(GalleryItemModel.Convert).ToList());
        }

        public ActionResult Select_Shots()
        {
            throw new NotImplementedException();
        }
    }
}