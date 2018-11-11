using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientIPSetIsActiveStrategyBase : BabbageDataManipulationStrategy<ApiClientIPSetIsActiveResponse, object, ApiClientIPSetIsActiveStatus, ApiClientIPSetIsActiveRequest, ApiClientIPSetIsActiveContext>
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