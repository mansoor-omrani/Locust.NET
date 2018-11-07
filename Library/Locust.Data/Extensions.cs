using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;

namespace Locust.Data
{
    internal static class TypeHelper
    {
        public static Type TypeOfCommandParameter { get; set; }
        public static Type TypeOfCommandOutputParameter { get; set; }

        static TypeHelper()
        {
            TypeOfCommandParameter = typeof(CommandParameter);
            TypeOfCommandOutputParameter = typeof(CommandOutputParameter);
        }
    }
    public static class CommandParameterExtensions
    {
        public static bool IsCommandParameterType(this Type type)
        {
            return type == TypeHelper.TypeOfCommandParameter || type.DescendsFrom(TypeHelper.TypeOfCommandParameter);
        }
        public static bool IsCommandOutputParameterType(this Type type)
        {
            return type == TypeHelper.TypeOfCommandOutputParameter || type.DescendsFrom(TypeHelper.TypeOfCommandOutputParameter);
        }
    }
}
