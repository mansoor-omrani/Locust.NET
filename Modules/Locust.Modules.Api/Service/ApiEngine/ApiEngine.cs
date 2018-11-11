using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service.ApiEngine
{
    public static class ApiEngine
    {
        private static List<IApiFilter> filters;
        static ApiEngine()
        {
            filters = new List<IApiFilter>();
        }

        public static void AddFilter(IApiFilter filter)
        {
            filters.Add(filter);
        }
        public static void OnBegoreGetSettings(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBegoreGetSettings(request);
            }
        }

        public static void OnBeforeGetApp(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeGetApp(request);
            }
        }

        public static void OnBeforeGetCustomer(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeGetCustomer(request);
            }
        }

        public static void OnBeforeGetCustomerHub(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeGetCustomerHub(request);
            }
        }

        public static void OnBeforeGetClient(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeGetClient(request);
            }
        }

        public static void OnBeforeGetBody(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeGetBody(request);
            }
        }

        public static void OnBeforeGetApi(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeGetApi(request);
            }
        }

        public static void OnBeforeCheckClientIp(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeCheckClientIp(request);
            }
        }

        public static void OnBeforeCheckApiAccess(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeCheckApiAccess(request);
            }
        }

        public static void OnBeforeCallService(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeCallService(request);
            }
        }

        public static void OnAfterCallService(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnAfterCallService(request);
            }
        }

        public static void OnBeforeFinalize(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                filter.OnBeforeFinalize(request);
            }
        }
        // ---------------------- async ---------------------
        public static async Task OnBeforeRunAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeRunAsync(request);
            }
        }

        public static async Task OnAfterRunAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnAfterRunAsync(request);
            }
        }

        public static async Task OnBegoreGetSettingsAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBegoreGetSettingsAsync(request);
            }
        }

        public static async Task OnBeforeGetAppAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeGetAppAsync(request);
            }
        }

        public static async Task OnBeforeGetCustomerAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeGetCustomerAsync(request);
            }
        }

        public static async Task OnBeforeGetCustomerHubAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeGetCustomerHubAsync(request);
            }
        }

        public static async Task OnBeforeGetClientAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeGetClientAsync(request);
            }
        }

        public static async Task OnBeforeGetBodyAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeGetBodyAsync(request);
            }
        }

        public static async Task OnBeforeGetApiAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeGetApiAsync(request);
            }
        }

        public static async Task OnBeforeCheckClientIpAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeCheckClientIpAsync(request);
            }
        }

        public static async Task OnBeforeCheckApiAccessAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeCheckApiAccessAsync(request);
            }
        }

        public static async Task OnBeforeCallServiceAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeCallServiceAsync(request);
            }
        }

        public static async Task OnAfterCallServiceAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnAfterCallServiceAsync(request);
            }
        }

        public static async Task OnBeforeFinalizeAsync(ApiEngineRunRequest request)
        {
            foreach (var filter in filters)
            {
                await filter.OnBeforeFinalizeAsync(request);
            }
        }
    }
}
