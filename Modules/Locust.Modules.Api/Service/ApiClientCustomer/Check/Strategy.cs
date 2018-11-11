using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerCheckStrategy : ApiClientCustomerCheckStrategyBase
    {
		public ApiClientCustomerCheckStrategy()
		{
			Init();
		}
		public override void Run(ApiClientCustomerCheckContext context)
        {
			ExecuteSingle(context);
            // ExecuteSingle(context, Func<ApiClientCustomerCheckRequest, string> keySpecifier);
        }

        public override Task RunAsync(ApiClientCustomerCheckContext context)
        {
			return ExecuteSingleAsync(context);
            // return ExecuteSingleAsync(context, Func<ApiClientCustomerCheckRequest, string> keySpecifier);
        }
    }
}