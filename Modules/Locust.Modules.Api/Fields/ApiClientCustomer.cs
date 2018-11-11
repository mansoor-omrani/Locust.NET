using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Calendar;
using Locust.ModelField;

namespace Locust.Modules.Api.Fields.ApiClientCustomer
{
    public class AccessToken : TGuid { }
    public class RefreshToken : TGuid { }
    public class NewAccessToken : TGuid { }
    public class NewRefreshToken : TGuid { }
    public class ApiClientCustomerId : TInt32 { }
    public class LifeLength : TInt32 { }
    public class CreatedDate : DateTimeField { }
    public class LastRefreshDate : DateTimeField { }
    public class RegisterDate : DateTimeField { }
    public class ActivationDate : DateTimeField { }
    public class NewLastRefreshDate : DateTimeField { }
    public class Activated : TBoolean { }
    public class Disabled : TBoolean { }
    public class IsLocked : TBoolean { }
    public class HardwareCode : TString { }
    public class ActivationCode : TString { }
    public class EncryptionCode : TString { }
    public class HashCode : TString { }
    public class ActivationRequestCode : TString { }
    public class NewEncryptionCode : TString { }
    public class Validity : TString { }
    public class CustomerType : TString { }
    public class RemainingLife : TInt32 { }
}
