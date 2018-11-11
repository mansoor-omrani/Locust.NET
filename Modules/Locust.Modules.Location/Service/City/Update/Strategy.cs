using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityUpdateStrategy : CityUpdateStrategyBase
    {
		public CityUpdateStrategy()
		{
			Init();
		}
		public override void Run(CityUpdateContext context)
        {
			 ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<CityUpdateRequest, string> keySpecifier);
        }

        public override Task RunAsync(CityUpdateContext context)
        {
			 return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<CityUpdateRequest, string> keySpecifier);
            
        }
    }
}