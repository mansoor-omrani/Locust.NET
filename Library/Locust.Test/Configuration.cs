using Locust.ServiceLocator;
using Locust.Test.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Test
{
    public class MappingItem
    {
        public Type From { get; set; }
        public Type To { get; set; }
        public LifeTimeType LifeTime { get; set; }
    }
    public static class Configuration
    {
        public static List<MappingItem> GetMappings()
        {
            return new List<MappingItem>
            {
                new MappingItem { From = typeof(IAuthenticationService), To = typeof(AuthenticationService), LifeTime = LifeTimeType.Transient }
            };
        }
    }
}
