using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationUpdateStrategyBase : BabbageDataManipulationStrategy<ApplicationUpdateResponse, object, ApplicationUpdateStatus, ApplicationUpdateRequest, ApplicationUpdateContext>
    {
		protected ICacheFactory _iCacheFactory;
		protected ISetting _iSetting;
		

		public ApplicationUpdateStrategyBase (ICacheFactory iCacheFactory, ISetting iSetting)
		{
			_iCacheFactory = iCacheFactory;
			_iSetting = iSetting;
			
			Init();
		}

    }
}