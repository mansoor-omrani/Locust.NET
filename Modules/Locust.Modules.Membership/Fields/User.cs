using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Calendar;
using Locust.ModelField;

namespace Locust.Modules.Membership.Fields.User
{
    public class Id : TInt32 { }
    public class AccessFailedCount : TInt32 { }
    public class LockoutEndDateUtc : DateTimeField { }
    public class EmailConfirmed : TBoolean { }
    public class PhoneNumberConfirmed : TBoolean { }
    public class TwoFactorEnabled : TBoolean { }
    public class LockoutEnabled : TBoolean { }
    public class Email : TString { }
    public class PasswordHash : TString { }
    public class SecurityStamp : TString { }
    public class PhoneNumber : TString { }
    public class UserName : TString { }
    public class IsBanned : TBoolean{ }

}
