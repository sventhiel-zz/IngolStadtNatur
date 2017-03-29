using System.Web.Mvc;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Impressum()
        {
            return View();
        }

        public ActionResult IngolStadtNatur()
        {
            return View();
        }
    }
}