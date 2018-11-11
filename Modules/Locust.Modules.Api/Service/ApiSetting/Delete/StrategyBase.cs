using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiSettingDeleteStrategyBase : BabbageDataManipulationStrategy<ApiSettingDeleteResponse, object, ApiSettingDeleteStatus, ApiSettingDeleteRequest, ApiSettingDeleteContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public ApiSettingDeleteStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}