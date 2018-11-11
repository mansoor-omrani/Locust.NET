using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CountryAddStrategy : CountryAddStrategyBase
    {
		public CountryAddStrategy()
		{
			Init();
		}
		public override void Run(CountryAddContext context)
        {
			 ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<CountryAddRequest, string> keySpecifier);
            
        }

        public override Task RunAsync(CountryAddContext context)
        {
			 return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<CountryAddRequest, string> keySpecifier);
        
        }
    }
}