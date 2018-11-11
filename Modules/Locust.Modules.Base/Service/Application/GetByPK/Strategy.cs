using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetByPKStrategy : ApplicationGetByPKStrategyBase
    {

		public ApplicationGetByPKStrategy (ICacheFactory iCacheFactory, ISetting iSetting):base(iCacheFactory, iSetting)
		{
			Init();
		}

		public override void Run(ApplicationGetByPKContext context)
		{
			ExecuteSingle(context, (ctx) => ctx.Request.Id.ToString());
			// ExecuteSingle(context, (req) => req.Id);
			// ExecuteSingle(context, (req) => req.Id, (req) => req.LifeLength);
			// ExecuteSingle(context, (reader) => {});
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id);
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(ApplicationGetByPKContext context)
		{
			return ExecuteSingleAsync(context, (ctx) => ctx.Request.Id.ToString());
			// return ExecuteSingleAsync(context, (req) => req.Id);
			// return ExecuteSingleAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteSingleAsync(context, (reader) => {});
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
    }
}