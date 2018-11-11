using System;
using Locust.Caching;
using Locust.ServiceModel.Babbage;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiGetByPathStrategyBase : BabbageItemFetcherStrategy<ApiGetByPathResponse, API.Full, ApiGetByPathStatus, ApiGetByPathRequest, ApiGetByPathContext>
    {
		public ApiGetByPathStrategyBase ()
		{
			Init();
		}

    }
}