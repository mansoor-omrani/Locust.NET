using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Caching;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetAllStrategy : AppSettingGetAllStrategyBase
    {
		public AppSettingGetAllStrategy (ICacheFactory iCacheFactory):base(iCacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingGetAllContext context)
		{
			Execute(context);
			// Execute(context, (req) => req.Id);
			// Execute(context, (req) => req.Id, (req) => req.LifeLength);
			// Execute(context, (reader) => {});
			// Execute(context, (reader) => {}, (req) => req.Id);
			// Execute(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(AppSettingGetAllContext context)
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