using System;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Base.Strategies;
namespace Locust.Modules.Base.Service
{
	public abstract partial class AppCrossOriginServiceBase : BaseService
    {
		public AppCrossOriginAddStrategyBase Add 
		{ 
			get { return (Store as AppCrossOriginStrategyStore).Add; }
		}

		public AppCrossOriginUpdateStrategyBase Update 
		{ 
			get { return (Store as AppCrossOriginStrategyStore).Update; }
		}

		public AppCrossOriginDeleteStrategyBase Delete 
		{ 
			get { return (Store as AppCrossOriginStrategyStore).Delete; }
		}

		public AppCrossOriginGetByPKStrategyBase GetByPK 
		{ 
			get { return (Store as AppCrossOriginStrategyStore).GetByPK; }
		}

		public AppCrossOriginGetAllStrategyBase GetAll 
		{ 
			get { return (Store as AppCrossOriginStrategyStore).GetAll; }
		}

		
		
        public AppCrossOriginServiceBase(AppCrossOriginStrategyStore store,IExceptionLogger logger, IDbHelper db): base(store,logger)
        {
			if (db == null)
				throw new ArgumentNullException("db");

			Db = db;

			Init();
		}
    }
}