using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Service
{
    public interface IServiceAction<TService, TRequest, TResponse>
        where TService : class
    {
        TService Owner { get; }
        TResponse Run(TRequest request);
        Task<TResponse> RunAsync(TRequest request, CancellationToken token);
    }
    public abstract class ServiceAction<TService, TRequest, TResponse> : IServiceAction<TService, TRequest, TResponse>
        where TService : class
        where TRequest : ServiceRequest
        where TResponse : ServiceResponse, new()
    {
        public TService Owner { get; private set; }
        public virtual string Name { get { return this.GetType().Name; } }
        public ServiceAction(TService owner)
        {
            Owner = owner ?? throw new ArgumentException(nameof(owner));
        }
        protected abstract void RunInternal(TRequest request, TResponse response);
        protected abstract Task RunInternalAsync(TRequest request, TResponse response, CancellationToken token);
        protected virtual void OnError(TRequest request, TResponse response, Exception e)
        {
        }
        protected virtual bool OnBeforeRun(TRequest request, TResponse response)
        {
            return true;
        }
        protected virtual void OnAfterRun(TRequest request, TResponse response)
        {
        }
        public virtual TResponse Run(TRequest request)
        {
            var response = new TResponse();

            try
            {
                if (OnBeforeRun(request, response))
                {
                    RunInternal(request, response);

                    OnAfterRun(request, response);
                }
            }
            catch (Exception e)
            {
                response.Failed(e);

                OnError(request, response, e);
            }

            return response;
        }
        public Task<TResponse> RunAsync(TRequest request)
        {
            return RunAsync(request, CancellationToken.None);
        }
        public virtual async Task<TResponse> RunAsync(TRequest request, CancellationToken token)
        {
            var response = new TResponse();

            try
            {
                if (OnBeforeRun(request, response))
                {
                    await RunInternalAsync(request, response, token);

                    OnAfterRun(request, response);
                }
            }
            catch (Exception e)
            {
                response.Failed(e);

                OnError(request, response, e);
            }

            return response;
        }
    }
    public abstract class ServiceAction<TService, TConfig, TRequest, TResponse> : ServiceAction<TService, TRequest, TResponse>
        where TConfig : class, new()
        where TService : class, IService<TConfig>
        where TRequest : ServiceRequest
        where TResponse : ServiceResponse, new()
    {
        public ServiceAction(TService owner) : base(owner)
        {

        }
    }
}
