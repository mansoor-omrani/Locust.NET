using System;
using Locust.Model;
using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerHubGetByPKStrategy : ApiClientCustomerHubGetByPKStrategyBase
    {

		public ApiClientCustomerHubGetByPKStrategy (ApiClientServiceBase clientService) :base(clientService)
		{
			Init();
		}

		public override void Run(ApiClientCustomerHubGetByPKContext context)
		{
			// ExecuteSingle(context);
			ExecuteSingle(context, Service.CacheKeySpecifier, cch => clientService.IsValidClient(cch.ApiClientId, "Hub" + context.Request.Id));
			// ExecuteSingle(context, (req) => req.Id, (req) => req.LifeLength);
			// ExecuteSingle(context, (reader) => {});
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id);
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(ApiClientCustomerHubGetByPKContext context)
		{
			// return ExecuteSingleAsync(context);
			return ExecuteSingleAsync(context, Service.CacheKeySpecifier, cch => Task.FromResult(clientService.IsValidClient(cch.ApiClientId, "Hub" + context.Request.Id)));
			// return ExecuteSingleAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteSingleAsync(context, (reader) => {});
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
    }
}