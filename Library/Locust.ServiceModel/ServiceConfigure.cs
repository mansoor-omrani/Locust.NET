using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Extensions;

namespace Locust.ServiceModel
{
    public abstract class ServiceConfig
    {
        private static Dictionary<Type, Type> mapping;
        private static ConcurrentDictionary<string, Type> service_mapping;
        static ServiceConfig()
        {
            mapping = new Dictionary<Type, Type>();
            service_mapping = new ConcurrentDictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        }

        public void Register<T, U>()
        {
            if (!mapping.ContainsKey(typeof (T)))
            {
                mapping.Add(typeof (T), typeof (U));
            }
            if (typeof (T).DescendsFrom(typeof (BaseService)))
            {
                service_mapping.TryAdd(typeof (U).FullName, typeof (T));
            }
        }

        public static IDictionary<Type, Type> GetMappings()
        {
            return mapping;
        }

        public abstract void Configure();

        public static Type GetServiceAbstraction(string serviceName, string @namespace = "")
        {
            Type result = null;

            foreach (var item in service_mapping)
            {
                var _serviceName = "";
                var _shortServiceName = "";
                var _namespace = "";
                var lastDotIndex = item.Key.LastIndexOf(".");

                if (lastDotIndex > 0)
                {
                    _serviceName = item.Key.Right(item.Key.Length - lastDotIndex - 1);
                    _shortServiceName = _serviceName.Replace("Service", "");
                    _namespace = item.Key.Left(lastDotIndex + 1);

                    if (string.IsNullOrEmpty(@namespace))
                    {
                        if ((string.Compare(_serviceName, serviceName, StringComparison.OrdinalIgnoreCase) == 0) ||
                        (string.Compare(_shortServiceName, serviceName, StringComparison.OrdinalIgnoreCase) == 0))
                        {
                            result = item.Value;
                            break;
                        }
                    }
                    else
                    {
                        if ((string.Compare(item.Key, @namespace + "." + serviceName, StringComparison.OrdinalIgnoreCase) == 0) ||
                            (string.Compare(_namespace + _shortServiceName, @namespace + "." + serviceName, StringComparison.OrdinalIgnoreCase) == 0))
                        {
                            result = item.Value;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
