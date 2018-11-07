using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ServiceModel.Babbage
{
    public class BabbageStrategyConfig
    {
        public string Name { get; set; }
        public string Command { get; set; }
        public string Type { get; set; }
    }
    public class BabbageServiceConfig
    {
        public string Name { get; set; }
        public List<BabbageStrategyConfig> Strategies { get; private set; }

        public BabbageServiceConfig()
        {
            Strategies = new List<BabbageStrategyConfig>();
        }
    }
    public class BabbageConfig
    {
        public List<BabbageServiceConfig> Services { get; private set; }

        public BabbageConfig()
        {
            Services = new List<BabbageServiceConfig>();
        }
    }
}
