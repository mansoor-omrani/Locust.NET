using System.Data;
using Locust.Data;
using Locust.Extensions;
using Locust.Modules.Api.Service.ApiEngine;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
    public partial class ApiClientCustomerRegisterRequest : ApiBaseRequest
    {
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string HardwareCode { get; set; }
        public string SerialNo { get; set; }
        public string ActivationMethod { get; set; }
        public string CustomerType { get; set; }
    }
}