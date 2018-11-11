using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientDeleteByPKStrategyBase : BabbageDataManipulationStrategy<ApiClientDeleteByPKResponse, object, ApiClientDeleteByPKStatus, ApiClientDeleteByPKRequest, ApiClientDeleteByPKContext>
    {
		public ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }
		

		public ApiClientDeleteByPKStrategyBase ()
		{
			
			Init();
		}
    }
}