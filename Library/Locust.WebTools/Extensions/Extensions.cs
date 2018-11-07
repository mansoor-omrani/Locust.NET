using Locust.WebExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Locust.WebTools
{
    public enum MultiLanguageRoutingOptions
    {
        None,
        Both,
        OnlyLanguageBased
    }
    public static class Extensions
    {
        public static string Render(this FormSecurityItem item)
        {
            return string.Format("<input type=\"hidden\" name=\"{0}\" value=\"{1}\"/>", item.Name, item.Value);
        }
        public static string Render(this FormSecurityToken token)
        {
            return token.Value.Render() + token.Checksum.Render();
        }
        public static void RegisterClientAwareRoutes(this RouteCollection routes, params string[] namespaces)
        {
            if (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                routes.MapRouteWithName(
                    name: "ClientAwareController_Styles_Route_LangBased",
                    url: "{lang}/{controller}/" + Locust.WebTools.WebConstants.CSS_PROCESSING_ACTION + "/{name}/{type}",
                    defaults: new { action = "css", type = UrlParameter.Optional, lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() },
                    namespaces: namespaces
                );

                routes.MapRouteWithName(
                    name: "ClientAwareController_Javascript_Route_LangBased",
                    url: "{lang}/{controller}/" + Locust.WebTools.WebConstants.JS_PROCESSING_ACTION + "/{name}/{type}",
                    defaults: new { action = "js", type = UrlParameter.Optional, lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() },
                    namespaces: namespaces
                );
            }

            if (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.None)
            {
                routes.MapRouteWithName(
                    name: "ClientAwareController_Styles_Route",
                    url: "{controller}/" + Locust.WebTools.WebConstants.CSS_PROCESSING_ACTION + "/{name}/{type}",
                    defaults: new { action = "css", type = UrlParameter.Optional },
                    namespaces: namespaces
                );

                routes.MapRouteWithName(
                    name: "ClientAwareController_Javascript_Route",
                    url: "{controller}/" + Locust.WebTools.WebConstants.JS_PROCESSING_ACTION + "/{name}/{type}",
                    defaults: new { action = "js", type = UrlParameter.Optional },
                    namespaces: namespaces
                );
            }
        }
        public static void RegisterClientAwareRoutes(this AreaRegistrationContext context, params string[] namespaces)
        {
            if (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                context.MapRouteWithName(
                    name: $"{context.AreaName}_ClientAwareController_Styles_Route_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{{controller}}/{Locust.WebTools.WebConstants.CSS_PROCESSING_ACTION}/{{name}}/{{type}}",
                    defaults: new { action = "css", type = UrlParameter.Optional, lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() },
                    namespaces: namespaces
                );

                context.MapRouteWithName(
                    name: $"{context.AreaName}_ClientAwareController_Javascript_Route_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{{controller}}/{Locust.WebTools.WebConstants.JS_PROCESSING_ACTION}/{{name}}/{{type}}",
                    defaults: new { action = "js", type = UrlParameter.Optional, lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() },
                    namespaces: namespaces
                );
            }

            if (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.None)
            {
                context.MapRouteWithName(
                    name: $"{context.AreaName}_ClientAwareController_Styles_Route",
                    url: $"{context.AreaName}/{{controller}}/{Locust.WebTools.WebConstants.CSS_PROCESSING_ACTION}/{{name}}/{{type}}",
                    defaults: new { action = "css", type = UrlParameter.Optional },
                    namespaces: namespaces
                );

                context.MapRouteWithName(
                    name: $"{context.AreaName}_ClientAwareController_Javascript_Route",
                    url: $"{context.AreaName}/{{controller}}/{Locust.WebTools.WebConstants.JS_PROCESSING_ACTION}/{{name}}/{{type}}",
                    defaults: new { action = "js", type = UrlParameter.Optional },
                    namespaces: namespaces
                );
            }
        }
        public static string[] GetControllerNamespace(this AreaRegistration area, object namespacelocator = null)
        {
            var name = "";
            if (namespacelocator != null)
            {
                name = namespacelocator.GetType().FullName;
            }
            else
            {
                name = area.GetType().FullName;
            }
            var dotIndex = name.IndexOf(".");
            if (dotIndex > 0)
            {
                name = name.Substring(0, dotIndex);
            }

            var result = new string[] { $"{name}.Areas.{area.AreaName}.Controllers" };

            return result;
        }
        public static string[] GetControllerNamespace(this AreaRegistration area, string rootNamespace)
        {
            var result = new string[] { $"{rootNamespace}.Areas.{area.AreaName}.Controllers" };

            return result;
        }
        public static string[] GetNamespace(this AreaRegistration area, object namespacelocator = null)
        {
            var name = "";
            if (namespacelocator != null)
            {
                name = namespacelocator.GetType().FullName;
            }
            else
            {
                name = area.GetType().FullName;
            }
            var dotIndex = name.IndexOf(".");
            if (dotIndex > 0)
            {
                name = name.Substring(0, dotIndex);
            }
            var result = new string[] { $"{name}.Areas.{area.AreaName}.Controllers", $"{name}.Areas.{area.AreaName}.Models" };

            return result;
        }
        public static string[] GetNamespace(this AreaRegistration area, string rootNamespace)
        {
            var result = new string[] { $"{rootNamespace}.Areas.{area.AreaName}.Controllers", $"{rootNamespace}.Areas.{area.AreaName}.Models" };

            return result;
        }
    }
}
