using System;
using Locust.Model;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetByCodeStrategy : AppSettingCategoryGetByCodeStrategyBase
    {

		public AppSettingCategoryGetByCodeStrategy (ICacheFactory iCacheFactory):base(iCacheFactory)
		{
			Init();
		}

		public override void Run(AppSettingCategoryGetByCodeContext context)
		{
			ExecuteSingle(context);
			// ExecuteSingle(context, (req) => req.Id);
			// ExecuteSingle(context, (req) => req.Id, (req) => req.LifeLength);
			// ExecuteSingle(context, (reader) => {});
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id);
			// ExecuteSingle(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
		public override Task RunAsync(AppSettingCategoryGetByCodeContext context)
		{
			return ExecuteSingleAsync(context);
			// return ExecuteSingleAsync(context, (req) => req.Id);
			// return ExecuteSingleAsync(context, (req) => req.Id, (req) => req.LifeLength);
			// return ExecuteSingleAsync(context, (reader) => {});
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id);
			// return ExecuteSingleAsync(context, (reader) => {}, (req) => req.Id, (req) => req.LifeLength);
		}
    }
}