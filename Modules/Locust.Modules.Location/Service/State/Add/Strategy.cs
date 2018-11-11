using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class StateAddStrategy : StateAddStrategyBase
    {
		public StateAddStrategy()
		{
			Init();
		}
		public override void Run(StateAddContext context)
        {
			 ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<StateAddRequest, string> keySpecifier);
           
        }

        public override Task RunAsync(StateAddContext context)
        {
			 return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<StateAddRequest, string> keySpecifier);
            
        }
    }
}