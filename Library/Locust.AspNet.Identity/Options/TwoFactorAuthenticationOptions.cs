using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.AspNet.Identity.Options
{
    public class TwoFactorAuthenticationOptions
    {
        public string AuthenticationType { get; set; }
        public string RememberBrwoserCookie { get; set; }
        public TimeSpan Expires { get; set; }
    }
}
