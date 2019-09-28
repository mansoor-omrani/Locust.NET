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
        public static TResponse Run<TRequest, TResponse>(this ServiceAction<TRequest, TResponse> action, object request)
            where TRequest : ServiceRequest, new()
            where TResponse : ServiceResponse, new()
        {
            var req = new TRequest();

            if (request != null)
            {
                var props = request.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(p => p.CanRead);
                var _props = request.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(p => p.CanRead);

                // TODO
                // Check AltNames attribute

                foreach (var prop in props)
                {
                    var _prop = req.GetType().GetProperty(prop.Name);
                    if (_prop != null)
                    {
                        _prop.SetValue(req, prop.GetValue(request));
                    }
                    else
                    {
                        // TODO: check AltNames
                    }
                }
            }

            return action.Run(req);
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
        public static Task<TResponse> RunAsync<TRequest, TResponse>(this ServiceAction<TRequest, TResponse> action, object request)
            where TRequest : ServiceRequest, new()
            where TResponse : ServiceResponse, new()
        {
            return action.RunAsync(request, CancellationToken.None);
        }
        public static Task<TResponse> RunAsync<TRequest, TResponse>(this ServiceAction<TRequest, TResponse> action, object request, CancellationToken cancellation)
            where TRequest : ServiceRequest, new()
            where TResponse : ServiceResponse, new()
        {
            var req = new TRequest();

            if (request != null)
            {
                var props = request.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(p => p.CanRead);
                var _props = request.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(p => p.CanRead);

                // TODO
                // Check AltNames attribute

                foreach (var prop in props)
                {
                    var _prop = req.GetType().GetProperty(prop.Name);
                    if (_prop != null)
                    {
                        _prop.SetValue(req, prop.GetValue(request));
                    }
                    else
                    {
                        // TODO: check AltNames
                    }
                }
            }

            return action.RunAsync(req, cancellation);
        }
    }
}
