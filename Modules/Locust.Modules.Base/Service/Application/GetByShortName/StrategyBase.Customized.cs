using Locust.Caching;
using Application = Locust.Modules.Base.Model.Application;
using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
    public abstract partial class ApplicationGetByShortNameStrategyBase : BabbageItemFetcherStrategy<ApplicationGetByShortNameResponse, Application.AdminGrid, ApplicationGetByShortNameStatus, ApplicationGetByShortNameRequest, ApplicationGetByShortNameContext>
    {
		protected void Init()
		{
			Cache = cacheFactory.Get(CacheName.App);
		}

    }
}