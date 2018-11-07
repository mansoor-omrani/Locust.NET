using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Locust.AspNet.Identity.Options
{
    public class UserManagerOptions
    {
        //
        // Summary:
        //     Default amount of time that a user is locked out for after MaxFailedAccessAttemptsBeforeLockout
        //     is reached
        public TimeSpan DefaultAccountLockoutTimeSpan { get; set; }
        //
        // Summary:
        //     Used to send email
        public IIdentityMessageService EmailService { get; set; }
        //
        // Summary:
        //     Number of access attempts allowed before a user is locked out (if lockout is
        //     enabled)
        public int MaxFailedAccessAttemptsBeforeLockout { get; set; }
        //
        // Summary:
        //     Used to hash/verify passwords
        public IPasswordHasher PasswordHasher { get; set; }
        //
        // Summary:
        //     Used to validate passwords before persisting changes
        public IIdentityValidator<string> PasswordValidator { get; set; }
        //
        // Summary:
        //     Used to send a sms message
        public IIdentityMessageService SmsService { get; set; }
        //
        // Summary:
        //     If true, will enable user lockout when users are created
        public bool UserLockoutEnabledByDefault { get; set; }
    }
}
