using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;

namespace Locust.ModelField
{
    public static class ModelExtensions
    {
        public static bool IsModelField(this Type type)
        {
            return type.DescendsFrom(TypeHelper.TypeOfField);
        }
        public static bool IsNumericField(this Type type)
        {
            var result = false;

            result = (type == TypeHelper.TypeOfTInt64) || (type == TypeHelper.TypeOfTInt32) || (type == TypeHelper.TypeOfTInt16) || (type == TypeHelper.TypeOfTByte) ||
                    (type == TypeHelper.TypeOfTUInt64) || (type == TypeHelper.TypeOfTUInt32) || (type == TypeHelper.TypeOfTUInt16) || (type == TypeHelper.TypeOfTSByte) ||
                    (type == TypeHelper.TypeOfTSingle) || (type == TypeHelper.TypeOfTDouble || type == TypeHelper.TypeOfTDecimal);

            return result;
        }
    }
}
