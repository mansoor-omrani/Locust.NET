using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Service.ApiEngine
{
    public class ApiBaseRequest:BaseServiceRequest
    {
        public ApiCallContext CallContext { get; set; }
    }
}
