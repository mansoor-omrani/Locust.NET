using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Json;

namespace Locust.Model
{
    public class ModelManipulationTemplate: JsonModel
    {
        public StringComparison Comparison { get; set; }
    }
}
