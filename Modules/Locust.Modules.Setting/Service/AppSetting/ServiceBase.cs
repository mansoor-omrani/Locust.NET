using System;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Setting.Strategies;
namespace Locust.Modules.Setting.Service
{
	public abstract partial class AppSettingServiceBase : BaseService
    {
		public AppSettingAddStrategyBase Add 
		{ 
			get { return (Store as AppSettingStrategyStore).Add; }
		}

		public AppSettingQuickAddStrategyBase QuickAdd 
		{ 
			get { return (Store as AppSettingStrategyStore).QuickAdd; }
		}

		public AppSettingUpdateStrategyBase Update 
		{ 
			get { return (Store as AppSettingStrategyStore).Update; }
		}

		public AppSettingQuickUpdateStrategyBase QuickUpdate 
		{ 
			get { return (Store as AppSettingStrategyStore).QuickUpdate; }
		}

		public AppSettingDeleteStrategyBase Delete 
		{ 
			get { return (Store as AppSettingStrategyStore).Delete; }
		}

		public AppSettingGetByPKStrategyBase GetByPK 
		{ 
			get { return (Store as AppSettingStrategyStore).GetByPK; }
		}

		public AppSettingGetByKeyStrategyBase GetByKey 
		{ 
			get { return (Store as AppSettingStrategyStore).GetByKey; }
		}

		public AppSettingGetAllStrategyBase GetAll 
		{ 
			get { return (Store as AppSettingStrategyStore).GetAll; }
		}

		
		
        public AppSettingServiceBase(AppSettingStrategyStore store,IExceptionLogger logger, IDbHelper db): base(store,logger)
        {
			if (db == null)
				throw new ArgumentNullException("db");

			Db = db;

			Init();
		}
    }
}