using System;
using Locust.Caching;
using Locust.ServiceModel.Babbage;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiGetAllByAppShortNameStrategyBase : BabbageListFetcherStrategy<ApiGetAllByAppShortNameResponse, ApiGetAllByAppShortNameStatus, ApiGetAllByAppShortNameRequest, ApiGetAllByAppShortNameContext, API.Full>
    {
        public ApiGetAllByAppShortNameStrategyBase ()
		{
            Init();
		}

    }
}