using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.DateTime
{
    public interface INow
    {
        DateTime Value { get; }
    }
    public class DateTimeNow : INow
    {
        public DateTime Value
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
