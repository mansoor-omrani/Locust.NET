using System;
using System.Threading.Tasks;
using Locust.Model;
using Locust.Caching;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetByShortNameStrategy : ApplicationGetByShortNameStrategyBase
    {

		public ApplicationGetByShortNameStrategy (ICacheFactory cacheFactory ,ISetting iSetting):base(cacheFactory ,iSetting)
		{
			Init();
		}
        public override void Run(ApplicationGetByShortNameContext context)
        {
            // ExecuteSingle(context);
            ExecuteSingle(context, (ctx) => ctx.Request.ShortName);
            // ExecuteSingle(context, (req) => req.Id, (req) => req.LifeLength);
            // ExecuteSingle(context, (reader) => {});
            // ExecuteSingle(context, (reader) => {}, (req) => req.Id);
            // ExecuteSingle(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
        }
        public override Task RunAsync(ApplicationGetByShortNameContext context)
        {
            // return ExecuteSingleAsync(context);
            return ExecuteSingleAsync(context, (ctx) => ctx.Request.ShortName);
            // return ExecuteSingleAsync(context, (req) => req.Id, (req) => req.LifeLength);
            // return ExecuteSingleAsync(context, (reader) => {});
            // return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id);
            // return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
        }
		
    }
}