using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiSettingAddStrategyBase : BabbageDataManipulationStrategy<ApiSettingAddResponse, object, ApiSettingAddStatus, ApiSettingAddRequest, ApiSettingAddContext>
    {
		protected ICacheFactory _iCacheFactory;
		

		public ApiSettingAddStrategyBase (ICacheFactory iCacheFactory)
		{
			_iCacheFactory = iCacheFactory;
			
			Init();
		}

    }
}