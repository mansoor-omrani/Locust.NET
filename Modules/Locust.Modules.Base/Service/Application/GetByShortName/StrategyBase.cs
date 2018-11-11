using System;
using Locust.Caching;
using Application = Locust.Modules.Base.Model.Application;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
    public abstract partial class ApplicationGetByShortNameStrategyBase : BabbageItemFetcherStrategy<ApplicationGetByShortNameResponse, Application.AdminGrid, ApplicationGetByShortNameStatus, ApplicationGetByShortNameRequest, ApplicationGetByShortNameContext>
    {
		protected ISetting _iSetting;
		protected ICacheFactory cacheFactory;

		public ApplicationGetByShortNameStrategyBase (ICacheFactory cacheFactory ,ISetting iSetting)
		{
			if (cacheFactory == null)
				throw new ArgumentNullException("cacheFactory");
			this.cacheFactory = cacheFactory;
			if (iSetting == null)
				throw new ArgumentNullException("iSetting");
			_iSetting = iSetting;
			Init();
		}

    }
}