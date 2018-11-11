using Locust.Caching;
using Locust.ServiceModel;
using Locust.Modules.Api.Service;
using ApiClientCustomer = Locust.Modules.Api.Model.ApiClientCustomer;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerGetByPKStrategyBase : BabbageItemFetcherStrategy<ApiClientCustomerGetByPKResponse, ApiClientCustomer.Full, ApiClientCustomerGetByPKStatus, ApiClientCustomerGetByPKRequest, ApiClientCustomerGetByPKContext>
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