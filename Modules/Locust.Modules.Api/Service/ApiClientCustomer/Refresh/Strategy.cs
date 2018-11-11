using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerRefreshStrategy : ApiClientCustomerRefreshStrategyBase
    {
		public ApiClientCustomerRefreshStrategy()
		{
			Init();
		}

        private void Finalize(ApiClientCustomerRefreshContext context)
        {
            if (context.Response.Success)
            {
                context.Response.Data = new CustomerRefreshResponseData();

                context.Response.Data.AccessToken = context.Response.NewAccessToken;
                context.Response.Data.RefreshToken = context.Response.NewRefreshToken;
                context.Response.Data.EncryptionCode = context.Response.NewEncryptionCode;

                Service.CacheRemove(context);
            }
        }
		public override void Run(ApiClientCustomerRefreshContext context)
        {
            // ExecuteNonQuery(context);
            // ExecuteNonQuery(context, Func<ApiClientCustomerRefreshRequest, string> keySpecifier);
            ExecuteNonQuery(context);
            Finalize(context);
        }

        public override async Task RunAsync(ApiClientCustomerRefreshContext context)
        {
            // return ExecuteNonQueryAsync(context);
            // return ExecuteNonQueryAsync(context, Func<ApiClientCustomerRefreshRequest, string> keySpecifier);
            await ExecuteNonQueryAsync(context);
            Finalize(context);
        }
    }
}