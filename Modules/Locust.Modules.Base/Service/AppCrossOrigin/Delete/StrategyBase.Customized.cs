using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginDeleteStrategyBase : BabbageDataManipulationStrategy<AppCrossOriginDeleteResponse, object, AppCrossOriginDeleteStatus, AppCrossOriginDeleteRequest, AppCrossOriginDeleteContext>
    {
		protected void Init()
		{
            Cache = _iCacheFactory.Get(CacheName.AppCrossOrigin);
        }
    }
}