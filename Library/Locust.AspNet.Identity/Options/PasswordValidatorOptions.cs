using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.AspNet.Identity.Options
{
    public class PasswordValidatorOptions
    {
        //
        // Summary:
        //     Require a digit ('0' - '9')
        public bool RequireDigit { get; set; }
        //
        // Summary:
        //     Minimum required length
        public int RequiredLength { get; set; }
        //
        // Summary:
        //     Require a lower case letter ('a' - 'z')
        public bool RequireLowercase { get; set; }
        //
        // Summary:
        //     Require a non letter or digit character
        public bool RequireNonLetterOrDigit { get; set; }
        //
        // Summary:
        //     Require an upper case letter ('A' - 'Z')
        public bool RequireUppercase { get; set; }
    }
}
