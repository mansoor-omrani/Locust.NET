using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Service;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerGetByTokenStrategyBase : BabbageItemFetcherStrategy<ApiClientCustomerGetByTokenResponse, ApiClientCustomer.Full, ApiClientCustomerGetByTokenStatus, ApiClientCustomerGetByTokenRequest, ApiClientCustomerGetByTokenContext>
    {
        public ApiClientCustomerServiceBase Service
        {
            get { return Store.Service as ApiClientCustomerServiceBase; }
        }
        protected void Init()
		{
        }

    }
}