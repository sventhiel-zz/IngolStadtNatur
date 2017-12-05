using IngolStadtNatur.Utilities.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class ExternalSignInConfirmationModel
    {
        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }

    public class ExternalSignInModel
    {
        public string ReturnUrl { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Required]
        [Display(Name = "Nutzername")]
        public string UserName { get; set; }
    }

    public class ResetPasswordModel
    {
        public string Code { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Passwort bestätigen")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }
    }

    public class SendCodeModel
    {
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        public string SelectedProvider { get; set; }
    }

    public class SignInModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Nutzername")]
        public string UserName { get; set; }
    }

    public class SignUpModel
    {
        [Display(Name = "Stadt")]
        [Required]
        public string City { get; set; }

        [Compare("Password", ErrorMessage = "Die beiden Passwörter stimmen nicht überein.")]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort bestätigen")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string FullName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        [Required]
        [StringLength(100, ErrorMessage = "Das {0} muss mindestens {2} Zeichen haben.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Strasse")]
        [Required]
        public string Street { get; set; }

        [Display(Name = @"Ich stimme den <a href=""/Documents/Datenschutzerklärung.pdf"" target=""_blank"">Datenschutzerklärung</a> zu.")]
        [RequiredToBeTrue(ErrorMessage = "Akzeptieren der Datenschutzerklärung ist erforderlich.")]
        public bool TermsAndConditions { get; set; }

        [Required]
        [Display(Name = "Nutzername")]
        public string UserName { get; set; }

        [Display(Name = "PLZ")]
        [Required]
        public string ZipCode { get; set; }
    }

    public class VerifyCodeModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        public string Provider { get; set; }

        [Display(Name = "Diesen Browser merken?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}