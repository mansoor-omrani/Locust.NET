using Locust.Caching;
using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.AdminGrid;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginGetAllStrategyBase : BabbageListFetcherStrategy<AppCrossOriginGetAllResponse, AppCrossOriginGetAllStatus, AppCrossOriginGetAllRequest, AppCrossOriginGetAllContext, AppCrossOrigin>
    {
		protected void Init(ICacheFactory iCacheFactory)
		{
            Cache = _iCacheFactory.Get(CacheName.AppCrossOrigin);
        }

    }
}