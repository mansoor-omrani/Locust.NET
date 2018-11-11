using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientRemoveByPKStrategyBase : BabbageDataManipulationStrategy<ApiClientRemoveByPKResponse, object, ApiClientRemoveByPKStatus, ApiClientRemoveByPKRequest, ApiClientRemoveByPKContext>
    {
		public ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }
		

		public ApiClientRemoveByPKStrategyBase ()
		{
			
			Init();
		}
    }
}