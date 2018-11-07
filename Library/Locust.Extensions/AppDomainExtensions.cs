using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class AppDomainExtensions
    {
        public static bool IsNamespaceDefined(this AppDomain domain, string nameSpace, StringComparison comparison = StringComparison.Ordinal)
        {
            return
                (from assembly in domain.GetAssemblies()
                 from type in assembly.GetTypes()
                 where string.Compare(type.Namespace, nameSpace, comparison) == 0
                 select type).Any();
        }
        public static bool IsTypeDefined(this AppDomain domain, string nameSpace, string className, StringComparison comparison = StringComparison.Ordinal)
        {
            return (from assembly in domain.GetAssemblies()
                    from type in assembly.GetTypes()
                    where string.Compare(type.Name, className, comparison) == 0 && type.GetMethods().Any()
                    select type).FirstOrDefault() != null;
        }

        public static List<Type> GetSubClasses<T>(this AppDomain domain, bool directDescendent = true)
        {
            return domain.GetSubClasses(typeof(T), directDescendent);
        }

        public static List<Type> GetSubClasses(this AppDomain domain, Type type, bool directDescendent = true)
        {
            var result = (from assembly in domain.GetAssemblies()
                from t in assembly.GetSubClasses(type, directDescendent)
                select t).ToList();

            return result;
        }
    }
}
