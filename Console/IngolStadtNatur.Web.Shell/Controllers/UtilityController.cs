using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Services.NH.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

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
            var enumerableOfImages = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/images.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in enumerableOfImages)
            {
                Image image = new Image()
                {

                };

                imageManager.Create(image);
            }

            // CATEGORIES
            var root = new Category()
            {

            };

            nodeManager.Create(root);

            var categories = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/categories.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in categories)
            {
                var category = new Category()
                {
                    Parent = (Category)nodeManager.Get(line[7])
                };

                //nodeManager.CreateCategory(line[0], line[1], line[2], line[3], line[4], line[5], line[6], parent);
            }

            // SPECIES
            var species = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/species.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in species)
            {
                var x = new Species()
                {
                    Parent = (Category)nodeManager.Get(line[4]),
                    Images = imageManager.Get(line[5].Split(','))
                };

                //nodeManager.CreateSpecies(line[0], line[1], line[2], line[3], pictures, parent);
            }

            return View("Index");
        }
    }
}