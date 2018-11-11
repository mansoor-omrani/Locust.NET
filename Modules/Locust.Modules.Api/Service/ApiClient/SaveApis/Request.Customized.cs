using System.Collections.Generic;
using Locust.ServiceModel;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientSaveApisRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
        public string Apis { get; set; }
        public bool Force { get; set; }
    }
}