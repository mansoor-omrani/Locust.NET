using Locust.ServiceModel;
using System;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class DateStrategyStore : BaseServiceStrategyStore
    {
		public DateNowStrategyBase Now 
		{ 
			get { return _nowStrategy; }
		}

		
		protected DateNowStrategyBase _nowStrategy;
		
        public DateStrategyStore(DateNowStrategyBase nowStrategy)
        {
			if (nowStrategy == null)
				throw new ArgumentNullException("nowStrategy");

			
			_nowStrategy = nowStrategy;
			
            Register(nowStrategy);
			
			Init();
        }
    }
}