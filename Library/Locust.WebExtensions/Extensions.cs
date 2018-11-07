using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Locust.WebExtensions
{
    public static class Extensions
    {
        public static string ChangeLanguage(this Uri uri, string lang)
        {
            var result = uri.PathAndQuery;
            var supportedLangs = WebConfigurationManager.AppSettings["SiteLanguages"]?.Trim();
            var _url = result;

            if (_url.Length > 0)
            {
                if (_url[0] == '/')
                {
                    _url = _url.Substring(1);
                }

                if (!string.IsNullOrEmpty(_url))
                {
                    var first = "";
                    var slashindex = _url.IndexOf('/');
                    if (slashindex >= 0)
                    {
                        first = _url.Substring(0, slashindex);
                    }
                    else
                    {
                        first = _url;
                    }

                    if (first.In(supportedLangs) && lang.In(supportedLangs) && string.Compare(first, lang, true) != 0)
                    {
                        result = "/" + lang;

                        if (slashindex > 0)
                        {
                            result += _url.Substring(slashindex);
                        }
                    }
                }
                else
                {
                    if (lang.In(supportedLangs))
                    {
                        result = "/" + lang;
                    }
                }
            }
            else
            {
                if (lang.In(supportedLangs))
                {
                    result = "/" + lang;
                }
            }

            return result;
        }
    }
}
