using System;
using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Setting;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public abstract partial class ApplicationGetAllStrategyBase : BabbageListFetcherStrategy<ApplicationGetAllResponse, ApplicationGetAllStatus, ApplicationGetAllRequest, ApplicationGetAllContext, Application.AdminGrid>
    {
		protected ICacheFactory _iCacheFactory;
		protected ISetting _iSetting;
		
		
		public ApplicationGetAllStrategyBase (ICacheFactory iCacheFactory, ISetting iSetting)
		{
			if (iCacheFactory == null)
				throw new ArgumentNullException("iCacheFactory");
			_iCacheFactory = iCacheFactory;
			if (iSetting == null)
				throw new ArgumentNullException("iSetting");
			_iSetting = iSetting;
			
			Init(_iCacheFactory, _iSetting);
		}

    }
}