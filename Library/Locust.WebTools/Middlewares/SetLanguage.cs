using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace Locust.WebTools
{
    public static class SetLanguage
    {
        private static string _langs;
        private static string _langStatus;
        private static string _langItemName;
        private static string _langRouteArgName;
        private static string _langParamName;
        private static string _langSource;
        public static string DefaultLanguage { get; set; }
        static SetLanguage()
        {
            _langItemName = WebConfigurationManager.AppSettings["LangItemName"];

            if (string.IsNullOrEmpty(_langItemName))
            {
                _langItemName = "Lang";
            }

            _langRouteArgName = WebConfigurationManager.AppSettings["LangRouteArgName"];

            if (string.IsNullOrEmpty(_langRouteArgName))
            {
                _langRouteArgName = "lang";
            }

            _langStatus = WebConfigurationManager.AppSettings["LangStatus"];
            _langSource = WebConfigurationManager.AppSettings["LangSource"];
            _langParamName = WebConfigurationManager.AppSettings["LangParamName"];

            if (string.IsNullOrEmpty(_langParamName))
            {
                _langParamName = "la";
            }

            _langs = WebConfigurationManager.AppSettings["SiteLanguages"]?.ToString();
            DefaultLanguage = WebConfigurationManager.AppSettings["DefaultLanguage"]?.ToString();
        }
        public static void Execute(HttpContextBase context = null, string manualLang = "")
        {
            var _context = context == null ? new HttpContextWrapper(HttpContext.Current) : context;
            var routeData = RouteTable.Routes.GetRouteData(_context);
            var lang = "";

            if (string.Compare(_langStatus, "disabled", true) == 0 || (_context.Items.Contains(_langItemName) && string.IsNullOrEmpty(manualLang)))
            {
                return;
            }

            if (string.IsNullOrEmpty(manualLang))
            {
                if (string.Compare(_langSource, "FormAndQuery", true) != 0)
                {
                    if (routeData != null && routeData.Values.ContainsKey(_langRouteArgName))
                    {
                        object value;

                        if (routeData.Values.TryGetValue(_langRouteArgName, out value))
                        {
                            lang = value?.ToString();
                        }
                    }
                    else
                    {
                        var url = _context.Request.Url.AbsolutePath;

                        if (!string.IsNullOrEmpty(url) && url != "/")
                        {
                            var slashIndex = url.IndexOf('/', 1);

                            if (slashIndex >= 0)
                            {
                                lang = url.Substring(1, slashIndex);

                                if (!lang.In(_langs))
                                {
                                    lang = "";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                lang = manualLang;
            }

            if (string.IsNullOrEmpty(lang))
            {
                lang = _context.Request[_langParamName];
            }

            if (string.IsNullOrEmpty(lang))
            {
                lang = DefaultLanguage;
            }

            _context.Items[_langItemName] = lang;
        }
    }
}
