using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientRemoveByKeyStrategyBase : BabbageDataManipulationStrategy<ApiClientRemoveByKeyResponse, object, ApiClientRemoveByKeyStatus, ApiClientRemoveByKeyRequest, ApiClientRemoveByKeyContext>
    {
		public ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }
		

		public ApiClientRemoveByKeyStrategyBase ()
		{
			
			Init();
		}
    }
}