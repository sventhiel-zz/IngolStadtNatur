using IngolStadtNatur.Entities.NH.Authentication;
using IngolStadtNatur.Services.NH.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;

namespace IngolStadtNatur.Services.NH.Authentication
{
    public sealed class UserManager : UserManager<User, long>
    {
        public UserManager(IUserStore<User, long> store) : base(store)
        {
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            EmailService = new EmailService();
            MaxFailedAccessAttemptsBeforeLockout = 5;

            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User, long>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            //RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User, long>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});

            UserLockoutEnabledByDefault = true;

            var dataProtectionProvider = Auth.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                var dataProtector = dataProtectionProvider.Create("ASP.NET Identity");

                this.UserTokenProvider = new DataProtectorTokenProvider<User, long>(dataProtector);
            }

            UserValidator = new UserValidator<User, long>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
        }
    }
}
