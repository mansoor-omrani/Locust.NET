using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginUpdateStrategyBase : BabbageDataManipulationStrategy<AppCrossOriginUpdateResponse, object, AppCrossOriginUpdateStatus, AppCrossOriginUpdateRequest, AppCrossOriginUpdateContext>
    {
		protected void Init()
		{
            Cache = _iCacheFactory.Get(CacheName.AppCrossOrigin);
        }
    }
}