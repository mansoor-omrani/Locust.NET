using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Base.Service;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationUpdateStrategyBase : BabbageDataManipulationStrategy<ApplicationUpdateResponse, object, ApplicationUpdateStatus, ApplicationUpdateRequest, ApplicationUpdateContext>
    {
		protected void Init()
		{
            Cache = _iCacheFactory.Get(CacheName.App);
        }
    }
}