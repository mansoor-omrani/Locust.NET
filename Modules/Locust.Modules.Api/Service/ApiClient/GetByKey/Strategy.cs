using System;
using Locust.Model;
using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientGetByKeyStrategy : ApiClientGetByKeyStrategyBase
    {

		public ApiClientGetByKeyStrategy ()
		{
			Init();
		}

		public override void Run(ApiClientGetByKeyContext context)
		{
			// ExecuteSingle(context);
			ExecuteSingle(context, Service.CacheKeySpecifier);
			// ExecuteSingle(context, (req) => req.Id, (req) => req.LifeLength);
			// ExecuteSingle(context, (reader) => {});
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id);
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(ApiClientGetByKeyContext context)
		{
			// return ExecuteSingleAsync(context);
            return ExecuteSingleAsync(context, Service.CacheKeySpecifier);
			// return ExecuteSingleAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteSingleAsync(context, (reader) => {});
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
    }
}