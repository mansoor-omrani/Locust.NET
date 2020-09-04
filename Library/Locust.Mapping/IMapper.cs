using System;
using System.Data;

namespace Locust.Mapping
{
    public interface IMapper
    {
        object Map(IDataReader reader, Type type);
        object Map(Type type, object source);
    }
}