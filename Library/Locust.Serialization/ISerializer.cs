using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Serialization
{
    public interface ISerializer
    {
        byte[] Serialize(object o);
        object Deserialize(byte[] bytes);
        object Deserialize(byte[] bytes, Type type);
    }
}
