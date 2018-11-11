using System;
using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiServiceBase : ApiBaseService
    {
		public ApiAddStrategyBase Add 
		{ 
			get { return (Store as ApiStrategyStore).Add; }
		}

		public ApiUpdateStrategyBase Update 
		{ 
			get { return (Store as ApiStrategyStore).Update; }
		}

		public ApiDeleteStrategyBase Delete 
		{ 
			get { return (Store as ApiStrategyStore).Delete; }
		}

		public ApiGetByPKStrategyBase GetByPK 
		{ 
			get { return (Store as ApiStrategyStore).GetByPK; }
		}

		public ApiGetByPathStrategyBase GetByApiPath 
		{ 
			get { return (Store as ApiStrategyStore).GetByApiPath; }
		}

		public ApiGetAllStrategyBase GetAll 
		{ 
			get { return (Store as ApiStrategyStore).GetAll; }
		}

		public ApiGetAllByAppShortNameStrategyBase GetAllByAppShortName 
		{ 
			get { return (Store as ApiStrategyStore).GetAllByAppShortName; }
		}

		public ApiCheckAccessStrategyBase CheckAccess 
		{ 
			get { return (Store as ApiStrategyStore).CheckAccess; }
		}

		
		
        public ApiServiceBase(ServiceSettingServiceBase serviceSettingService, ApiStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(serviceSettingService, store, logger, db, cacheFactory)
        {
			Init();
		}
    }
}