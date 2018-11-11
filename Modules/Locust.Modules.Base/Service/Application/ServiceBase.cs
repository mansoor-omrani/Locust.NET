using System;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Base.Strategies;
namespace Locust.Modules.Base.Service
{
	public abstract partial class ApplicationServiceBase : BaseService
    {
		public ApplicationAddStrategyBase Add 
		{ 
			get { return (Store as ApplicationStrategyStore).Add; }
		}

		public ApplicationUpdateStrategyBase Update 
		{ 
			get { return (Store as ApplicationStrategyStore).Update; }
		}

		public ApplicationDeleteStrategyBase Delete 
		{ 
			get { return (Store as ApplicationStrategyStore).Delete; }
		}

		public ApplicationGetByPKStrategyBase GetByPK 
		{ 
			get { return (Store as ApplicationStrategyStore).GetByPK; }
		}

		public ApplicationGetByShortNameStrategyBase GetByShortName 
		{ 
			get { return (Store as ApplicationStrategyStore).GetByShortName; }
		}

		public ApplicationGetAllStrategyBase GetAll 
		{ 
			get { return (Store as ApplicationStrategyStore).GetAll; }
		}

		
		
        public ApplicationServiceBase(ApplicationStrategyStore store,IExceptionLogger logger, IDbHelper db): base(store,logger)
        {
			if (db == null)
				throw new ArgumentNullException("db");

			Db = db;

			Init();
		}
    }
}