using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientDeleteByKeyStrategyBase : BabbageDataManipulationStrategy<ApiClientDeleteByKeyResponse, object, ApiClientDeleteByKeyStatus, ApiClientDeleteByKeyRequest, ApiClientDeleteByKeyContext>
    {
		public ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }
		

		public ApiClientDeleteByKeyStrategyBase ()
		{
			
			Init();
		}
    }
}