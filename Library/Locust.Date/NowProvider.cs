using Locust.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Date
{
    public class NowProvider : InstanceProvider<INow, DateTimeNow>
    { }
}
