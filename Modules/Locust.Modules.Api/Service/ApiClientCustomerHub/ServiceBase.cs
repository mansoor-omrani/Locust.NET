using System;
using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiClientCustomerHubServiceBase : ApiBaseService
    {
		public ApiClientCustomerHubAddStrategyBase Add 
		{ 
			get { return (Store as ApiClientCustomerHubStrategyStore).Add; }
		}

		public ApiClientCustomerHubUpdateStrategyBase Update 
		{ 
			get { return (Store as ApiClientCustomerHubStrategyStore).Update; }
		}

		public ApiClientCustomerHubQuickUpdateStrategyBase QuickUpdate 
		{ 
			get { return (Store as ApiClientCustomerHubStrategyStore).QuickUpdate; }
		}

		public ApiClientCustomerHubDeleteStrategyBase Delete 
		{ 
			get { return (Store as ApiClientCustomerHubStrategyStore).Delete; }
		}

		public ApiClientCustomerHubGetByPKStrategyBase GetByPK 
		{ 
			get { return (Store as ApiClientCustomerHubStrategyStore).GetByPK; }
		}

		public ApiClientCustomerHubGetPageStrategyBase GetPage 
		{ 
			get { return (Store as ApiClientCustomerHubStrategyStore).GetPage; }
		}

		
		
        public ApiClientCustomerHubServiceBase(ServiceSettingServiceBase serviceSettingService, ApiClientCustomerHubStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(serviceSettingService, store, logger, db, cacheFactory)
        {
			Init();
		}
    }
}