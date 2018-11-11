using System;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Setting;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetAllStrategy : ApplicationGetAllStrategyBase
    {
		public ApplicationGetAllStrategy (ICacheFactory iCacheFactory, ISetting iSetting):base(iCacheFactory, iSetting)
		{
			Init();
		}
		public override void Run(ApplicationGetAllContext context)
		{
			Execute(context);
			// Execute(context, (req) => req.Id);
			// Execute(context, (req) => req.Id, (req) => req.LifeLength);
			// Execute(context, (reader) => {});
			// Execute(context, (reader) => {}, (req) => req.Id);
			// Execute(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(ApplicationGetAllContext context)
		{
			return ExecuteAsync(context);
			// return ExecuteAsync(context, (req) => req.Id);
			// return ExecuteAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteAsync(context, (reader) => {});
			// return ExecuteAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
    }
}