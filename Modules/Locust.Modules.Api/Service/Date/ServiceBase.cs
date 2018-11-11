using System;
using Locust.Db;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public abstract partial class DateServiceBase : BaseService
    {
		public DateNowStrategyBase Now 
		{ 
			get { return (Store as DateStrategyStore).Now; }
		}

		
		
        public DateServiceBase(DateStrategyStore store,IExceptionLogger logger, IDbHelper db): base(store,logger)
        {
			if (db == null)
				throw new ArgumentNullException("db");

			Db = db;

			Init();
		}
    }
}