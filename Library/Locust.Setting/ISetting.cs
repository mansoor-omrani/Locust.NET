using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Setting
{
    public interface ISetting
    {
        dynamic Config { get; }
        dynamic Db { get; }
        dynamic Text { get; }
    }
}
