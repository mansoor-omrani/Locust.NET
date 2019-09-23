using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Service
{
    public static class Extensions
    {
        public static TResponse Run<TRequest, TResponse>(this ServiceAction<TRequest, TResponse> action)
            where TRequest : ServiceRequest, new()
            where TResponse : ServiceResponse, new()
        {
            return action.Run(new TRequest());
        }
        public static Task<TResponse> RunAsync<TRequest, TResponse>(this ServiceAction<TRequest, TResponse> action)
            where TRequest : ServiceRequest, new()
            where TResponse : ServiceResponse, new()
        {
            return action.RunAsync(new TRequest(), CancellationToken.None);
        }
        public static Task<TResponse> RunAsync<TRequest, TResponse>(this ServiceAction<TRequest, TResponse> action, CancellationToken cancellation)
            where TRequest : ServiceRequest, new()
            where TResponse : ServiceResponse, new()
        {
            return action.RunAsync(new TRequest(), cancellation);
        }
    }
}
