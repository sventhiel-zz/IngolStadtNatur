using System.Collections.Generic;
using IngolStadtNatur.Services.NH.Objects;
using IngolStadtNatur.Services.NH.Observations;
using System.Linq;
using System.Web.Mvc;
using IngolStadtNatur.Entities.NH.Objects;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        [Authorize]
        public ActionResult Private()
        {
            return View();
        }

        public ActionResult Public()
        {
            return View();
        }

        [Authorize]
        public JsonResult Select_Coordinates(string nodeName)
        {
            var nodeManager = new NodeManager();

            var nodes = nodeManager.SpeciesRepository.Query(s => s.CommonName.ToUpperInvariant() == nodeName.ToUpperInvariant() || s.ScientificName.ToUpperInvariant() == nodeName.ToUpperInvariant());
            if (nodes.Count() != 1) return Json(new List<string[]>(), JsonRequestBehavior.DenyGet);

            var species = nodes.First();
            if (!species.IsSearchable || species.IsThreatened) return Json(new List<string[]>(), JsonRequestBehavior.DenyGet);

            var observationManager = new ObservationManager();
            var data = observationManager.ObservationRepository.Query(x => x.Species.ToUpperInvariant() == species.CommonName.ToUpperInvariant())
                .Select(x => x.Coordinates.Split(',')).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult Select_Species(string query)
        {
            var nodeManager = new NodeManager();

            var commonNames = nodeManager.SpeciesRepository.Query(m => m.IsSearchable && !m.IsThreatened && m.CommonName.ToUpperInvariant().Contains(query.ToUpperInvariant())).Select(m => m.CommonName).ToList();
            var scientificNames = nodeManager.SpeciesRepository.Query(m => m.IsSearchable && !m.IsThreatened && m.ScientificName.ToUpperInvariant().Contains(query.ToUpperInvariant())).Select(m => m.ScientificName).ToList();
            return Json(commonNames.Union(scientificNames), JsonRequestBehavior.AllowGet);
        }
    }
}