using System;
using Locust.Model;
using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Conversion;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetByTokenStrategy : ApiClientCustomerGetByTokenStrategyBase
    {

		public ApiClientCustomerGetByTokenStrategy (ApiClientCustomerHubServiceBase hubService) : base(hubService)
        {
			Init();
		}
		public override void Run(ApiClientCustomerGetByTokenContext context)
		{
            ExecuteSingle(context, Service.CacheKeySpecifier, Service.CacheLifeSpecifier, (cc) => !SafeClrConvert.ToBoolean(context.OutputParameters["IsChanged"].Value) && hubService.IsValidHub(cc.ApiClientCustomerHubId, context.Request.AccessToken));
		}
		public override Task RunAsync(ApiClientCustomerGetByTokenContext context)
		{
            return ExecuteSingleAsync(context, Service.CacheKeySpecifier, Service.CacheLifeSpecifier, (cc) => Task.FromResult(!SafeClrConvert.ToBoolean(context.OutputParameters["IsChanged"].Value) && hubService.IsValidHub(cc.ApiClientCustomerHubId, context.Request.AccessToken)));
        }
    }
}