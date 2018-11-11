using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingGetAllByApiStrategy : ApiSettingGetAllByApiStrategyBase
    {
		public ApiSettingGetAllByApiStrategy (ICacheFactory iCacheFactory):base(iCacheFactory)
		{
			Init();
		}
		public override void Run(ApiSettingGetAllByApiContext context)
		{
			// Execute(context);
			Execute(context, (ctx) => ctx.Request.ApiId.ToString());
			// Execute(context, (reader) => {});
			// Execute(context, (reader) => {}, (req) => req.Id);
			// Execute(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(ApiSettingGetAllByApiContext context)
		{
            // return ExecuteAsync(context);
            return ExecuteAsync(context, (ctx) => ctx.Request.ApiId.ToString());
            // return ExecuteAsync(context, (req) => req.Id, (req) => req.LifeLength);
            // return ExecuteAsync(context, (reader) => {});
            // return ExecuteAsync(context, (reader) => {}, (req) => req.Id);
            // return ExecuteAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
        }
    }
}