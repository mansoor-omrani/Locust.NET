using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ServiceModel
{
    public class StratgeyLocalizedMessages
    {
        public string Lang { get; set; }
        public Dictionary<string, string> Items { get; set; }
    }
    public class StrategyMessages
    {
        public string Strategy { get; set; }
        public List<StratgeyLocalizedMessages> Messages { get; set; }
    }
    public class ServiceMessages
    {
        public string Service { get; set; }
        public List<StrategyMessages> Strategies { get; set; }
    }
}
