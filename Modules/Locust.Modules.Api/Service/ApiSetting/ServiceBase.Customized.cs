using System.Threading.Tasks;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiSettingServiceBase : BabbageService
    {
        protected virtual void InitSettings()
        {
            this.Settings.Add("UseCache", "true");
        }
        public override void FetchSettings(IServiceStrategyContext context = null)
        {
            base.FetchSettings(context);

            InitSettings();
        }

        public override async Task FetchSettingsAsync(IServiceStrategyContext context = null)
        {
            await base.FetchSettingsAsync(context);

            InitSettings();
        }
        protected void Init()
		{
            Cache = CacheFactory.Get(CacheName.ApiSettings);
        }
    }
}