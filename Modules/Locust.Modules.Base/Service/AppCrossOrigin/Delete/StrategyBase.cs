using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginDeleteStrategyBase : BabbageDataManipulationStrategy<AppCrossOriginDeleteResponse, object, AppCrossOriginDeleteStatus, AppCrossOriginDeleteRequest, AppCrossOriginDeleteContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppCrossOriginDeleteStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}