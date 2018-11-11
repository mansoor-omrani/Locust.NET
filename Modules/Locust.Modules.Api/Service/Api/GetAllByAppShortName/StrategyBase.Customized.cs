using Locust.Modules.Api.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiGetAllByAppShortNameStrategyBase : BabbageListFetcherStrategy<ApiGetAllByAppShortNameResponse, ApiGetAllByAppShortNameStatus, ApiGetAllByAppShortNameRequest, ApiGetAllByAppShortNameContext, API.Full>
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