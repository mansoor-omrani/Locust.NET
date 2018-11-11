using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ModelField;

namespace Locust.Modules.Api.Fields.ApiClient
{
    public class ClientKey : TGuid { }
    public class ApiClientId : TInt32 { }
    public class Enabled : TBoolean { }
    public class AllowAnyIPAddress : TBoolean { }
    public class ClientSecret : TString { }
    public class HardwareCode : TString { }
    public class FinishPaymentReturnUrl : TString { }
    public class Title : TString { }
    public class Description : TString { }
    public class Website : TString { }
    public class Photo : TString { }
    public class TheaterCode : TInt32 { }
}
