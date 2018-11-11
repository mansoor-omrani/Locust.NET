using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByHashStrategy : ApiClientGetByHashStrategyBase
    {

		public ApiClientGetByHashStrategy ()
		{
			Init();
		}

		public override void Run(ApiClientGetByHashContext context)
		{
			ExecuteSingle(context);
			// ExecuteSingle(context, (req) => req.Id);
			// ExecuteSingle(context, (req) => req.Id, (req) => req.LifeLength);
			// ExecuteSingle(context, (reader) => {});
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id);
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(ApiClientGetByHashContext context)
		{
			return ExecuteSingleAsync(context);
			// return ExecuteSingleAsync(context, (req) => req.Id);
			// return ExecuteSingleAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteSingleAsync(context, (reader) => {});
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
    }
}