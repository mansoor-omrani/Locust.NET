using System;
using Locust.Model;
using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetByPKStrategy : ApiClientCustomerGetByPKStrategyBase
    {

		public ApiClientCustomerGetByPKStrategy (ApiClientCustomerHubServiceBase hubService):base(hubService)
		{
			Init();
		}

		public override void Run(ApiClientCustomerGetByPKContext context)
		{
            ExecuteSingle(context, Service.CacheKeySpecifier, Service.CacheLifeSpecifier, (cc) => hubService.IsValidHub(cc.ApiClientCustomerHubId, "Customer" + context.Request.Id));
		}
		public override async Task RunAsync(ApiClientCustomerGetByPKContext context)
		{
            await ExecuteSingleAsync(context, Service.CacheKeySpecifier, Service.CacheLifeSpecifier, (cc) => Task.FromResult(hubService.IsValidHub(cc.ApiClientCustomerHubId, "Customer" + context.Request.Id)));
		}
    }
}