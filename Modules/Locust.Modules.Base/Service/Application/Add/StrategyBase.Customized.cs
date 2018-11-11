using Locust.Modules.Base.Service;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationAddStrategyBase : BabbageDataManipulationStrategy<ApplicationAddResponse, object, ApplicationAddStatus, ApplicationAddRequest, ApplicationAddContext>
    {
		protected void Init()
		{
            Cache = _iCacheFactory.Get(CacheName.App);
        }
    }
}