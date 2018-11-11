using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using ResponseType = Locust.Modules.Api.Model.ApiClient.GetPage;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientGetPageStrategyBase : BabbagePageFetcherStrategy<ApiClientGetPageResponse, ApiClientGetPageStatus, ApiClientGetPageRequest, ApiClientGetPageContext, ResponseType>
    {
		public ApiClientServiceBase Service
        {
            get { return Store.Service as ApiClientServiceBase; }
        }
		
		
		public ApiClientGetPageStrategyBase ()
		{
			
			Init();
		}
    }
}