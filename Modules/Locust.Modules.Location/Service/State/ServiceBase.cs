using System;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Location.Strategies;
namespace Locust.Modules.Location.Service
{
	public abstract partial class StateServiceBase : BaseService
    {
		public StateAddStrategyBase Add 
		{ 
			get { return (Store as StateStrategyStore).Add; }
		}

		public StateUpdateStrategyBase Update 
		{ 
			get { return (Store as StateStrategyStore).Update; }
		}

		public StateDeleteByIdStrategyBase DeleteById 
		{ 
			get { return (Store as StateStrategyStore).DeleteById; }
		}

		public StateGetByIdStrategyBase GetById 
		{ 
			get { return (Store as StateStrategyStore).GetById; }
		}

		public StateGetByCodeStrategyBase GetByCode 
		{ 
			get { return (Store as StateStrategyStore).GetByCode; }
		}

		public StateGetAllStrategyBase GetAll 
		{ 
			get { return (Store as StateStrategyStore).GetAll; }
		}

		public StateGetCitiesStrategyBase GetCities 
		{ 
			get { return (Store as StateStrategyStore).GetCities; }
		}

		
		
        public StateServiceBase(StateStrategyStore store,IExceptionLogger logger, IDbHelper db): base(store,logger)
        {
			if (db == null)
				throw new ArgumentNullException("db");

			Db = db;

			Init();
		}
    }
}