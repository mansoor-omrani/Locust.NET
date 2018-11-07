using Locust.Extensions;
using Locust.WebExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Locust.WebTools
{
    public static class AreaRouteExtensions
    {
        public static Route RegisterRoutes(this AreaRegistrationContext context)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{{controller}}/{{action}}/{{id}}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() }
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default",
                    url: $"{context.AreaName}/{{controller}}/{{action}}/{{id}}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string url)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_u_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() }
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_u",
                    url: $"{context.AreaName}/{url}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string name, string url)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nu_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() }
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nu",
                    url: $"{context.AreaName}/{url}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string name, string url, object defaults)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                var _defaults = (new { lang = LangRouteConstraint.DefaultLanguage }).Extend(defaults);

                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nud_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: _defaults,
                    constraints: new { lang = new LangRouteConstraint() }
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nud",
                    url: $"{context.AreaName}/{url}",
                    defaults: defaults
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string url, object defaults)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                var _defaults = (new { lang = LangRouteConstraint.DefaultLanguage }).Extend(defaults);

                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_ud_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: _defaults,
                    constraints: new { lang = new LangRouteConstraint() }
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_ud",
                    url: $"{context.AreaName}/{url}",
                    defaults: defaults
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string name, string url, string[] namespaces)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nun_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: new { lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() },
                    namespaces: namespaces
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nun",
                    url: $"{context.AreaName}/{url}",
                    namespaces: namespaces
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string url, string[] namespaces)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_un_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: new { lang = LangRouteConstraint.DefaultLanguage },
                    constraints: new { lang = new LangRouteConstraint() },
                    namespaces: namespaces
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_un",
                    url: $"{context.AreaName}/{url}",
                    namespaces: namespaces
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string name, string url, object defaults, object constraints)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                var _defaults = (new { lang = LangRouteConstraint.DefaultLanguage }).Extend(defaults);
                var _constraints = (new { lang = new LangRouteConstraint() }).Extend(constraints);

                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nudc_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: _defaults,
                    constraints: _constraints
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nudc",
                    url: $"{context.AreaName}/{url}",
                    defaults: defaults,
                    constraints: constraints
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string url, object defaults, object constraints)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                var _defaults = (new { lang = LangRouteConstraint.DefaultLanguage }).Extend(defaults);
                var _constraints = (new { lang = new LangRouteConstraint() }).Extend(constraints);

                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_udc_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: _defaults,
                    constraints: _constraints
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_udc",
                    url: $"{context.AreaName}/{url}",
                    defaults: defaults,
                    constraints: constraints
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string name, string url, object defaults, string[] namespaces)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                var _defaults = (new { lang = LangRouteConstraint.DefaultLanguage }).Extend(defaults);

                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nudn_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: _defaults,
                    constraints: new
                    {
                        lang = new LangRouteConstraint()
                    },
                    namespaces: namespaces
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nudn",
                    url: $"{context.AreaName}/{url}",
                    defaults: defaults,
                    namespaces: namespaces
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string url, object defaults, string[] namespaces)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                var _defaults = (new { lang = LangRouteConstraint.DefaultLanguage }).Extend(defaults);

                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_udn_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: _defaults,
                    constraints: new
                    {
                        lang = new LangRouteConstraint()
                    },
                    namespaces: namespaces
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_udn",
                    url: $"{context.AreaName}/{url}",
                    defaults: defaults,
                    namespaces: namespaces
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                var _defaults = (new { lang = LangRouteConstraint.DefaultLanguage }).Extend(defaults);
                var _constraints = (new { lang = new LangRouteConstraint() }).Extend(constraints);

                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nudcn_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: _defaults,
                    constraints: _constraints,
                    namespaces: namespaces
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_{name}_nudcn",
                    url: $"{context.AreaName}/{url}",
                    defaults: defaults,
                    constraints: constraints,
                    namespaces: namespaces
                );
            }

            return route;
        }
        public static Route RegisterRoutes(this AreaRegistrationContext context, string url, object defaults, object constraints, string[] namespaces)
        {
            Route route = null;

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.OnlyLanguageBased)
            {
                var _defaults = (new { lang = LangRouteConstraint.DefaultLanguage }).Extend(defaults);
                var _constraints = (new { lang = new LangRouteConstraint() }).Extend(constraints);

                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_udcn_LangBased",
                    url: $"{{lang}}/{context.AreaName}/{url}",
                    defaults: _defaults,
                    constraints: _constraints,
                    namespaces: namespaces
                );
            }

            if (WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageAreas == MultiLanguageRoutingOptions.None)
            {
                route = context.MapRouteWithName(
                    name: $"{context.AreaName}_default_udcn",
                    url: $"{context.AreaName}/{url}",
                    defaults: defaults,
                    constraints: constraints,
                    namespaces: namespaces
                );
            }

            return route;
        }
    }
}
