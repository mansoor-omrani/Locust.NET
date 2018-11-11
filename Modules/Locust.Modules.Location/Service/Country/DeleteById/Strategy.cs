using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CountryDeleteByIdStrategy : CountryDeleteByIdStrategyBase
    {
		public CountryDeleteByIdStrategy()
		{
			Init();
		}
		public override void Run(CountryDeleteByIdContext context)
        {
			 ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<CountryDeleteByIdRequest, string> keySpecifier);
        }

        public override Task RunAsync(CountryDeleteByIdContext context)
        {
			 return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<CountryDeleteByIdRequest, string> keySpecifier);
        }
    }
}