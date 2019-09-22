using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;
using Locust.Service;

namespace Locust.Service.Moon
{
    public static class Extensions
    {
        public static ServiceResponse Run(this BaseService service, string name, object request = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be empty");

            var action = service.GetType().GetProperty(name);
            var method = action.GetType().GetMethod("Run");

            return null;
        }
        public static BaseServiceAction<BaseActionBasedService<TConfig>, TRequest, TResponse> GetAction<TConfig, TRequest, TResponse>(this BaseActionBasedService<TConfig> service, string name)
            where TRequest : ServiceRequest
            where TResponse : ServiceResponse, new()
            where TConfig : BaseConfig, new()
        {
            return service.Actions[name] as BaseServiceAction<BaseActionBasedService<TConfig>, TRequest, TResponse>;
        }
    }
}
