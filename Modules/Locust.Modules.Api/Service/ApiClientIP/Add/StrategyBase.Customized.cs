using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPAddStrategyBase : BabbageDataManipulationStrategy<ApiClientIPAddResponse, object, ApiClientIPAddStatus, ApiClientIPAddRequest, ApiClientIPAddContext>
    {
        public ApiClientIPServiceBase Service
        {
            get { return Store.Service as ApiClientIPServiceBase; }
        }
        protected void Init()
		{
        }
    }
}