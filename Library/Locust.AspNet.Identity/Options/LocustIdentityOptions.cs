using System;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.MicrosoftAccount;
using Microsoft.Owin.Security.Twitter;

namespace Locust.AspNet.Identity.Options
{
    public class LocustIdentityOptions:IDisposable
    {
        public PasswordValidatorOptions PasswordValidatorOptions { get; set; }
        public UserManagerOptions UserManagerOptions { get; set; }
        public UserValidatorOptions UserValidatorOptions { get; set; }
        public PhoneOptions PhoneOptions { get; set; }
        public EmailOptions EmailOptions { get; set; }
        public CookieAuthenticationOptions CookieAuthenticationOptions  { get; set; }
        public TwoFactorAuthenticationOptions TwoFactorAuthenticationOptions { get; set; }
        public ExternalAuthenticationOptions ExternalAuthenticationOptions { get; set; }
        public LocustThirdPartyOptions ThirdPartyOptions { get; set; }
        public LocustIdentityOptions()
        {
            PasswordValidatorOptions = new PasswordValidatorOptions();
            UserManagerOptions = new UserManagerOptions();
            UserValidatorOptions = new UserValidatorOptions();
            PhoneOptions = new PhoneOptions();
            EmailOptions = new EmailOptions();
            CookieAuthenticationOptions = new CookieAuthenticationOptions();
            TwoFactorAuthenticationOptions = new TwoFactorAuthenticationOptions();
            ExternalAuthenticationOptions = new ExternalAuthenticationOptions();
            ThirdPartyOptions = new LocustThirdPartyOptions();
        }

        public void Dispose()
        {
            ThirdPartyOptions = null;
        }
    }

    public class LocustThirdPartyOptions
    {
        public bool UseMicrosoftAccount { get; set; }
        public bool UseTwitter { get; set; }
        public bool UseFacebook { get; set; }
        public bool UseGoogle { get; set; }
        public MicrosoftAccountAuthenticationOptions MicrosoftAccount { get; set; }
        public TwitterAuthenticationOptions Twitter { get; set; }
        public FacebookAuthenticationOptions Facebook { get; set; }
        public GoogleOAuth2AuthenticationOptions Google { get; set; }
        public LocustThirdPartyOptions()
        {
            MicrosoftAccount = new MicrosoftAccountAuthenticationOptions();
            Twitter = new TwitterAuthenticationOptions();
            Facebook = new FacebookAuthenticationOptions();
            Google = new GoogleOAuth2AuthenticationOptions();
        }
    }
}
