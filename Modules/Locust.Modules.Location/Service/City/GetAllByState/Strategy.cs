using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetAllByStateStrategy : CityGetAllByStateStrategyBase
    {
		public CityGetAllByStateStrategy ():base()
		{
			Init();
		}
		public override void Run(CityGetAllByStateContext context)
		{
			Execute(context);
            
            // Execute(context, (req) => req.Id);
			// Execute(context, (req) => req.Id, (req) => req.LifeLength);
			// Execute(context, (reader) => {});
			// Execute(context, (reader) => {}, (req) => req.Id);
			// Execute(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(CityGetAllByStateContext context)
		{
			return ExecuteAsync(context);

			// return ExecuteAsync(context, (req) => req.Id);
			// return ExecuteAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteAsync(context, (reader) => {});
			// return ExecuteAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
    }
}