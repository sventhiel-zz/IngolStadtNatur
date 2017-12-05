using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Services.NH.Objects;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using IngolStadtNatur.Entities.NH.Media;
using IngolStadtNatur.Services.NH.Media;

namespace IngolStadtNatur.Web.Shell.Controllers
{
    public class UtilityController : Controller
    {
        public ActionResult CreateSeedData()
        {
            var imageManager = new ImageManager();
            var nodeManager = new NodeManager();

            // IMAGES
            var enumerableOfImages = System.IO.File.ReadAllLines(Server.MapPath("/Documents/Images.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in enumerableOfImages)
            {
                Image image = new Image()
                {
                    Author = line[3],
                    Description = line[1],
                    License = line[4],
                    Name = line[0],
                    Source = line[2]
                };

                imageManager.Create(image);
            }

            // CATEGORIES
            var root = new Category()
            {
                CommonName = "Tiere",
                IsPreviewed = true,
                IsValid = true,
                Parent = null,
                ScientificName = "Animalium",
                UncertaintyHeader = "Ein unbekanntes Tier melden",
                UncertaintyText = "Sie wissen nicht weiter? Kein Problem! Melden Sie hier ein Ihnen unbekanntes Tier."
            };

            nodeManager.Create(root);

            var categories = System.IO.File.ReadAllLines(Server.MapPath("/Documents/Categories.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in categories)
            {
                var category = new Category()
                {
                    CommonName = line[0],
                    Description = line[2],
                    IsPreviewed = true,
                    IsValid = true,
                    Parent = (Category)nodeManager.FindByName(line[7]),
                    Preview = line[3],
                    Reference = line[4],
                    ScientificName = line[1],
                    UncertaintyHeader = line[5],
                    UncertaintyText = line[6]
                };

                nodeManager.Create(category);
            }

            // SPECIES
            var animals = System.IO.File.ReadAllLines(Server.MapPath("/Documents/Species.txt"), Encoding.UTF8).Select(a => a.Split('\t'));

            foreach (var line in animals)
            {
                var species = new Species()
                {
                    CommonName = line[0],
                    Description = line[2],
                    Images = imageManager.Get(line[5].Split(',')),
                    IsPreviewed = true,
                    IsValid = true,
                    Parent = (Category)nodeManager.FindByName(line[4]),
                    Reference = line[3],
                    ScientificName = line[1]
                };

                nodeManager.Create(species);
            }

            return View();
        }
    }
}