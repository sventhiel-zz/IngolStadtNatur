using IngolStadtNatur.Entities.NH.Authentication;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace IngolStadtNatur.Services.NH.Authentication
{
    public class SignInManager : SignInManager<User, long>
    {
        public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager)
             : base(userManager, authenticationManager)
        {
        }
    }
}