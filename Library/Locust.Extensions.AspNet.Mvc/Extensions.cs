using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Extensions.AspNet.Mvc
{
    public static class Extensions
    {
        public static string Join(this ICollection<ModelState> modelStateValues, string separator = ",")
        {
            var result = "";

            foreach (var x in modelStateValues)
            {
                foreach (var y in x.Errors)
                {
                    result += (string.IsNullOrEmpty(result)? "" : separator) + y.ErrorMessage;
                }
            }

            return result;
        }
    }
}
