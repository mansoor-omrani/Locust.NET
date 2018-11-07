using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Service
{
    public abstract class ServiceAction<TRequest, TResponse>
        where TRequest : ServiceRequest
        where TResponse : ServiceResponse, new()
    {
        protected abstract void RunInternal(TRequest request, TResponse response);
        protected abstract Task RunInternalAsync(TRequest request, TResponse response, CancellationToken token);
        public virtual TResponse Run(TRequest request)
        {
            var response = new TResponse();

            try
            {
                RunInternal(request, response);
            }
            catch (Exception e)
            {
                response.Failed(e);
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
                await RunInternalAsync(request, response, token);
            }
            catch (Exception e)
            {
                response.Failed(e);
            }

            return response;
        }
    }
}
