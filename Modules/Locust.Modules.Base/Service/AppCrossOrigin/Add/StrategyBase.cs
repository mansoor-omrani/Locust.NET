using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginAddStrategyBase : BabbageDataManipulationStrategy<AppCrossOriginAddResponse, object, AppCrossOriginAddStatus, AppCrossOriginAddRequest, AppCrossOriginAddContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public AppCrossOriginAddStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}