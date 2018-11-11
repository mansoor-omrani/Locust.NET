using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class StateDeleteByIdStrategy : StateDeleteByIdStrategyBase
    {
		public StateDeleteByIdStrategy()
		{
			Init();
		}
		public override void Run(StateDeleteByIdContext context)
        {
			 ExecuteNonQuery(context);
			// ExecuteNonQuery(context, Func<StateDeleteByIdRequest, string> keySpecifier);
            throw new NotImplementedException();
        }

        public override Task RunAsync(StateDeleteByIdContext context)
        {
			 return ExecuteNonQueryAsync(context);
			// return ExecuteNonQueryAsync(context, Func<StateDeleteByIdRequest, string> keySpecifier);
            throw new NotImplementedException();
        }
    }
}