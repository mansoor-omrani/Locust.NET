using System;
using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiSettingServiceBase : BabbageService
    {
		public ApiSettingAddStrategyBase Add 
		{ 
			get { return (Store as ApiSettingStrategyStore).Add; }
		}

		public ApiSettingUpdateStrategyBase Update 
		{ 
			get { return (Store as ApiSettingStrategyStore).Update; }
		}

		public ApiSettingDeleteStrategyBase Delete 
		{ 
			get { return (Store as ApiSettingStrategyStore).Delete; }
		}

		public ApiSettingGetAllByApiStrategyBase GetAllByApi 
		{ 
			get { return (Store as ApiSettingStrategyStore).GetAllByApi; }
		}

		
		
        public ApiSettingServiceBase(ApiSettingStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory): base(store,logger, db, cacheFactory)
        {
			Init();
		}
    }
}