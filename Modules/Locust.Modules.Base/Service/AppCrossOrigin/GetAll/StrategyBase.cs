using Locust.Caching;
using Locust.ServiceModel.Babbage;
using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.AdminGrid;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginGetAllStrategyBase : BabbageListFetcherStrategy<AppCrossOriginGetAllResponse, AppCrossOriginGetAllStatus, AppCrossOriginGetAllRequest, AppCrossOriginGetAllContext, AppCrossOrigin>
    {
		protected ICacheFactory _iCacheFactory;
		
		
		public AppCrossOriginGetAllStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init(iCacheFactory);
		}

    }
}