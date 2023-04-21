using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.DateTime
{
    public interface INow
    {
        System.DateTime Value { get; }
    }
    public class DateTimeNow : INow
    {
        public System.DateTime Value
        {
            get
            {
                return System.DateTime.Now;
            }
        }
    }
}
