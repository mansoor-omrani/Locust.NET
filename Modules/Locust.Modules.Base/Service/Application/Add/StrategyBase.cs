using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationAddStrategyBase : BabbageDataManipulationStrategy<ApplicationAddResponse, object, ApplicationAddStatus, ApplicationAddRequest, ApplicationAddContext>
    {
		protected ICacheFactory _iCacheFactory;
		protected ISetting _iSetting;
		

		public ApplicationAddStrategyBase (ICacheFactory iCacheFactory, ISetting iSetting)
		{
			_iCacheFactory = iCacheFactory;
			_iSetting = iSetting;
			
			Init();
		}

    }
}