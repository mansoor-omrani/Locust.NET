using System;
using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Service
{
	public abstract partial class ServiceSettingServiceBase : BabbageService
    {
		public ServiceSettingAddStrategyBase Add 
		{ 
			get { return (Store as ServiceSettingStrategyStore).Add; }
		}

		public ServiceSettingUpdateStrategyBase Update 
		{ 
			get { return (Store as ServiceSettingStrategyStore).Update; }
		}

		public ServiceSettingDeleteStrategyBase Delete 
		{ 
			get { return (Store as ServiceSettingStrategyStore).Delete; }
		}

		public ServiceSettingGetAllByServiceStrategyBase GetAllByService
		{ 
			get { return (Store as ServiceSettingStrategyStore).GetAllByService; }
		}

		
		
        public ServiceSettingServiceBase(ServiceSettingStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory): base(store,logger, db, cacheFactory)
        {
			Init();
		}
    }
}