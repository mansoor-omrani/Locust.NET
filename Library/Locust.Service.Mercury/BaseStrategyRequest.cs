using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public class BaseStrategyRequest
    {
        private IDictionary<string, object> values;
        public IDictionary<string, object> Values
        {
            get
            {
                if (values == null)
                {
                    values = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
                }

                return values;
            }
        }
    }
    public class BaseStrategyRequest<TData> : BaseStrategyRequest
    {
        public TData Data { get; set; }
    }
}
