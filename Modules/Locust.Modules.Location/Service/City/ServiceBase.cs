using System;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Location.Strategies;
namespace Locust.Modules.Location.Service
{
	public abstract partial class CityServiceBase : BaseService
    {
		public CityAddStrategyBase Add 
		{ 
			get { return (Store as CityStrategyStore).Add; }
		}

		public CityUpdateStrategyBase Update 
		{ 
			get { return (Store as CityStrategyStore).Update; }
		}

		public CityDeleteByIdStrategyBase DeleteById 
		{ 
			get { return (Store as CityStrategyStore).DeleteById; }
		}

		public CityGetByIdStrategyBase GetById 
		{ 
			get { return (Store as CityStrategyStore).GetById; }
		}

		public CityGetByCodeStrategyBase GetByCode 
		{ 
			get { return (Store as CityStrategyStore).GetByCode; }
		}

		public CityGetAllStrategyBase GetAll 
		{ 
			get { return (Store as CityStrategyStore).GetAll; }
		}
        public CityGetAllByStateStrategyBase GetAllByState
        {
            get { return (Store as CityStrategyStore).GetAllByState; }
        }
        public CityGetByStateStrategyBase GetByState 
		{ 
			get { return (Store as CityStrategyStore).GetByState; }
		}

		
		
        public CityServiceBase(CityStrategyStore store,IExceptionLogger logger, IDbHelper db): base(store,logger)
        {
			if (db == null)
				throw new ArgumentNullException("db");

			Db = db;

			Init();
		}
    }
}