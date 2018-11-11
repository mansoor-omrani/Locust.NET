using System;
using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiClientIPServiceBase : ApiBaseService
    {
		public ApiClientIPAddStrategyBase Add 
		{ 
			get { return (Store as ApiClientIPStrategyStore).Add; }
		}

		public ApiClientIPUpdateStrategyBase Update 
		{ 
			get { return (Store as ApiClientIPStrategyStore).Update; }
		}

		public ApiClientIPDeleteStrategyBase Delete 
		{ 
			get { return (Store as ApiClientIPStrategyStore).Delete; }
		}

		public ApiClientIPSetIsActiveStrategyBase SetIsActive
		{ 
			get { return (Store as ApiClientIPStrategyStore).SetIsActive; }
		}

		public ApiClientIPGetAllStrategyBase GetAll 
		{ 
			get { return (Store as ApiClientIPStrategyStore).GetAll; }
		}

		
		
        public ApiClientIPServiceBase(ServiceSettingServiceBase serviceSettingService, ApiClientIPStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory): base(serviceSettingService, store, logger, db, cacheFactory)
        {
			Init();
		}
    }
}