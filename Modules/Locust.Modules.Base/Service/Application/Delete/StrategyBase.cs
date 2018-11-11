using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationDeleteStrategyBase : BabbageDataManipulationStrategy<ApplicationDeleteResponse, object, ApplicationDeleteStatus, ApplicationDeleteRequest, ApplicationDeleteContext>
    {
		protected ICacheFactory _iCacheFactory;
		protected ISetting _iSetting;
		

		public ApplicationDeleteStrategyBase (ICacheFactory iCacheFactory, ISetting iSetting)
		{
			_iCacheFactory = iCacheFactory;
			_iSetting = iSetting;
			
			Init();
		}

    }
}