using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiDeleteStrategyBase : BabbageDataManipulationStrategy<ApiDeleteResponse, object, ApiDeleteStatus, ApiDeleteRequest, ApiDeleteContext>
    {
        public ApiServiceBase Service
        {
            get { return Store.Service as ApiServiceBase; }
        }
        protected void Init()
		{
            Cache = _iCacheFactory.Get(CacheName.Api);
        }
    }
}