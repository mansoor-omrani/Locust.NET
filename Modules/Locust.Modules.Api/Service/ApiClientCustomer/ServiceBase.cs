using System;
using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiClientCustomerServiceBase : ApiBaseService
    {
		public ApiClientCustomerAddStrategyBase Add 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Add; }
		}

		public ApiClientCustomerUpdateStrategyBase Update 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Update; }
		}

		public ApiClientCustomerDeleteStrategyBase Delete 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Delete; }
		}

		public ApiClientCustomerSetActivatedStrategyBase SetActivated 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).SetActivated; }
		}

		public ApiClientCustomerSetDisabledStrategyBase SetDisabled 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).SetDisabled; }
		}

		public ApiClientCustomerUnlockStrategyBase Unlock 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Unlock; }
		}

		public ApiClientCustomerGetByPKStrategyBase GetByPK 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).GetByPK; }
		}

		public ApiClientCustomerGetByTokenStrategyBase GetByToken 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).GetByToken; }
		}

		public ApiClientCustomerCheckStrategyBase Check 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Check; }
		}

		public ApiClientCustomerActivateStrategyBase Activate 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Activate; }
		}

		public ApiClientCustomerRefreshStrategyBase Refresh 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Refresh; }
		}

		public ApiClientCustomerRegisterStrategyBase Register 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Register; }
		}

		public ApiClientCustomerEnrolStrategyBase Enrol 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).Enrol; }
		}

		public ApiClientCustomerGetPageStrategyBase GetPage 
		{ 
			get { return (Store as ApiClientCustomerStrategyStore).GetPage; }
		}
        public ApiClientCustomerServiceBase(ServiceSettingServiceBase serviceSettingService, ApiClientCustomerStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory): base(serviceSettingService, store, logger, db, cacheFactory)
        {
			Init();
		}
    }
}