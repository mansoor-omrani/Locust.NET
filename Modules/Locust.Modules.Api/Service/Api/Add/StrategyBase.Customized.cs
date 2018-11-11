using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiAddStrategyBase : BabbageDataManipulationStrategy<ApiAddResponse, int, ApiAddStatus, ApiAddRequest, ApiAddContext>
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