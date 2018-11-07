using Locust.Configuration;
using Locust.WebExtensions;
using System;
using System.Web.Configuration;

namespace Locust.WebTools
{
    public static class ExternalClientSideItemType
    {
        public static string Resource = "rs";
        public static string DynamicFile = "df";
        public static string StaticFile = "sf";
        public static string RazorView = "rv";
        public static string DatabaseRecord = "dbr";
        public static bool Validate(string type)
        {
            return
                string.Compare(type, Resource, StringComparison.InvariantCultureIgnoreCase) == 0 ||
                string.Compare(type, DynamicFile, StringComparison.InvariantCultureIgnoreCase) == 0 ||
                string.Compare(type, StaticFile, StringComparison.InvariantCultureIgnoreCase) == 0 ||
                string.Compare(type, RazorView, StringComparison.InvariantCultureIgnoreCase) == 0 ||
                string.Compare(type, DatabaseRecord, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
    public static class WebConstants
    {
        public static string CSS_KEY => "Css";
        public static string JS_KEY => "Js";
        public static string CSS_PROCESSING_ACTION => "Css";
        public static string JS_PROCESSING_ACTION => "Js";
        public static string CSS_STATIC_RESOURCE_PATH_KEY => "CssPath";
        public static string JS_STATIC_RESOURCE_PATH_KEY => "JsPath";
        public static string CSS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY => "BaseResourceCssPath";
        public static string JS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY => "BaseResourceJsPath";
        public static string CSS_DYNAMIC_RESOURCE_PATH_KEY => "CssPath";
        public static string JS_DYNAMIC_RESOURCE_PATH_KEY => "JsPath";
        public static string CSS_DYNAMIC_RESOURCE_BASEPATH_KEY => "BaseCssPath";
        public static string JS_DYNAMIC_RESOURCE_BASEPATH_KEY => "BaseJsPath";
        public static string CSS_TYPE_KEY => "CssType";
        public static string JS_TYPE_KEY => "JsType";
        public static string CSS_EXTRA_ARGS_KEY => "CssExtraArgs";
        public static string JS_EXTRA_ARGS_KEY => "JsExtraArgs";
        public static string CSS_DEPENDENCIES_KEY => "CssDependencies";
        public static string JS_DEPENDENCIES_KEY => "JsDependencies";

        public static MultiLanguageRoutingOptions MultiLanguageRouting { get; set; }
        public static MultiLanguageRoutingOptions MultiLanguageAreas { get; set; }
        public static MultiLanguageRoutingOptions MultiLanguageClientAwareController { get; set; }
        public static bool SeparateClientSideResourcesByLanguage { get; set; }
        public static bool SeparateClientSideDynamicFilesByLanguage { get; set; }
        public static bool SeparateClientSideStaticFilesByLanguage { get; set; }
        public static bool SeparateClientSideRazorViewsByLanguage { get; set; }
        public static bool SeparateClientSideDatabaseRecordsByLanguage { get; set; }

        public static string CssStaticResourceDefaultBasePath { get; set; }
        public static string CssDynamicResourceDefaultBasePath { get; set; }
        public static string CssDynamicResourceResourceDefaultBasePath { get; set; }
        public static string JsStaticResourceDefaultBasePath { get; set; }
        public static string JsDynamicResourceDefaultBasePath { get; set; }
        public static string JsDynamicResourceResourceDefaultBasePath { get; set; }
        public static string MinifyCss { get; set; }
        public static string MinifyJs { get; set; }
        static WebConstants()
        {
            MultiLanguageRouting = ConfigHelper.AppSetting<MultiLanguageRoutingOptions>("MultiLanguageRoutingOption");
            MultiLanguageAreas = ConfigHelper.AppSetting<MultiLanguageRoutingOptions>("MultiLanguageAreasOption", MultiLanguageRouting);
            MultiLanguageClientAwareController = ConfigHelper.AppSetting<MultiLanguageRoutingOptions>("MultiLanguageClientAwareControllerOption", MultiLanguageRouting);

            SeparateClientSideResourcesByLanguage = ConfigHelper.AppSetting<bool>("SeparateClientSideResourcesByLanguage");
            SeparateClientSideDynamicFilesByLanguage = ConfigHelper.AppSetting<bool>("SeparateClientSideDynamicFilesByLanguage");
            SeparateClientSideStaticFilesByLanguage = ConfigHelper.AppSetting<bool>("SeparateClientSideStaticFilesByLanguage");
            SeparateClientSideRazorViewsByLanguage = ConfigHelper.AppSetting<bool>("SeparateClientSideRazorViewsByLanguage");
            SeparateClientSideDatabaseRecordsByLanguage = ConfigHelper.AppSetting<bool>("SeparateClientSideDatabaseRecordsByLanguage");

            CssStaticResourceDefaultBasePath = WebConfigurationManager.AppSettings[CSS_STATIC_RESOURCE_PATH_KEY]?.Trim();
            CssDynamicResourceDefaultBasePath = WebConfigurationManager.AppSettings[CSS_DYNAMIC_RESOURCE_BASEPATH_KEY]?.Trim();
            CssDynamicResourceResourceDefaultBasePath = WebConfigurationManager.AppSettings[CSS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY]?.Trim();
            JsStaticResourceDefaultBasePath = WebConfigurationManager.AppSettings[JS_STATIC_RESOURCE_PATH_KEY]?.Trim();
            JsDynamicResourceDefaultBasePath = WebConfigurationManager.AppSettings[JS_DYNAMIC_RESOURCE_BASEPATH_KEY]?.Trim();
            JsDynamicResourceResourceDefaultBasePath = WebConfigurationManager.AppSettings[JS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY]?.Trim();

            MinifyCss = WebConfigurationManager.AppSettings["MinifyCss"]?.Trim();
            MinifyJs = WebConfigurationManager.AppSettings["MinifyJs"]?.Trim();
        }
    }
}
