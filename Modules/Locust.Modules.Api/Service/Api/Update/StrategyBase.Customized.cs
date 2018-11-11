using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiUpdateStrategyBase : BabbageDataManipulationStrategy<ApiUpdateResponse, object, ApiUpdateStatus, ApiUpdateRequest, ApiUpdateContext>
    {
        public ApiServiceBase Service
        {
            get { return Store.Service as ApiServiceBase; }
        }
        protected void Init()
		{
        }
    }
}