using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Locust.WebTools
{
    public class LangRouteConstraint : IRouteConstraint
    {
        private static string _langs;
        private static string _default;
        static LangRouteConstraint()
        {
            _langs = ConfigurationManager.AppSettings["SiteLanguages"]?.ToString();
            _default = ConfigurationManager.AppSettings["DefaultLanguage"]?.ToString();
        }
        public static string DefaultLanguage
        {
            get { return _default; }
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!string.IsNullOrEmpty(_langs))
            {
                if (string.Compare(parameterName, "lang", true) == 0)
                {
                    object value;

                    if (values.TryGetValue(parameterName, out value))
                    {
                        var _lang = value?.ToString();

                        return !string.IsNullOrEmpty(_lang) && _lang.In(_langs);
                    }

                    return false;
                }
            }

            return false;
        }
    }
}
