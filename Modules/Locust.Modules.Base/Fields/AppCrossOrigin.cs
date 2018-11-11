using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ModelField;

namespace Locust.Modules.Base.Fields.AppCrossOrigin
{
    public class AppCrossOriginId : TInt32 { }
    public class WithCredentials : TBoolean { }
    public class Origin : TString { }
    public class ExposeHeaders : TString { }
    public class AllowHeaders : TString { }
    public class MaxAge : TInt32 { }
}
