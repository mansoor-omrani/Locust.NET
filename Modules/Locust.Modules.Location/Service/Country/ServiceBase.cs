using System;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Location.Strategies;
namespace Locust.Modules.Location.Service
{
	public abstract partial class CountryServiceBase : BaseService
    {
		public CountryAddStrategyBase Add 
		{ 
			get { return (Store as CountryStrategyStore).Add; }
		}

		public CountryUpdateStrategyBase Update 
		{ 
			get { return (Store as CountryStrategyStore).Update; }
		}

		public CountryDeleteByIdStrategyBase DeleteById 
		{ 
			get { return (Store as CountryStrategyStore).DeleteById; }
		}

		public CountryGetByIdStrategyBase GetById 
		{ 
			get { return (Store as CountryStrategyStore).GetById; }
		}

		public CountryGetByCodeStrategyBase GetByCode 
		{ 
			get { return (Store as CountryStrategyStore).GetByCode; }
		}

		public CountryGetAllStrategyBase GetAll 
		{ 
			get { return (Store as CountryStrategyStore).GetAll; }
		}

		
		
        public CountryServiceBase(CountryStrategyStore store,IExceptionLogger logger, IDbHelper db): base(store,logger)
        {
			if (db == null)
				throw new ArgumentNullException("db");

			Db = db;

			Init();
		}
    }
}