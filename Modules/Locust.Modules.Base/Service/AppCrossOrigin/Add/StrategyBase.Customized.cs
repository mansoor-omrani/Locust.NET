using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class AppCrossOriginAddStrategyBase : BabbageDataManipulationStrategy<AppCrossOriginAddResponse, object, AppCrossOriginAddStatus, AppCrossOriginAddRequest, AppCrossOriginAddContext>
    {
		protected void Init()
		{
            Cache = _iCacheFactory.Get(CacheName.AppCrossOrigin);
        }
    }
}