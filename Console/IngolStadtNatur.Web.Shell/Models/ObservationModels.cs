using Foolproof;
using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Utilities.Filters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class CreateCategoryObservationModel
    {
        public CategoryModel Category { get; set; }

        [Display(Name = "Kommentar")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "Koordinaten")]
        [RequiredIfEmpty("Coordinates")]
        public string Coordinates { get; set; }

        [Display(Name = "Datum")]
        [RequiredIfEmpty("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Foto")]
        public HttpPostedFileBase Shot { get; set; }

        [Display(Name = "Tiername")]
        public string Species { get; set; }


        [Display(Name = "Ich stimme den Nutzungsbedingungen zu.")]
        [RequiredToBeTrue]
        public bool TermsAndConditions { get; set; }

        public static CreateCategoryObservationModel Convert(Category category)
        {
            return new CreateCategoryObservationModel()
            {
                Category = CategoryModel.Convert(category)
            };
        }
    }

    public class CreateQuickObservationModel
    {
        [Display(Name = "Kommentar")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "Koordinaten")]
        [RequiredIfEmpty("Coordinates")]
        public string Coordinates { get; set; }

        [Display(Name = "Datum")]
        [RequiredIfEmpty("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Foto")]
        [RequiredIfEmpty("Species")]
        public HttpPostedFileBase Shot { get; set; }

        [Display(Name = "Tiername")]
        [RequiredIfEmpty("Shot")]
        public string Species { get; set; }

        [Display(Name = "Ich stimme den Nutzungsbedingungen zu.")]
        [RequiredToBeTrue]
        public bool TermsAndConditions { get; set; }
    }

    public class CreateSpeciesObservationModel
    {
        [Display(Name = "Koordinaten")]
        [RequiredIfEmpty("Coordinates")]
        public string Coordinates { get; set; }

        [Display(Name = "Kommentar")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "Datum")]
        [RequiredIfEmpty("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Foto")]
        public HttpPostedFileBase Shot { get; set; }

        [Display(Name = "Tiername")]
        public SpeciesModel Species { get; set; }

        [Display(Name = "Ich stimme den Nutzungsbedingungen zu.")]
        [RequiredToBeTrue]
        public bool TermsAndConditions { get; set; }

        public static CreateSpeciesObservationModel Convert(Species species)
        {
            return new CreateSpeciesObservationModel()
            {
                Species = SpeciesModel.Convert(species)
            };
        }
    }
}