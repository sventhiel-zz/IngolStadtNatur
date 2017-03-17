using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Services.NH.Objects;
using IngolStadtNatur.Services.NH.Observations;
using IngolStadtNatur.Web.Shell.Models;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class ObservationController : Controller
    {
        public ActionResult Index()
        {
            var nodeManager = new NodeManager();
            return View("CategoryGroupList", CategoryListGroupModel.Convert(nodeManager.GetRoot()));
        }

        [ChildActionOnly]
        public ActionResult GetCategoryChild(long id)
        {
            var nodeManager = new NodeManager();
            var node = nodeManager.GetNode(id);

            if (node is Category)
            {
                return PartialView("_CategoryGroupListItem", CategoryListGroupItemModel.Convert((Category)node));
            }
            else
            {
                return PartialView("_SpeciesGroupListItem", SpeciesListGroupItemModel.Convert((Species)node));
            }
        }

        public ActionResult Category(long id)
        {
            NodeManager nodeManager = new NodeManager();
            return View("CategoryGroupList", CategoryListGroupModel.Convert(nodeManager.GetCategory(id)));
        }



        public ActionResult Thanks()
        {
            return View();
        }

        public ActionResult CreateCategoryObservation(long id)
        {
            NodeManager nodeManager = new NodeManager();
            return View("CreateCategoryObservation", CreateCategoryObservationModel.Convert(nodeManager.GetCategory(id)));
        }

        [HttpPost]
        public ActionResult CreateCategoryObservation(CreateCategoryObservationModel model)
        {
            NodeManager nodeManager = new NodeManager();

            if (ModelState.IsValid)
            {
                ObservationManager observationManager = new ObservationManager();
                var observation = observationManager.CreateCategoryObservation(nodeManager.GetCategoryById(model.Category.Id), model.Comment, model.Coordinates, Origin.Category, model.Species);

                if (model.Shot != null)
                {
                    ShotManager shotManager = new ShotManager(MvcApplication.SessionFactory);
                    var fileName = observation.Id + "_Shot" + Path.GetExtension(model.Shot.FileName);
                    var path = Path.Combine(ConfigurationManager.AppSettings["Workspace"], fileName);

                    model.Shot.SaveAs(path);

                    shotManager.CreateShot(observation.Id, fileName, path);
                }

                return RedirectToAction("Thanks", "Observation");
            }

            model.Category = CategoryModel.Convert(nodeManager.GetCategoryById(model.Category.Id));
            return View("CreateCategoryObservation", model);
        }

        [NHibernatePersistence]
        public ActionResult CreateQuickObservation()
        {
            return View("CreateQuickObservation", new CreateQuickObservationModel());
        }

        [HttpPost]
        [NHibernatePersistence]
        public ActionResult CreateQuickObservation(CreateQuickObservationModel model)
        {
            if (ModelState.IsValid)
            {
                NodeManager nodeManager = new NodeManager(MvcApplication.SessionFactory);
                ObservationManager observationManager = new ObservationManager(MvcApplication.SessionFactory);
                var observation = observationManager.CreateCategoryObservation(nodeManager.GetRoot(), model.Comment, model.Coordinates, Origin.Quick, model.Species);

                if (model.Shot != null)
                {
                    ShotManager shotManager = new ShotManager(MvcApplication.SessionFactory);
                    var fileName = observation.Id + "_Shot" + Path.GetExtension(model.Shot.FileName);
                    var path = Path.Combine(ConfigurationManager.AppSettings["Workspace"], fileName);

                    model.Shot.SaveAs(path);

                    shotManager.CreateShot(observation.Id, fileName, path);
                }

                return RedirectToAction("Thanks", "Observation");
            }

            return View("CreateQuickObservation", model);
        }

        [NHibernatePersistence]
        public ActionResult CreateSpeciesObservation(long id)
        {
            NodeManager nodeManager = new NodeManager(MvcApplication.SessionFactory);
            return View("CreateSpeciesObservation", CreateSpeciesObservationModel.Convert(nodeManager.GetSpeciesById(id)));
        }

        [HttpPost]
        [NHibernatePersistence]
        public ActionResult CreateSpeciesObservation(CreateSpeciesObservationModel model)
        {
            NodeManager nodeManager = new NodeManager(MvcApplication.SessionFactory);

            if (ModelState.IsValid)
            {
                ObservationManager observationManager = new ObservationManager(MvcApplication.SessionFactory);
                var observation = observationManager.CreateSpeciesObservation(nodeManager.GetSpeciesById(model.Species.Id), model.Comment, model.Coordinates, Origin.Species);

                if (model.Shot != null)
                {
                    ShotManager shotManager = new ShotManager(MvcApplication.SessionFactory);
                    var fileName = observation.Id + "_Shot" + Path.GetExtension(model.Shot.FileName);
                    var path = Path.Combine(ConfigurationManager.AppSettings["Workspace"], fileName);

                    model.Shot.SaveAs(path);

                    shotManager.CreateShot(observation.Id, fileName, path);
                }

                return RedirectToAction("Thanks", "Observation");
            }

            model.Species = SpeciesModel.Convert(nodeManager.GetSpeciesById(model.Species.Id));
            return View("CreateSpeciesObservation", model);
        }

        public JsonResult GetSpeciesNames(string query)
        {
            NodeManager nodeManager = new NodeManager(MvcApplication.SessionFactory);

            List<string> commonNames = nodeManager.GetSpecies().Select(m => m.CommonName).Where(m => m.ToLower().Contains(query.ToLower())).ToList();
            List<string> scientificNames = nodeManager.GetSpecies().Select(m => m.ScientificName).Where(m => m.ToLower().Contains(query.ToLower())).ToList();
            return this.Json(commonNames.Union(scientificNames), JsonRequestBehavior.AllowGet);
        }
    }
}