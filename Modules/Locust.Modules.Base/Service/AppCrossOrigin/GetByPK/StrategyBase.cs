using Locust.Caching;
using Locust.ServiceModel.Babbage;
using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.Full;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginGetByPKStrategyBase : BabbageItemFetcherStrategy<AppCrossOriginGetByPKResponse, AppCrossOrigin, AppCrossOriginGetByPKStatus, AppCrossOriginGetByPKRequest, AppCrossOriginGetByPKContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppCrossOriginGetByPKStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init(iCacheFactory);
		}

    }
}