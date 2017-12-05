using Foolproof;
using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Utilities.Filters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

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
        [HiddenInput]
        public DateTime Date { get; set; }

        [Display(Name = "Foto")]
        public HttpPostedFileBase Shot { get; set; }

        [Display(Name = "Tiername")]
        public string Species { get; set; }

        [Display(Name = @"Ich stimme den <a href=""/Documents/Impressum.pdf"" target=""_blank"">Nutzungsbedingungen</a> zu.")]
        [RequiredToBeTrue]
        public bool TermsAndConditions { get; set; }

        public static CreateCategoryObservationModel Convert(Category category)
        {
            return new CreateCategoryObservationModel()
            {
                Category = CategoryModel.Convert(category),
                Date = DateTime.Now
            };
        }
    }

    public class CreateQuickObservationModel
    {
        public CreateQuickObservationModel()
        {
            Date = DateTime.Now;
        }

        [Display(Name = "Kommentar")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "Koordinaten")]
        [HiddenInput]
        [RequiredIfEmpty("Coordinates")]
        public string Coordinates { get; set; }

        [Display(Name = "Datum")]
        [HiddenInput]
        public DateTime Date { get; set; }

        [Display(Name = "Foto")]
        [RequiredIfEmpty("Species")]
        public HttpPostedFileBase Shot { get; set; }

        [Display(Name = "Tiername")]
        [RequiredIfEmpty("Shot")]
        public string Species { get; set; }

        [Display(Name = @"Ich stimme den <a href=""/Documents/Impressum.pdf"" target=""_blank"">Nutzungsbedingungen</a> zu.")]
        [RequiredToBeTrue]
        public bool TermsAndConditions { get; set; }
    }

    public class CreateSpeciesObservationModel
    {
        [Display(Name = "Kommentar")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "Koordinaten")]
        [RequiredIfEmpty("Coordinates")]
        public string Coordinates { get; set; }

        [Display(Name = "Datum")]
        [HiddenInput]
        public DateTime Date { get; set; }

        [Display(Name = "Foto")]
        public HttpPostedFileBase Shot { get; set; }

        [Display(Name = "Tiername")]
        public SpeciesModel Species { get; set; }

        [Display(Name = @"Ich stimme den <a href=""/Documents/Impressum.pdf"" target=""_blank"">Nutzungsbedingungen</a> zu.")]
        [RequiredToBeTrue]
        public bool TermsAndConditions { get; set; }

        public static CreateSpeciesObservationModel Convert(Species species)
        {
            return new CreateSpeciesObservationModel()
            {
                Date = DateTime.Now,
                Species = SpeciesModel.Convert(species)
            };
        }
    }
}