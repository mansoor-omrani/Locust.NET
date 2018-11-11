using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientSaveApisStrategyBase : BabbageDataManipulationStrategy<ApiClientSaveApisResponse, object, ApiClientSaveApisStatus, ApiClientSaveApisRequest, ApiClientSaveApisContext>
    {
        protected ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }

        public ApiClientSaveApisStrategyBase ()
		{
			
			Init();
		}

    }
}