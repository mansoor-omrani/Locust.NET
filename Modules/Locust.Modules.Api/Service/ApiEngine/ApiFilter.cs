using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service.ApiEngine
{
    public interface IApiFilter
    {
        void OnBeforeRun(ApiEngineRunRequest request);
        void OnAfterRun(ApiEngineRunRequest request);
        void OnBegoreGetSettings(ApiEngineRunRequest request);
        void OnBeforeGetApp(ApiEngineRunRequest request);
        void OnBeforeGetCustomer(ApiEngineRunRequest request);
        void OnBeforeGetCustomerHub(ApiEngineRunRequest request);
        void OnBeforeGetClient(ApiEngineRunRequest request);
        void OnBeforeGetBody(ApiEngineRunRequest request);
        void OnBeforeGetApi(ApiEngineRunRequest request);
        void OnBeforeCheckClientIp(ApiEngineRunRequest request);
        void OnBeforeCheckApiAccess(ApiEngineRunRequest request);
        void OnBeforeCallService(ApiEngineRunRequest request);
        void OnAfterCallService(ApiEngineRunRequest request);
        void OnBeforeFinalize(ApiEngineRunRequest request);
        // ----------------- async --------------------
        Task OnBeforeRunAsync(ApiEngineRunRequest request);
        Task OnAfterRunAsync(ApiEngineRunRequest request);
        Task OnBegoreGetSettingsAsync(ApiEngineRunRequest request);
        Task OnBeforeGetAppAsync(ApiEngineRunRequest request);
        Task OnBeforeGetCustomerAsync(ApiEngineRunRequest request);
        Task OnBeforeGetCustomerHubAsync(ApiEngineRunRequest request);
        Task OnBeforeGetClientAsync(ApiEngineRunRequest request);
        Task OnBeforeGetBodyAsync(ApiEngineRunRequest request);
        Task OnBeforeGetApiAsync(ApiEngineRunRequest request);
        Task OnBeforeCheckClientIpAsync(ApiEngineRunRequest request);
        Task OnBeforeCheckApiAccessAsync(ApiEngineRunRequest request);
        Task OnBeforeCallServiceAsync(ApiEngineRunRequest request);
        Task OnAfterCallServiceAsync(ApiEngineRunRequest request);
        Task OnBeforeFinalizeAsync(ApiEngineRunRequest request);
    }

    public abstract class ApiFilter : IApiFilter
    {
        public virtual void OnBeforeRun(ApiEngineRunRequest request)
        {
        }

        public virtual void OnAfterRun(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBegoreGetSettings(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeGetApp(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeGetCustomer(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeGetCustomerHub(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeGetClient(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeGetBody(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeGetApi(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeCheckClientIp(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeCheckApiAccess(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeCallService(ApiEngineRunRequest request)
        {
        }

        public virtual void OnAfterCallService(ApiEngineRunRequest request)
        {
        }

        public virtual void OnBeforeFinalize(ApiEngineRunRequest request)
        {
        }
        // --------------------- async -----------------------
        public virtual Task OnBeforeRunAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnAfterRunAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBegoreGetSettingsAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeGetAppAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeGetCustomerAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeGetCustomerHubAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeGetClientAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeGetBodyAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeGetApiAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeCheckClientIpAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeCheckApiAccessAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeCallServiceAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnAfterCallServiceAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }

        public virtual Task OnBeforeFinalizeAsync(ApiEngineRunRequest request)
        { return Task.Factory.StartNew(() => { }); }
    }
}
