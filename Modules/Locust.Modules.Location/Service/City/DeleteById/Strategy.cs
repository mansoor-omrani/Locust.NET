using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityDeleteByIdStrategy : CityDeleteByIdStrategyBase
    {
		public CityDeleteByIdStrategy()
		{
			Init();
		}
		public override void Run(CityDeleteByIdContext context)
        {
			 ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<CityDeleteByIdRequest, string> keySpecifier);
        }

        public override Task RunAsync(CityDeleteByIdContext context)
        {
			 return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<CityDeleteByIdRequest, string> keySpecifier);
            
        }
    }
}