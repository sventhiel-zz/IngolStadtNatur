using IngolStadtNatur.Services.NH.Media;
using IngolStadtNatur.Web.Shell.Models;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class GalleryController : Controller
    {
        [Authorize]
        public ActionResult Private()
        {
            var shotManager = new ShotManager();
            var shots = shotManager.Shots.Where(s => s.Observation.User.UserName.ToUpperInvariant() == HttpContext.User.Identity.Name.ToUpperInvariant());

            return View(shots.AsEnumerable().Select(GalleryItemModel.Convert).ToList());
        }

        [AllowAnonymous]
        public ActionResult Public()
        {
            var shotManager = new ShotManager();
            var shots = shotManager.Shots.Where(s => s.IsPublic);

            return View(shots.AsEnumerable().Select(GalleryItemModel.Convert).ToList());
        }
    }
}