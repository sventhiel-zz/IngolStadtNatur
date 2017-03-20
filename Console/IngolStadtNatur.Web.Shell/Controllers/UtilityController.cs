using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Services.NH.Objects;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class UtilityController : Controller
    {
        public ActionResult CreateSeedData()
        {
            var imageManager = new ImageManager();
            var nodeManager = new NodeManager();

            Category parent;
            List<Image> pictures;
            int position;

            // IMAGES
            var images = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/images.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in images)
            {
                imageManager.CreateImage(line[0], line[1], line[2], line[3], line[4], line[5]);
            }

            // CATEGORIES
            nodeManager.CreateCategory("Tiere", "Animalium", "", "", "", "ein unbekanntes Tier melden", "Sie wissen nicht weiter? Kein Problem! Melden Sie hier ein Ihnen unbekanntes Tier.");

            var categories = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/categories.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in categories)
            {
                parent = nodeManager.GetCategoryByCommonName(line[7]);

                nodeManager.CreateCategory(line[0], line[1], line[2], line[3], line[4], line[5], line[6], parent);
            }

            // SPECIES
            var species = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/species.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in species)
            {
                parent = nodeManager.GetCategoryByCommonName(line[4]);
                pictures = imageManager.GetImagesByNames(line[5]);

                nodeManager.CreateSpecies(line[0], line[1], line[2], line[3], pictures, parent);
            }

            return View("Index");
        }
    }
}