using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiDeleteStrategyBase : BabbageDataManipulationStrategy<ApiDeleteResponse, object, ApiDeleteStatus, ApiDeleteRequest, ApiDeleteContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public ApiDeleteStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}