using System;
using Locust.Db;
using Locust.Caching;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Service;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiClientServiceBase : ApiBaseService
    {
		public ApiClientAddStrategyBase Add 
		{ 
			get { return (Store as ApiClientStrategyStore).Add; }
		}

		public ApiClientUpdateStrategyBase Update 
		{ 
			get { return (Store as ApiClientStrategyStore).Update; }
		}

		public ApiClientDeleteByPKStrategyBase DeleteByPK 
		{ 
			get { return (Store as ApiClientStrategyStore).DeleteByPK; }
		}

		public ApiClientDeleteByKeyStrategyBase DeleteByKey 
		{ 
			get { return (Store as ApiClientStrategyStore).DeleteByKey; }
		}

		public ApiClientRemoveByPKStrategyBase RemoveByPK 
		{ 
			get { return (Store as ApiClientStrategyStore).RemoveByPK; }
		}

		public ApiClientRemoveByKeyStrategyBase RemoveByKey 
		{ 
			get { return (Store as ApiClientStrategyStore).RemoveByKey; }
		}

		public ApiClientGetByPKStrategyBase GetByPK 
		{ 
			get { return (Store as ApiClientStrategyStore).GetByPK; }
		}

		public ApiClientGetByKeyStrategyBase GetByKey 
		{ 
			get { return (Store as ApiClientStrategyStore).GetByKey; }
		}

		public ApiClientGetByHashStrategyBase GetByHash 
		{ 
			get { return (Store as ApiClientStrategyStore).GetByHash; }
		}

		public ApiClientGetAllStrategyBase GetAll 
		{ 
			get { return (Store as ApiClientStrategyStore).GetAll; }
		}

		public ApiClientGetApisStrategyBase GetApis 
		{ 
			get { return (Store as ApiClientStrategyStore).GetApis; }
		}

		public ApiClientSaveApisStrategyBase SaveApis 
		{ 
			get { return (Store as ApiClientStrategyStore).SaveApis; }
		}

		public ApiClientGetPageStrategyBase GetPage 
		{ 
			get { return (Store as ApiClientStrategyStore).GetPage; }
		}

		
		
        public ApiClientServiceBase(ServiceSettingServiceBase serviceSettingService, ApiClientStrategyStore store,IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory): base(serviceSettingService, store,logger, db, cacheFactory)
        {
			Init();
		}
    }
}