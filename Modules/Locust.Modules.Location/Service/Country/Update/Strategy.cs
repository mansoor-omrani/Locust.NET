using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CountryUpdateStrategy : CountryUpdateStrategyBase
    {
		public CountryUpdateStrategy()
		{
			Init();
		}
		public override void Run(CountryUpdateContext context)
        {
			 ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<CountryUpdateRequest, string> keySpecifier);
        }

        public override Task RunAsync(CountryUpdateContext context)
        {
            return ExecuteNonQueryAsync(context);
            // return ExecuteNonQueryAsync(context, Func<CountryUpdateRequest, string> keySpecifier);
        }
    }
}