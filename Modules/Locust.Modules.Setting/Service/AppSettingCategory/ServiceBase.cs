using System;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Setting.Strategies;
namespace Locust.Modules.Setting.Service
{
	public abstract partial class AppSettingCategoryServiceBase : BaseService
    {
		public AppSettingCategoryAddStrategyBase Add 
		{ 
			get { return (Store as AppSettingCategoryStrategyStore).Add; }
		}

		public AppSettingCategoryUpdateStrategyBase Update 
		{ 
			get { return (Store as AppSettingCategoryStrategyStore).Update; }
		}

		public AppSettingCategoryDeleteStrategyBase Delete 
		{ 
			get { return (Store as AppSettingCategoryStrategyStore).Delete; }
		}

		public AppSettingCategoryGetByPKStrategyBase GetByPK 
		{ 
			get { return (Store as AppSettingCategoryStrategyStore).GetByPK; }
		}

		public AppSettingCategoryGetByCodeStrategyBase GetByKey 
		{ 
			get { return (Store as AppSettingCategoryStrategyStore).GetByKey; }
		}

		public AppSettingCategoryGetAllStrategyBase GetAll 
		{ 
			get { return (Store as AppSettingCategoryStrategyStore).GetAll; }
		}

		
		
        public AppSettingCategoryServiceBase(AppSettingCategoryStrategyStore store,IExceptionLogger logger, IDbHelper db): base(store,logger)
        {
			if (db == null)
				throw new ArgumentNullException("db");

			Db = db;

			Init();
		}
    }
}