using IngolStadtNatur.Services.NH.Observations;
using System.Linq;
using System.Web.Mvc;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Select_Positions(long nodeId)
        {
            var observationManager = new ObservationManager();
            var observations = observationManager.Observations.Where(x => x.Node.Id == nodeId);

            var data = observationManager.ObservationRepository.Query(x => x.Node.Id == nodeId)
                .Select(x => x.Coordinates)
                .ToList();

            return Json(new
            {
                data = data
            }, JsonRequestBehavior.AllowGet);
        }
    }
}