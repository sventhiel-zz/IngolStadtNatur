using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic;
using IngolStadtNatur.Entities.NH.Objects;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class CreateSpeciesModel
    {
        public string ScientificName { get; set; }

        [Required]
        public string CommonName { get; set; }
    }

    public class SpeciesListGroupItemModel
    {
        public string Description { get; set; }
        public long Id { get; set; }
        public List<ImageListGroupItemModel> Images { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }

        public SpeciesListGroupItemModel()
        {
            Images = new List<ImageListGroupItemModel>();
        }

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
        public string Description { get; set; }
        public long Id { get; set; }
        public List<ImageModel> Images { get; set; }
        public long ParentId { get; set; }
        public string Reference { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }

        public SpeciesModel()
        {
            Images = new List<ImageModel>();
        }

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

    public class SpeciesSelectionModel
    {
        [Display(Name = "Deutscher Name")]
        public string CommonName { get; set; }

        public string Description { get; set; }
        public List<ImageListGroupItemModel> Images { get; set; }
        public long Id { get; set; }

        [Display(Name = "Wissenschaftlicher Name")]
        public string ScientificName { get; set; }

        public SpeciesSelectionModel()
        {
            Images = new List<ImageListGroupItemModel>();
        }

        public static SpeciesSelectionModel Convert(Species species)
        {
            return new SpeciesSelectionModel()
            {
                CommonName = species.CommonName,
                Description = species.Description,
                Id = species.Id,
                Images = species.Images.Select(ImageListGroupItemModel.Convert).ToList(),
                ScientificName = species.ScientificName
            };
        }
    }
}