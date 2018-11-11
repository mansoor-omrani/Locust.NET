using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPDeleteStrategyBase : BabbageDataManipulationStrategy<ApiClientIPDeleteResponse, object, ApiClientIPDeleteStatus, ApiClientIPDeleteRequest, ApiClientIPDeleteContext>
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