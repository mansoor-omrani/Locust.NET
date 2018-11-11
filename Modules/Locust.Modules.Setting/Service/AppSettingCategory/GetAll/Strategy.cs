using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetAllStrategy : AppSettingCategoryGetAllStrategyBase
    {
		public AppSettingCategoryGetAllStrategy (ICacheFactory iCacheFactory):base(iCacheFactory)
		{
			Init();
		}
		public override void Run(AppSettingCategoryGetAllContext context)
		{
			Execute(context);
			// Execute(context, (req) => req.Id);
			// Execute(context, (req) => req.Id, (req) => req.LifeLength);
			// Execute(context, (reader) => {});
			// Execute(context, (reader) => {}, (req) => req.Id);
			// Execute(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(AppSettingCategoryGetAllContext context)
		{
			return ExecuteAsync(context);
			// return ExecuteAsync(context, (req) => req.Id);
			// return ExecuteAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteAsync(context, (reader) => {});
			// return ExecuteAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
			
			return Task.Run(()=>{});
		}
    }
}