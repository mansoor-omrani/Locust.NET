using Owin;
using Locust.AspNet.Identity.Options;
using Locust.AspNet.Identity.Service;

namespace Locust.AspNet.Identity
{
    public class IdentityConfig
    {
        public static void Configure(IAppBuilder app, LocustIdentityOptions identityOptions)
        {
            if (identityOptions != null)
            {
                // Configure the db context, user manager and signin manager to use a single instance per request
                app.CreatePerOwinContext(ApplicationDbContext.Create);
                app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
                app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

                // Enable the application to use a cookie to store information for the signed in user
                // and to use a cookie to temporarily store information about a user logging in with a third party login provider
                // Configure the sign in cookie

                app.UseCookieAuthentication(identityOptions.CookieAuthenticationOptions);
                app.UseExternalSignInCookie(identityOptions.ExternalAuthenticationOptions.AuthenticationType);

                // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
                app.UseTwoFactorSignInCookie(identityOptions.TwoFactorAuthenticationOptions.AuthenticationType,
                    identityOptions.TwoFactorAuthenticationOptions.Expires);

                // Enables the application to remember the second login verification factor such as phone or email.
                // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
                // This is similar to the RememberMe option when you log in.
                app.UseTwoFactorRememberBrowserCookie(identityOptions.TwoFactorAuthenticationOptions.RememberBrwoserCookie);

                if (identityOptions.ThirdPartyOptions.UseMicrosoftAccount)
                {
                    app.UseMicrosoftAccountAuthentication(identityOptions.ThirdPartyOptions.MicrosoftAccount);
                }

                if (identityOptions.ThirdPartyOptions.UseTwitter)
                {
                    app.UseTwitterAuthentication(identityOptions.ThirdPartyOptions.Twitter);
                }

                if (identityOptions.ThirdPartyOptions.UseFacebook)
                {
                    app.UseFacebookAuthentication(identityOptions.ThirdPartyOptions.Facebook);
                }

                if (identityOptions.ThirdPartyOptions.UseGoogle)
                {
                    app.UseGoogleAuthentication(identityOptions.ThirdPartyOptions.Google);
                }
            }
        }
    }
}
