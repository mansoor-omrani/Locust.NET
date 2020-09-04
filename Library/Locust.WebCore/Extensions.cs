using Locust.Conversion;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.WebCore
{
    public static class Extensions
    {
        static string hashNumber;
        static Extensions()
        {
            hashNumber = DateTime.Now.ToString("yyyyMMddhhmmss");
        }
        public static HtmlString ActionCss(ViewContext context)
        {
            var useActionCss = SafeClrConvert.ToBoolean(context.ViewData["UseActionCss"], true);

            if (useActionCss)
            {
                var area = context.RouteData.DataTokens["area"]?.ToString().ToLower();
                var controller = context.RouteData.Values["controller"]?.ToString().ToLower();
                var action = context.RouteData.Values["action"]?.ToString().ToLower();

                if (string.IsNullOrEmpty(area))
                {
                    area = "app";
                }

                return new HtmlString($"<link href=\"/css/{area}/{controller}/{action}.css?{hashNumber}\" rel=\"stylesheet\" type=\"text/css\" />");
            }

            return new HtmlString("");
        }
        public static HtmlString ActionJs(ViewContext context)
        {
            var useActionJs = SafeClrConvert.ToBoolean(context.ViewData["UseActionJs"], true);

            if (useActionJs)
            {
                var area = context.RouteData.DataTokens["area"]?.ToString().ToLower();
                var controller = context.RouteData.Values["controller"]?.ToString().ToLower();
                var action = context.RouteData.Values["action"]?.ToString().ToLower();

                if (string.IsNullOrEmpty(area))
                {
                    area = "app";
                }

                return new HtmlString($"<script src=\"/js/{area}/{controller}/{action}.js?{hashNumber}\"></script>");
            }

            return new HtmlString("");
        }
        public static HtmlString ActionCss(this RazorPageBase page)
        {
            return ActionCss(page.ViewContext);
        }
        public static HtmlString ActionJs(this RazorPageBase page)
        {
            return ActionJs(page.ViewContext);
        }
    }
}
