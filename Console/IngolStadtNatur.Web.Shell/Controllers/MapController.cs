using IngolStadtNatur.Services.NH.Objects;
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

        public JsonResult Select_Coordinates(string nodeName)
        {
            var observationManager = new ObservationManager();
            var observations = observationManager.Observations.Where(x => x.Node.CommonName.ToLowerInvariant() == nodeName.ToLowerInvariant());

            var data = observationManager.ObservationRepository.Query(x => x.Node.CommonName.ToLowerInvariant() == nodeName.ToLowerInvariant())
                .Select(x => x.Coordinates.Split(',')).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Select_Species(string query)
        {
            var nodeManager = new NodeManager();

            var commonNames = nodeManager.SpeciesRepository.Query(m => m.CommonName.ToLower().Contains(query.ToLower())).Select(m => m.CommonName).ToList();
            var scientificNames = nodeManager.SpeciesRepository.Query(m => m.ScientificName.ToLower().Contains(query.ToLower())).Select(m => m.ScientificName).ToList();
            return Json(commonNames.Union(scientificNames), JsonRequestBehavior.AllowGet);
        }
    }
}