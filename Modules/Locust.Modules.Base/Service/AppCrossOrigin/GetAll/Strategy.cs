using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Caching;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginGetAllStrategy : AppCrossOriginGetAllStrategyBase
    {
		public AppCrossOriginGetAllStrategy (ICacheFactory iCacheFactory):base(iCacheFactory)
		{
			Init();
		}
		public override void Run(AppCrossOriginGetAllContext context)
		{
            // Execute(context);
            Execute(context, (ctx) => ctx.Request.AppId.ToString());
            // Execute(context, (req) => req.Id, (req) => req.LifeLength);
            // Execute(context, (reader) => {});
            // Execute(context, (reader) => {}, (req) => req.Id);
            // Execute(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
        }
		public override Task RunAsync(AppCrossOriginGetAllContext context)
		{
            // return ExecuteAsync(context);
            return ExecuteAsync(context, (ctx) => ctx.Request.AppId.ToString());
            // return ExecuteAsync(context, (req) => req.Id, (req) => req.LifeLength);
            // return ExecuteAsync(context, (reader) => {});
            // return ExecuteAsync(context, (reader) => {}, (req) => req.Id);
            // return ExecuteAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
        }
    }
}