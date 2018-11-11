using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ModelField;

namespace Locust.Modules.Api.Fields.ApiClientCustomerHub
{
    public enum ApiClientCustomerHubType
    {
        Mobile = 1,
        Email = 2,
        Mixed = 3
    }
    public class ApiClientCustomerHubTypeId : TByte { }
    public class ApiClientCustomerHubId : TInt32 { }
    public class MaxCustomer : TInt32 { }
    public class IsActive : TBoolean { }
    public class HubUniqueCode : TString { }
}
