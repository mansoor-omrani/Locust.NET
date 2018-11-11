using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Caching;
using Locust.Collections;
using Locust.Db;
using Locust.Extensions;
using Locust.Logging;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Service
{
    public class ApiBaseService: BabbageService
    {
        
        protected ServiceSettingServiceBase serviceSettingService;
        public ApiBaseService(ServiceSettingServiceBase serviceSettingService, BaseServiceStrategyStore store, IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(store, logger, db, cacheFactory)
        {
            this.serviceSettingService = serviceSettingService;
        }
        public override void FetchSettings(IServiceStrategyContext context = null)
        {
            if (serviceSettingService != null)
            {
                var ctx = serviceSettingService.GetAllByService.Invoke(context, new ServiceSettingGetAllByServiceRequest { Service = this.Name });

                FinalizeFetchSettings(ctx);
            }
        }
        public override async Task FetchSettingsAsync(IServiceStrategyContext context = null)
        {
            if (serviceSettingService != null)
            {
                var ctx = await serviceSettingService.GetAllByService.InvokeAsync(context, new ServiceSettingGetAllByServiceRequest { Service = this.Name });

                FinalizeFetchSettings(ctx);
            }
        }

        private void FinalizeFetchSettings(ServiceSettingGetAllByServiceContext ctx)
        {
            if (ctx != null && ctx.Response.Success)
            {
                if (ctx.Response.Data == null || ctx.Response.Data.Count == 0)
                {
                    this.Settings = new CaseInsensitiveDictionary<string>();
                }
                else
                {
                    this.Settings = ctx.Response.Data.ToIDictionary(new CaseInsensitiveStringDictionary(true),
                        x => x.Key.Value, x => x.Value.Value);
                }
            }
            else
            {
                this.Settings = new CaseInsensitiveDictionary<string>();
            }
        }
    }
}
