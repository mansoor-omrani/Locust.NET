using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.BaseInfo
{
    public static class BaseInfoExtensions
    {
        public static bool IsBaseInfoType(this Type type)
        {
            if (type.IsGenericType)
            {
                return type.GetGenericTypeDefinition() == BaseInfoHelper.TypeOfBasicData;
            }
            else
            {
                return false;
            }
        }
    }
    public static class BaseInfoHelper
    {
        public static Type TypeOfBasicData;
        static BaseInfoHelper()
        {
            TypeOfBasicData = typeof(BasicData<>);
        }
    }
}
