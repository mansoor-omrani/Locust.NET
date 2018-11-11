using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
using Locust.Tracing;
namespace Locust.Modules.Location.Strategies
{
    public partial class CityAddStrategy : CityAddStrategyBase
    {
        public CityAddStrategy()
        {
            Init();
        }
        public override void Run(CityAddContext context)
        {
            ExecuteNonQuery(context);
        }

        public override Task RunAsync(CityAddContext context)
        {
            return ExecuteNonQueryAsync(context);
        }
    }
}