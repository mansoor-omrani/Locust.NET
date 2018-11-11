using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Base.Service;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationDeleteStrategyBase : BabbageDataManipulationStrategy<ApplicationDeleteResponse, object, ApplicationDeleteStatus, ApplicationDeleteRequest, ApplicationDeleteContext>
    {
		protected void Init()
		{
            Cache = _iCacheFactory.Get(CacheName.App);
        }
    }
}