using IngolStadtNatur.Entities.NH.Media;
using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Entities.NH.Observations;
using IngolStadtNatur.Services.NH.Authentication;
using IngolStadtNatur.Services.NH.Media;
using IngolStadtNatur.Services.NH.Objects;
using IngolStadtNatur.Services.NH.Observations;
using IngolStadtNatur.Utilities.Extensions;
using IngolStadtNatur.Web.Shell.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class ObservationController : Controller
    {
        public ActionResult Category(long id)
        {
            NodeManager nodeManager = new NodeManager();
            return View("CategoryGroupList", CategoryListGroupModel.Convert(nodeManager.FindById(id) as Category));
        }

        public ActionResult CreateCategoryObservation(long id)
        {
            NodeManager nodeManager = new NodeManager();
            return View("CreateCategoryObservation", CreateCategoryObservationModel.Convert(nodeManager.FindById(id) as Category));
        }

        [HttpPost]
        public ActionResult CreateCategoryObservation(CreateCategoryObservationModel model)
        {
            var nodeManager = new NodeManager();
            var userManager = new UserManager(new UserStore());

            if (ModelState.IsValid)
            {
                var observationManager = new ObservationManager();

                var observation = new Observation()
                {
                    Comment = model.Comment,
                    Coordinates = model.Coordinates,
                    CreationDate = DateTime.Now,
                    MeasurementDate = model.Date,
                    Node = nodeManager.FindById(model.Category.Id),
                    Species = model.Species,
                    User = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId().ToLong())
                };

                observationManager.Create(observation);

                if (model.Shot != null)
                {
                    var shotManager = new ShotManager();

                    var shot = new Shot()
                    {
                        Name = Guid.NewGuid() + Path.GetExtension(model.Shot.FileName),
                        Observation = observation
                    };

                    model.Shot.SaveAs(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["Shots"]), shot.Name));

                    shotManager.Create(shot);
                }

                return View("Thanks", (object)model.Coordinates);
            }

            model.Category = CategoryModel.Convert(nodeManager.FindById(model.Category.Id) as Category);
            return View("CreateCategoryObservation", model);
        }

        public ActionResult CreateQuickObservation()
        {
            return View("CreateQuickObservation", new CreateQuickObservationModel());
        }

        [HttpPost]
        public ActionResult CreateQuickObservation(CreateQuickObservationModel model)
        {
            if (ModelState.IsValid)
            {
                var nodeManager = new NodeManager();
                var observationManager = new ObservationManager();
                var userManager = new UserManager(new UserStore());

                var observation = new Observation()
                {
                    Comment = model.Comment,
                    Coordinates = model.Coordinates,
                    CreationDate = DateTime.Now,
                    MeasurementDate = model.Date,
                    Node = nodeManager.FindRoot(),
                    Species = model.Species,
                    User = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId().ToLong())
                };

                observationManager.Create(observation);

                if (model.Shot != null)
                {
                    var shotManager = new ShotManager();

                    var shot = new Shot()
                    {
                        Name = Guid.NewGuid() + Path.GetExtension(model.Shot.FileName),
                        Observation = observation
                    };

                    model.Shot.SaveAs(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["Shots"]), shot.Name));
                    shotManager.Create(shot);
                }

                return View("Thanks", (object)model.Coordinates);
            }

            return View("CreateQuickObservation", model);
        }

        public ActionResult CreateSpeciesObservation(long id)
        {
            NodeManager nodeManager = new NodeManager();
            return View("CreateSpeciesObservation", CreateSpeciesObservationModel.Convert(nodeManager.FindById(id) as Species));
        }

        [HttpPost]
        public ActionResult CreateSpeciesObservation(CreateSpeciesObservationModel model)
        {
            var nodeManager = new NodeManager();

            if (ModelState.IsValid)
            {
                var observationManager = new ObservationManager();
                var userManager = new UserManager(new UserStore());

                var observation = new Observation()
                {
                    Comment = model.Comment,
                    Coordinates = model.Coordinates,
                    CreationDate = DateTime.Now,
                    MeasurementDate = model.Date,
                    Node = nodeManager.FindById(model.Species.Id),
                    Species = model.Species.ScientificName,
                    User = userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId().ToLong())
                };

                observationManager.Create(observation);

                if (model.Shot != null)
                {
                    var shotManager = new ShotManager();

                    var shot = new Shot()
                    {
                        Name = Guid.NewGuid() + Path.GetExtension(model.Shot.FileName),
                        Observation = observation
                    };

                    model.Shot.SaveAs(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["Shots"]), shot.Name));

                    shotManager.Create(shot);
                }

                return View("Thanks", (object)model.Coordinates);
            }

            model.Species = SpeciesModel.Convert(nodeManager.FindById(model.Species.Id) as Species);
            return View("CreateSpeciesObservation", model);
        }

        [ChildActionOnly]
        public ActionResult GetCategoryChild(long id)
        {
            var nodeManager = new NodeManager();
            var node = nodeManager.FindById(id);

            if (node is Category)
            {
                return PartialView("_CategoryGroupListItem", CategoryListGroupItemModel.Convert((Category)node));
            }
            else
            {
                return PartialView("_SpeciesGroupListItem", SpeciesListGroupItemModel.Convert((Species)node));
            }
        }

        public JsonResult GetSpeciesNames(string query)
        {
            NodeManager nodeManager = new NodeManager();

            List<string> commonNames = nodeManager.SpeciesRepository.Query(m => m.CommonName.ToLower().Contains(query.ToLower())).Select(m => m.CommonName).ToList();
            List<string> scientificNames = nodeManager.SpeciesRepository.Query(m => m.ScientificName.ToLower().Contains(query.ToLower())).Select(m => m.ScientificName).ToList();
            return this.Json(commonNames.Union(scientificNames), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var nodeManager = new NodeManager();
            return View("CategoryGroupList", CategoryListGroupModel.Convert(nodeManager.FindRoot()));
        }

        public ActionResult Thanks(string coordinates)
        {
            return View(coordinates);
        }
    }
}