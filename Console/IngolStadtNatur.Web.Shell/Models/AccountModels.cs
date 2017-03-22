using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class ExternalSignInModel
    {
        public string ReturnUrl { get; set; }
    }

    public class ExternalSignInConfirmationModel
    {
        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }

    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class SendCodeModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class SignInModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class SignUpModel
    {
        [Display(Name = "Stadt")]
        [Required]
        public string City { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Kennwort betätigen")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string FullName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Kennwort")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Strasse")]
        [Required]
        public string Street { get; set; }

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
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Diesen Browser merken?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
}