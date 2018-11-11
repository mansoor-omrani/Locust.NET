using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginUpdateStrategyBase : BabbageDataManipulationStrategy<AppCrossOriginUpdateResponse, object, AppCrossOriginUpdateStatus, AppCrossOriginUpdateRequest, AppCrossOriginUpdateContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppCrossOriginUpdateStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}