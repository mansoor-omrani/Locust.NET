using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Locust.WebExtensions
{
    public static class RouteExtensions
    {
        // source: https://forums.asp.net/t/1504480.aspx?Get+current+RouteName
        // with slight modifications (adding more extentions for other MapRoute() overloads
        public static Route MapRouteWithName(this RouteCollection routes, string name, string url)
        {
            Route route = routes.MapRoute(name, url: url);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this RouteCollection routes, string name, string url, object defaults)
        {
            Route route = routes.MapRoute(name, url: url, defaults: defaults);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            Route route = routes.MapRoute(name, url: url, namespaces: namespaces);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            Route route = routes.MapRoute(name, url: url, defaults: defaults, constraints: constraints);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            Route route = routes.MapRoute(name, url: url, defaults: defaults, namespaces: namespaces);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            Route route = routes.MapRoute(name, url: url, defaults: defaults, constraints: constraints, namespaces: namespaces);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this AreaRegistrationContext context, string name, string url)
        {
            Route route = context.MapRoute(name, url: url);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this AreaRegistrationContext context, string name, string url, object defaults)
        {
            Route route = context.MapRoute(name, url: url, defaults: defaults);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this AreaRegistrationContext context, string name, string url, string[] namespaces)
        {
            Route route = context.MapRoute(name, url: url, namespaces: namespaces);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this AreaRegistrationContext context, string name, string url, object defaults, object constraints)
        {
            Route route = context.MapRoute(name, url: url, defaults: defaults, constraints: constraints);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this AreaRegistrationContext context, string name, string url, object defaults, string[] namespaces)
        {
            Route route = context.MapRoute(name, url: url, defaults: defaults, namespaces: namespaces);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }
        public static Route MapRouteWithName(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            Route route = context.MapRoute(name, url: url, defaults: defaults, constraints: constraints, namespaces: namespaces);
            if (route.DataTokens == null)
            {
                route.DataTokens = new RouteValueDictionary();
            }
            route.DataTokens.Add("RouteName", name);
            return route;
        }

        // source: https://rimdev.io/get-current-route-name-from-aspnet-web-api-request/
        // with slight modification: add the extension for ControllerBase
        public static string GetCurrentRouteName(this ControllerBase controller)
        {
            object value;
            var dataTokens = controller.ControllerContext.RequestContext.RouteData.DataTokens;

            return dataTokens.TryGetValue("RouteName", out value)
                ? value?.ToString()
                : null;
        }
        public static string GetCurrentRouteName(this RouteValueDictionary dataTokens)
        {
            object value;
            
            return dataTokens.TryGetValue("RouteName", out value)
                ? value?.ToString()
                : null;
        }
    }
}
