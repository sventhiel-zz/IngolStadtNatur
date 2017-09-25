using IngolStadtNatur.Entities.NH.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class SpeciesListGroupItemModel
    {
        public SpeciesListGroupItemModel()
        {
            Images = new List<ImageListGroupItemModel>();
        }

        public string CommonName { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public List<ImageListGroupItemModel> Images { get; set; }
        public string ScientificName { get; set; }

        public static SpeciesListGroupItemModel Convert(Species species)
        {
            return new SpeciesListGroupItemModel()
            {
                Description = species.Description,
                Id = species.Id,
                Images = species.Images.Select(ImageListGroupItemModel.Convert).ToList(),
                ScientificName = species.ScientificName,
                CommonName = species.CommonName
            };
        }
    }

    public class SpeciesModel
    {
        public SpeciesModel()
        {
            Images = new List<ImageModel>();
        }

        public string CommonName { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public List<ImageModel> Images { get; set; }
        public long ParentId { get; set; }
        public string Reference { get; set; }
        public string ScientificName { get; set; }

        public static SpeciesModel Convert(Species species)
        {
            return new SpeciesModel()
            {
                Description = species.Description,
                Id = species.Id,
                Images = species.Images.Select(ImageModel.Convert).ToList(),
                ParentId = species.Parent.Id,
                Reference = species.Reference,
                ScientificName = species.ScientificName,
                CommonName = species.CommonName
            };
        }
    }
}