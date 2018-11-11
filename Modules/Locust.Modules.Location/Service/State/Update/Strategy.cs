using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class StateUpdateStrategy : StateUpdateStrategyBase
    {
		public StateUpdateStrategy()
		{
			Init();
		}
		public override void Run(StateUpdateContext context)
        {
			ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<StateUpdateRequest, string> keySpecifier);
           
        }

        public override Task RunAsync(StateUpdateContext context)
        {
			 return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<StateUpdateRequest, string> keySpecifier);
           
        }
    }
}