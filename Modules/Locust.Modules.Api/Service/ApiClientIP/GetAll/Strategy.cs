using System;
using Locust.Model;
using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPGetAllStrategy : ApiClientIPGetAllStrategyBase
    {
		public ApiClientIPGetAllStrategy (ApiClientServiceBase clientService):base(clientService)
		{
			Init();
		}
		public override void Run(ApiClientIPGetAllContext context)
		{
            // Execute(context);
			Execute(context, (ctx) => ctx.Request.ApiClientId.ToString(), x => clientService.IsValidClient(context.Request.ApiClientId, "ClientIP.GetAll"));
			// Execute(context, (req) => req.Id, (req) => req.LifeLength);
			// Execute(context, (reader) => {});
			// Execute(context, (reader) => {}, (req) => req.Id);
			// Execute(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(ApiClientIPGetAllContext context)
		{
			// return ExecuteAsync(context);
			return ExecuteAsync(context, (ctx) => ctx.Request.ApiClientId.ToString(), x => Task.FromResult(clientService.IsValidClient(context.Request.ApiClientId, "ClientIP.GetAll")));
			// return ExecuteAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteAsync(context, (reader) => {});
			// return ExecuteAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
    }
}