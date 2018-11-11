using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Calendar;
using Locust.ModelField;

namespace Locust.Modules.Base.Fields.Application
{
    
    public class AppId : TInt32 { }
    public class CreatedDate : DateTimeField { }
    public class AllowAnonymousHardwareRegistration : TBoolean { }
    public class AllowAnonymousIPRegistration : TBoolean { }
    public class RequiresImmediateApiCall : TBoolean { }
    public class RegisterBySerialNo : TBoolean { }
    public class IsActive : TBoolean { }
    public class Code : TString { }
    public class Version : TString { }
    public class Host : TString { }
    public class BaseAddress : TString { }
    public class Title : TString { }
    public class Description : TString { }
    public class ShortName: TString { }
    public class MultipleActivationRoutes : TBoolean { }
    public class UniqueHubs : TBoolean { }
}
