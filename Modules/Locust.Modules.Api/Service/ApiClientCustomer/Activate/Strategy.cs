using Locust.Caching;
using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerActivateStrategy : ApiClientCustomerActivateStrategyBase
    {
        public ApiClientCustomerActivateStrategy()
        {
            Init();
        }

        private void Initialize(ApiClientCustomerActivateContext context)
        {
            //if (context.OverrideAppId > 0)
            //{
            //    context.Request.AppId = context.OverrideAppId;
            //}
            //else
            //{
            //    context.Request.AppId = context.Request.CallContext.App.AppId;
            //}
        }
        private void Finalize(ApiClientCustomerActivateContext context, ApiClientCustomerGetByPKContext ctx)
        {
            context.Request.CallContext.Customer = ctx.Response.Data;

            if (ctx.Response.Success && ctx.Response.Data != null)
            {
                context.Response.Data = new ApiClientCustomerActivateResponseData();

                context.Response.Data.AccessToken = ctx.Response.Data.AccessToken;
                context.Response.Data.RefreshToken = ctx.Response.Data.RefreshToken;
                context.Response.Data.EncryptionCode = ctx.Response.Data.EncryptionCode;
                context.Response.Data.LifeLength = ctx.Response.Data.LifeLength;

                Service.CacheRemove(context);

                context.Request.CallContext.Customer.EncryptionCode.Value = context.Response.OldEncryptionCode;
            }
        }
        public override void Run(ApiClientCustomerActivateContext context)
        {
            Initialize(context);

            ExecuteNonQuery(context);

            if (context.Response.Success && context.Response.ApiClientCustomerId > 0)
            {
                var store = this.Store as ApiClientCustomerStrategyStore;
                var ctx = store.GetByPK.CreateContextBy(context);

                ctx.Request.Id = context.Response.ApiClientCustomerId;
                store.GetByPK.Run(ctx);

                Finalize(context, ctx);
            }
            // ExecuteNonQuery(context, Func<CustomerActivateRequest, string> keySpecifier);
        }

        public override async Task RunAsync(ApiClientCustomerActivateContext context)
        {
            Initialize(context);

            await ExecuteNonQueryAsync(context);

            if (context.Response.Success && context.Response.ApiClientCustomerId > 0)
            {
                var store = this.Store as ApiClientCustomerStrategyStore;
                var ctx = store.GetByPK.CreateContextBy(context);

                ctx.Request.Id = context.Response.ApiClientCustomerId;
                await store.GetByPK.RunAsync(ctx);

                Finalize(context, ctx);
            }
            // return ExecuteNonQueryAsync(context, Func<CustomerActivateRequest, string> keySpecifier);
        }
    }
}