using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.ServiceModel;
using Locust.WebExtensions;
using Locust.WebTools;

namespace Locust.Modules.Api.Service.ApiEngine
{
    public class ApiCallContext
    {
        public Model.Api.Full Api { get; set; }
        public Model.ApiClient.Full Client { get; set; }
        public Model.ApiClientCustomer.Full Customer { get; set; }
        public Model.ApiClientCustomerHub.Full Hub { get; set; }
        public Locust.Modules.Base.Model.Application.AdminGrid App { get; set; }
        public IList<Model.ApiClientIP.AdminGrid> ClientIPs { get; set; }
        public BaseService Service { get; set; }
        public IServiceStrategyContext ServiceContext { get; set; }
        public bool ShouldRefreshCustomer { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ApiResponse ApiResponse { get; set; }
        private string clientIP;
        public HttpContextBase HttpContext { get; set; }
        public ApiEngineServiceBase EngineService { get; set; }
        public string ClientIP
        {
            get
            {
                if (string.IsNullOrEmpty(clientIP))
                {
                    if (HttpContext != null)
                    {
                        if (HttpContext.Request != null)
                        {
                            clientIP = HttpContext.Request.GetClientIpAddress();
                        }
                    }
                }

                return clientIP;
            }
        }
        public string Result { get; set; }
        public string Body { get; set; }
        public ApiCallContext()
        {
            StatusCode = HttpStatusCode.OK;
            ApiResponse = new ApiResponse(this);
        }
    }
}
