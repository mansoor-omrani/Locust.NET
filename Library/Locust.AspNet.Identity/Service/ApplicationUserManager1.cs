
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Locust.AspNet.Identity.Models;
using Locust.AspNet.Identity.Options;

namespace Locust.AspNet.Identity.Service
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var LocustOptions = context.Get<LocustIdentityOptions>();
            var manager = new ApplicationUserManager(new ApplicationUserStore(context.Get<ApplicationDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = LocustOptions.UserValidatorOptions.AllowOnlyAlphanumericUserNames,
                RequireUniqueEmail = LocustOptions.UserValidatorOptions.RequireUniqueEmail
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = LocustOptions.PasswordValidatorOptions.RequiredLength,
                RequireNonLetterOrDigit = LocustOptions.PasswordValidatorOptions.RequireNonLetterOrDigit,
                RequireDigit = LocustOptions.PasswordValidatorOptions.RequireDigit,
                RequireLowercase = LocustOptions.PasswordValidatorOptions.RequireLowercase,
                RequireUppercase = LocustOptions.PasswordValidatorOptions.RequireUppercase,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = LocustOptions.UserManagerOptions.UserLockoutEnabledByDefault;
            manager.DefaultAccountLockoutTimeSpan = LocustOptions.UserManagerOptions.DefaultAccountLockoutTimeSpan;
            manager.MaxFailedAccessAttemptsBeforeLockout = LocustOptions.UserManagerOptions.MaxFailedAccessAttemptsBeforeLockout;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider(LocustOptions.PhoneOptions.Name, new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = LocustOptions.PhoneOptions.MessageFormat
            });
            manager.RegisterTwoFactorProvider(LocustOptions.EmailOptions.Name, new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = LocustOptions.EmailOptions.Subject,
                BodyFormat = LocustOptions.EmailOptions.BodyFormat
            });

            if (LocustOptions.UserManagerOptions.EmailService != null)
            {
                manager.EmailService = LocustOptions.UserManagerOptions.EmailService;
            }
            else
            {
                manager.EmailService = new EmailService();
            }

            if (LocustOptions.UserManagerOptions.SmsService != null)
            {
                manager.SmsService = LocustOptions.UserManagerOptions.SmsService;
            }
            else
            {
                manager.SmsService = new SmsService();
            }

            if (LocustOptions.UserManagerOptions.PasswordHasher != null)
            {
                manager.PasswordHasher = LocustOptions.UserManagerOptions.PasswordHasher;
            }

            if (LocustOptions.UserManagerOptions.PasswordValidator != null)
            {
                manager.PasswordValidator = LocustOptions.UserManagerOptions.PasswordValidator;
            }

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }

}
