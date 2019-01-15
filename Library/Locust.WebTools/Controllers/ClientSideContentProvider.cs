using Locust.AppSetting;
using Locust.Base;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Logging;
using Locust.WebExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Locust.WebTools
{
    public abstract class ClientSideContentBaseProvider
    {
        public string MasterDynamicPath { get; set; }
        public bool StaticsAreExternal { get; set; }
        public ILogger Logger { get; set; }
        public IExceptionLogger ExceptionLogger { get; set; }
        public IAppSettingsRead Settings { get; set; }
        public virtual string Lang
        {
            get
            {
                return HttpContext.Items["Lang"]?.ToString();
            }
        }
        public abstract string Area
        {
            get; protected set;
        }
        public abstract string Controller
        {
            get; protected set;
        }
        public virtual HttpContextBase HttpContext { get; set; }
        public virtual bool MinifyCss
        {
            get
            {
                var result = Settings[$"{Area}{Controller}MinifyCss"]?.Trim();

                if (string.IsNullOrEmpty(result))
                {
                    result = WebConstants.MinifyCss;

                    if (string.IsNullOrEmpty(result))
                    {
                        result = "true";
                    }
                }

                if (!result.In("true,false"))
                {
                    result = "true";
                }

                return SafeClrConvert.ToBoolean(result);
            }
        }
        public virtual bool MinifyJs
        {
            get
            {
                var result = Settings[$"{Area}{Controller}MinifyJs"]?.Trim();

                if (string.IsNullOrEmpty(result))
                {
                    result = WebConstants.MinifyJs;

                    if (string.IsNullOrEmpty(result))
                    {
                        result = "true";
                    }
                }

                if (!result.In("true,false"))
                {
                    result = "true";
                }

                return SafeClrConvert.ToBoolean(result);
            }
        }
        public ClientSideContentBaseProvider()
        {
            MasterDynamicPath = "/static";

            StaticsAreExternal = true;
            Settings = new ConfigAppSettings();
        }
        internal virtual string GetResource(object resourceLocator, string basePath, string name, string extension)
        {
            var result = "";
            var area = string.IsNullOrEmpty(Area) ? "" : Area + ".";
            var lang = "";

            if (WebConstants.SeparateClientSideResourcesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(Lang))
            {
                lang = Lang + ".";
            }

            var resource = basePath + "." + lang + area + Controller + "." + name + extension;

            if (resource[0] == '/')
            {
                resource = resource.Substring(1);
            }

            Logger?.Log($"GetResource: {resource}");

            result = resourceLocator.GetType().Assembly.GetResourceString(resource);

            Logger?.Log($"   result Length: {result.Length}");

            return result;
        }
        internal virtual async Task<string> GetResourceAsync(object resourceLocator, string basePath, string name, string extension)
        {
            var result = "";
            var area = string.IsNullOrEmpty(Area) ? "" : Area + ".";
            var lang = "";

            if (WebConstants.SeparateClientSideResourcesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(Lang))
            {
                lang = Lang + ".";
            }

            var resource = basePath + "." + lang + area + Controller + "." + name + extension;

            if (resource[0] == '/')
            {
                resource = resource.Substring(1);
            }

            Logger?.Log($"GetResourceAsync: {resource}");

            result = await resourceLocator.GetType().Assembly.GetResourceStringAsync(resource);

            Logger?.Log($"   result Length: {result.Length}");
            
            return result;
        }
        public virtual string GetViewPath(string area, string controller, string lang, string name, string extension)
        {
            var result = "";
            var _lang = "";
            var ext = extension.Replace(".", "_") + ".";

            if (!string.IsNullOrEmpty(area))
            {
                if (WebConstants.SeparateClientSideStaticFilesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(lang))
                {
                    _lang = "." + lang;
                }

                result = $"~/Areas/{area}/Views/{controller}/{ext}{name}{_lang}.cshtml";
            }
            else
            {
                result = $"~/Views/{controller}/{ext}{name}{_lang}.cshtml";
            }

            return result;
        }
        internal virtual string GetFile(string basePath, string name, string extension)
        {
            var area = Area;
            if (!string.IsNullOrEmpty(area))
            {
                area = area + "/";
            }
            var lang = "";
            if (WebConstants.SeparateClientSideDynamicFilesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(Lang))
            {
                lang = Lang + "/";
            }

            var path = "";
            if (StaticsAreExternal)
            {
                path = Path.Combine(HttpContext.Server.MapPath("\\"), ".." + MasterDynamicPath + basePath + "/" + lang + area + Controller + "/" + name + extension);
            }
            else
            {
                if (basePath.Length > 0 && basePath[0] == '/')
                    basePath = basePath.Substring(1);

                path = Path.Combine(HttpContext.Server.MapPath("\\"), basePath + "/" + lang + area + Controller + "/" + name + extension);
            }
            var result = "";

            Logger?.Log($"GetFile: \"{path}\"");

            if (System.IO.File.Exists(path))
            {
                result = System.IO.File.ReadAllText(path);

                Logger?.Log($"   result length: {result.Length}");

                return result;
            }
            else
            {
                Logger?.Log($"   NOT FOUND");

                throw new HttpNotFoundException("File not found: " + path);
            }
        }
        internal virtual async Task<string> GetFileAsync(string basePath, string name, string extension)
        {
            var area = Area;
            if (!string.IsNullOrEmpty(area))
            {
                area = area + "/";
            }
            var lang = "";
            if (WebConstants.SeparateClientSideDynamicFilesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(Lang))
            {
                lang = Lang + "/";
            }

            var path = "";
            if (StaticsAreExternal)
            {
                path = Path.Combine(HttpContext.Server.MapPath("\\"), ".." + MasterDynamicPath + basePath + "/" + lang + area + Controller + "/" + name + extension);
            }
            else
            {
                if (basePath.Length > 0 && basePath[0] == '/')
                    basePath = basePath.Substring(1);

                path = Path.Combine(HttpContext.Server.MapPath("\\"), basePath + "/" + lang + area + Controller + "/" + name + extension);
            }
            var result = "";

            Logger?.Log($"GetFileAsync: \"{path}\"");

            if (System.IO.File.Exists(path))
            {
                using (System.IO.TextReader reader = new System.IO.StreamReader(path))
                {
                    result = await reader.ReadToEndAsync();
                }

                Logger?.Log($"   result length: {result.Length}");

                return result;
            }
            else
            {
                Logger?.Log($"   NOT FOUND");

                throw new HttpNotFoundException("File not found: " + path);
            }
        }
        protected internal virtual string GetDynamicFileBasePath(string extension, string key, string defaultValue)
        {
            var basePath = Settings[$"{Area}{Controller}{key}"]?.Trim();

            if (string.IsNullOrEmpty(basePath))
            {
                // when WebConstants.CssDynamicResourceDefaultBasePath is empty, the default basepath is "/css/app" (look at Css() action in ClientAwareController/ClientAwareAsyncController.
                // We want to override this for Controllers in Areas to be "/css/{area}" like "/css/admin" (area is used in the basepath).
                // Since area will be used later in GetFile() we omit "/app" from default "/css/app" and return "/css".
                //
                // This is the same for .js files.

                if (extension == ".css" && string.IsNullOrEmpty(WebConstants.CssDynamicResourceDefaultBasePath) && !string.IsNullOrEmpty(Area))
                {
                    basePath = "/css";
                }
                else
                {
                    if (extension == ".js" && string.IsNullOrEmpty(WebConstants.JsDynamicResourceDefaultBasePath) && !string.IsNullOrEmpty(Area))
                    {
                        basePath = "/js";
                    }
                }
                
                if (string.IsNullOrEmpty(basePath))
                {
                    basePath = defaultValue;
                }
            }

            Logger?.Log($"GetDynamicFileBasePath: Args({nameof(extension)}: \"{extension}\", {nameof(key)}: \"{key}\", {nameof(defaultValue)}: \"{defaultValue}\")");
            Logger?.Log($"   result: \"{basePath}\"");

            return basePath;
        }
        protected internal virtual string GetResourceBasePath(string key, string defaultValue)
        {
            var basePath = SafeClrConvert.ToString(Settings[$"{key}"]);

            if (string.IsNullOrEmpty(basePath))
            {
                basePath = defaultValue;
            }

            Logger?.Log($"GetResourceBasePath: Args({nameof(key)}: \"{key}\", {nameof(defaultValue)}: \"{defaultValue}\")");
            Logger?.Log($"   result: \"{basePath}\"");

            return basePath;
        }
    }
    public class ClientSideContentControllerProvider: ClientSideContentBaseProvider
    {
        private bool _area_set;
        private string _area;
        public override string Area
        {
            get
            {
                if (!_area_set)
                {
                    _area = ControllerContext.RouteData.DataTokens["area"]?.ToLowerCase() ?? "";
                    _area_set = true;
                }

                return _area;
            }
            protected set { _area = value; }
        }
        private bool _controller_set;
        private string _controller;
        public override string Controller
        {
            get
            {
                if (!_controller_set)
                {
                    _controller = ControllerContext.RouteData.Values["controller"]?.ToLowerCase() ?? "";
                    _controller_set = true;
                }

                return _controller;
            }
            protected set { _controller = value; }
        }
        public ControllerContext ControllerContext { get; set; }
        public ClientSideContentControllerProvider(ControllerContext context)
        {
            ControllerContext = context;
            HttpContext = context.HttpContext;
        }
    }
    public class ClientSideContentViewProvider : ClientSideContentBaseProvider
    {
        private bool _area_set;
        private string _area;
        public override string Area
        {
            get
            {
                if (!_area_set)
                {
                    _area = Page.ViewContext.RouteData.DataTokens["area"]?.ToLowerCase() ?? "";
                    _area_set = true;
                }

                return _area;
            }
            protected set { _area = value; }
        }
        private bool _controller_set;
        private string _controller;
        public override string Controller
        {
            get
            {
                if (!_controller_set)
                {
                    _controller = Page.ViewContext.RouteData.Values["controller"]?.ToLowerCase() ?? "";
                    _controller_set = true;
                }

                return _controller;
            }
            protected set { _controller = value; }
        }
        private bool _action_set;
        private string _action;
        public virtual string Action
        {
            get
            {
                if (!_action_set)
                {
                    _action = Page.ViewContext.RouteData.Values["action"]?.ToLowerCase() ?? "";
                    _action_set = true;
                }

                return _action;
            }
            protected set { _action = value; }
        }
        public WebViewPage Page { get; set; }
        public ViewDataDictionary ViewData
        {
            get
            {
                return Page?.ViewData ?? new ViewDataDictionary();
            }
        }
        public ClientSideContentViewProvider(WebViewPage page)
        {
            Page = page;
            HttpContext = page.Context;
            hashProvider = new MD5HashProvider();
        }
        private IHashProvider hashProvider;
        protected IHashProvider HashProvider
        {
            get
            {
                if (hashProvider == null)
                {
                    hashProvider = ViewData["HashProvider"] as IHashProvider;
                }

                return hashProvider;
            }
            set
            {
                hashProvider = value;
            }
        }
        internal virtual string GetHash(string action,
                                        string type,
                                        string extension,
                                        string staticResourcePathKey,
                                        string staticResourceDefaultBasePath,
                                        string dynamicResourceResourceBasePathKey,
                                        string dynamicResourceResourceDefaultBasePath,
                                        string dynamicResourcePathKey,
                                        string dynamicResourceDefaultBasePath)
        {
            var result = "";

            if (HashProvider != null)
            {
                var basePath = "";
                var content = "";
                var path = "";
                var area = string.IsNullOrEmpty(Area) ? "" : Area + "/";
                var lang = "";

                Logger?.LogCategory($"GetHash()");
                
                if (ExternalClientSideItemType.Resource.EqualsTrimmedIgnoreCase(type))
                {
                    basePath = GetResourceBasePath(dynamicResourceResourceBasePathKey, dynamicResourceResourceDefaultBasePath);
                    content = GetResource(Page.ViewContext.Controller, basePath, action, extension);
                }
                else
                if (ExternalClientSideItemType.DynamicFile.EqualsTrimmedIgnoreCase(type))
                {
                    try
                    {
                        basePath = GetDynamicFileBasePath(extension, dynamicResourcePathKey, dynamicResourceDefaultBasePath);
                        content = GetFile(basePath, action, extension);
                    }
                    catch (Exception e)
                    {
                        Logger?.Log($"ERROR: {e.Message}");

                        ExceptionLogger?.LogException(e, $@"GetHash();DynamicFile: Args({nameof(action)}: ""{action}"",			
{nameof(type)}: ""{type}"",
{nameof(extension)}: ""{extension}"",
{nameof(staticResourcePathKey)}: ""{staticResourcePathKey}"",
{nameof(staticResourceDefaultBasePath)}: ""{staticResourceDefaultBasePath}"",
{nameof(dynamicResourceResourceBasePathKey)}: ""{dynamicResourceResourceBasePathKey}"",
{nameof(dynamicResourceResourceDefaultBasePath)}: ""{dynamicResourceResourceDefaultBasePath}"",
{nameof(dynamicResourcePathKey)}: ""{dynamicResourcePathKey}"",
{nameof(dynamicResourceDefaultBasePath)}: ""{dynamicResourceDefaultBasePath})");


                        return new Random().Next(99999).ToString();
                    }
                }
                else
                if (ExternalClientSideItemType.RazorView.EqualsTrimmedIgnoreCase(type))
                {
                    /*
                    if (WebConstants.SeparateClientSideStaticFilesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(Lang))
                    {
                        lang = "." + Lang;
                    }

                    if (!string.IsNullOrEmpty(Area))
                    {
                        path = "/Areas/" + Area + "/Views/" + Controller + "/" + action + lang + ".cshtml";
                    }
                    else
                    {
                        path = "/Views/" + Controller + "/" + action + lang + ".cshtml";
                    }
                    */
                    path = GetViewPath(Area, Controller, Lang, Action, extension);
                    path = path.Length > 1 ? path.Substr(2): "";
                    path = Path.Combine(HttpContext.Server.MapPath("\\"), path);

                    try
                    {
                        Logger?.Log($"Path = {path}");

                        content = File.ReadAllText(path);
                    }
                    catch (Exception e)
                    {
                        Logger?.Log($"ERROR: {e.Message}");

                        ExceptionLogger?.LogException(e, $@"GetHash();RazorView: Path = {path}"", Args({nameof(action)}: ""{action}"",			
{nameof(type)}: ""{type}"",
{nameof(extension)}: ""{extension}"",
{nameof(staticResourcePathKey)}: ""{staticResourcePathKey}"",
{nameof(staticResourceDefaultBasePath)}: ""{staticResourceDefaultBasePath}"",
{nameof(dynamicResourceResourceBasePathKey)}: ""{dynamicResourceResourceBasePathKey}"",
{nameof(dynamicResourceResourceDefaultBasePath)}: ""{dynamicResourceResourceDefaultBasePath}"",
{nameof(dynamicResourcePathKey)}: ""{dynamicResourcePathKey}"",
{nameof(dynamicResourceDefaultBasePath)}: ""{dynamicResourceDefaultBasePath})");

                        return new Random().Next(99999).ToString();
                    }
                }
                else
                if (string.IsNullOrEmpty(type) || ExternalClientSideItemType.StaticFile.EqualsTrimmedIgnoreCase(type))
                {
                    var staticPath = SafeClrConvert.ToString(ViewData[staticResourcePathKey]).ToTrimmedLowerCase();

                    if (string.IsNullOrEmpty(staticPath))
                    {
                        staticPath = staticResourceDefaultBasePath;
                    }

                    if (WebConstants.SeparateClientSideStaticFilesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(Lang))
                    {
                        lang = Lang + "/";
                    }

                    path = Path.Combine(HttpContext.Server.MapPath("\\"), $"{staticPath}/{lang}{area}{Controller}/{Action}{extension}");

                    try
                    {
                        Logger?.Log($"Path = {path}");

                        content = File.ReadAllText(path);
                    }
                    catch (Exception e)
                    {
                        Logger?.Log($"ERROR: {e.Message}");

                        ExceptionLogger?.LogException(e, $@"GetHash();StaticFile: Path = {path}"", Args({nameof(action)}: ""{action}"",			
{nameof(type)}: ""{type}"",
{nameof(extension)}: ""{extension}"",
{nameof(staticResourcePathKey)}: ""{staticResourcePathKey}"",
{nameof(staticResourceDefaultBasePath)}: ""{staticResourceDefaultBasePath}"",
{nameof(dynamicResourceResourceBasePathKey)}: ""{dynamicResourceResourceBasePathKey}"",
{nameof(dynamicResourceResourceDefaultBasePath)}: ""{dynamicResourceResourceDefaultBasePath}"",
{nameof(dynamicResourcePathKey)}: ""{dynamicResourcePathKey}"",
{nameof(dynamicResourceDefaultBasePath)}: ""{dynamicResourceDefaultBasePath})");

                        return new Random().Next(99999).ToString();
                    }
                }

                Logger?.Log($"content retrieved. Content Length = {content.Length}");

                result = HashProvider.GetHash(new HashContext { Data = content, BasePath = basePath });
            }

            return result;
        }
        private string GetArgs(string hash, string extraArgs)
        {
            var result = "";

            if (string.IsNullOrEmpty(extraArgs))
            {
                result = hash;
            }
            else
            {
                if (string.IsNullOrEmpty(hash))
                {
                    result = "?" + extraArgs;
                }
                else
                {
                    result = hash + "&" + extraArgs;
                }
            }

            if (!string.IsNullOrEmpty(result) && result[0] != '?')
            {
                result = '?' + result;
            }

            return result;
        }
        protected string GetPath(string processingAction,
                                string staticResourcePathKey,
                                string staticResourceDefaultBasePath,
                                string dynamicResourceResourceBasePathKey,
                                string dynamicResourceResourceDefaultBasePath,
                                string dynamicResourcePathKey,
                                string dynamicResourceDefaultBasePath,
                                string typeKey,
                                string extension,
                                string staticResourceExtraArgsKey,
                                string dynamicResourceExtraArgs)
        {
            var type = ViewData[typeKey]?.ToLowerCase();

            Logger?.LogCategory("GetPath(): ");
            Logger?.Log($@"Args(
        {nameof(type)}: ""{type}"",
        {nameof(extension)}: ""{extension}"",
        {nameof(staticResourcePathKey)}: ""{staticResourcePathKey}"",
        {nameof(staticResourceDefaultBasePath)}: ""{staticResourceDefaultBasePath}"",
        {nameof(dynamicResourceResourceBasePathKey)}: ""{dynamicResourceResourceBasePathKey}"",
        {nameof(dynamicResourceResourceDefaultBasePath)}: ""{dynamicResourceResourceDefaultBasePath}"",
        {nameof(dynamicResourcePathKey)}: ""{dynamicResourcePathKey}"",
        {nameof(dynamicResourceDefaultBasePath)}: ""{dynamicResourceDefaultBasePath})"",
        {nameof(staticResourceExtraArgsKey)}: ""{ staticResourceExtraArgsKey}"",
        {nameof(dynamicResourceExtraArgs)}: ""{ dynamicResourceExtraArgs})");

            if (!string.IsNullOrEmpty(type))
            {
                if (!ExternalClientSideItemType.Validate(type))
                {
                    throw new Exception($"invalid client side item type: {type}");
                }
            }

            var area = string.IsNullOrEmpty(Area) ? "" : Area + "/";
            var lang = "";
            var hash = GetHash( Action,
                                type,
                                extension,
                                staticResourcePathKey,
                                staticResourceDefaultBasePath,
                                dynamicResourceResourceBasePathKey,
                                dynamicResourceResourceDefaultBasePath,
                                dynamicResourcePathKey,
                                dynamicResourceDefaultBasePath);
            var args = "";
            var result = "";

            if (!string.IsNullOrEmpty(type) && type != ExternalClientSideItemType.StaticFile)
            {
                Logger?.Log("Not a static file");

                args = GetArgs(hash, dynamicResourceExtraArgs);
                lang = (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(Lang) ? Lang + "/" : "";

                if (!string.IsNullOrEmpty(type))
                {
                    type = "/" + type;
                }

                result = $"/{lang}{area}{Controller}{processingAction}/{Action}{type}{args}";
            }
            else
            {
                Logger?.Log("static file");

                var staticPath = SafeClrConvert.ToString(ViewData[staticResourcePathKey]).ToTrimmedLowerCase();

                if (string.IsNullOrEmpty(staticPath))
                {
                    staticPath = staticResourceDefaultBasePath;
                }

                if (WebConstants.SeparateClientSideStaticFilesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
                            && !string.IsNullOrEmpty(Lang))
                {
                    lang = Lang + "/";
                }

                var staticResourceExtraArgs = SafeClrConvert.ToString(ViewData[staticResourceExtraArgsKey]);

                args = GetArgs(hash, staticResourceExtraArgs);

                result = $"{staticPath}/{lang}{area}{Controller}/{Action}{extension}{args}";
            }

            Logger?.Log($"   result = \"{result}\"");

            return result;
        }
        public virtual string AddActionCss(string dynamicResourceExtraArgs = "")
        {
            Logger?.LogCategory("AddActionCss()");

            var result = "";
            var css = SafeClrConvert.ToString(ViewData[WebConstants.CSS_KEY]);
            var staticResourceDefaultBasePath = WebConstants.CssStaticResourceDefaultBasePath;
            var dynamicResourceResourceDefaultBasePath = WebConstants.CssDynamicResourceResourceDefaultBasePath;
            var dynamicResourceDefaultBasePath = WebConstants.CssDynamicResourceDefaultBasePath;

            if (string.IsNullOrEmpty(staticResourceDefaultBasePath))
            {
                staticResourceDefaultBasePath = "/css";
            }
            if (string.IsNullOrEmpty(dynamicResourceResourceDefaultBasePath))
            {
                dynamicResourceResourceDefaultBasePath = "/css";
            }
            if (string.IsNullOrEmpty(dynamicResourceDefaultBasePath))
            {
                dynamicResourceDefaultBasePath = "/css/app";
            }

            if (SafeClrConvert.ToBoolean(css))
            {
                result = GetPath(processingAction: "/" + WebConstants.CSS_PROCESSING_ACTION,
                                staticResourcePathKey: WebConstants.CSS_STATIC_RESOURCE_PATH_KEY,
                                staticResourceDefaultBasePath: staticResourceDefaultBasePath,
                                dynamicResourceResourceBasePathKey: WebConstants.CSS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY,
                                dynamicResourceResourceDefaultBasePath: dynamicResourceResourceDefaultBasePath,
                                dynamicResourcePathKey: WebConstants.CSS_DYNAMIC_RESOURCE_PATH_KEY,
                                dynamicResourceDefaultBasePath: dynamicResourceDefaultBasePath,
                                typeKey: WebConstants.CSS_TYPE_KEY,
                                extension: ".css",
                                staticResourceExtraArgsKey: WebConstants.CSS_EXTRA_ARGS_KEY,
                                dynamicResourceExtraArgs: dynamicResourceExtraArgs);
                result = $"<link rel=\"stylesheet\" type=\"text/css\" href=\"{result}\" />";
            }

            Logger?.Log($"   result: {result}");

            return result;
        }
        public virtual string AddActionJs(string dynamicResourceExtraArgs = "")
        {
            Logger?.LogCategory("AddActionJs()");

            var result = "";
            var js = SafeClrConvert.ToString(ViewData[WebConstants.JS_KEY]);
            var staticResourceDefaultBasePath = WebConstants.JsStaticResourceDefaultBasePath;
            var dynamicResourceResourceDefaultBasePath = WebConstants.JsDynamicResourceResourceDefaultBasePath;
            var dynamicResourceDefaultBasePath = WebConstants.JsDynamicResourceDefaultBasePath;

            if (string.IsNullOrEmpty(staticResourceDefaultBasePath))
            {
                staticResourceDefaultBasePath = "/js";
            }
            if (string.IsNullOrEmpty(dynamicResourceResourceDefaultBasePath))
            {
                dynamicResourceResourceDefaultBasePath = "/js";
            }
            if (string.IsNullOrEmpty(dynamicResourceDefaultBasePath))
            {
                dynamicResourceDefaultBasePath = "/js/app";
            }

            if (SafeClrConvert.ToBoolean(js))
            {
                result = GetPath(processingAction: "/" + WebConstants.JS_PROCESSING_ACTION,
                                staticResourcePathKey: WebConstants.JS_STATIC_RESOURCE_PATH_KEY,
                                staticResourceDefaultBasePath: staticResourceDefaultBasePath,
                                dynamicResourceResourceBasePathKey: WebConstants.JS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY,
                                dynamicResourceResourceDefaultBasePath: dynamicResourceResourceDefaultBasePath,
                                dynamicResourcePathKey: WebConstants.JS_DYNAMIC_RESOURCE_PATH_KEY,
                                dynamicResourceDefaultBasePath: dynamicResourceDefaultBasePath,
                                typeKey: WebConstants.JS_TYPE_KEY,
                                extension: ".js",
                                staticResourceExtraArgsKey: WebConstants.JS_EXTRA_ARGS_KEY,
                                dynamicResourceExtraArgs: dynamicResourceExtraArgs);

                result = $"<script type=\"text/javascript\" src=\"{result}\"></script>";
            }

            Logger?.Log($"   result: {result}");

            return result;
        }
        public virtual string AddActionCssDependencies()
        {
            Logger?.LogCategory("AddActionCssDependencies()");

            var result = "";

            Func<IEnumerable, string, string> iterate = (_x, _hash) =>
            {
                var _result = "";

                if (_x != null)
                {
                    var e = _x.GetEnumerator();
                    while (e.MoveNext())
                    {
                        _result += $"<link rel=\"stylesheet\" type=\"text/css\" href=\"{e.Current}{_hash}\" />\n";
                    }
                }

                return _result;
            };

            var cssLibs = ViewData[WebConstants.CSS_DEPENDENCIES_KEY];
            var hash = "";
            var x = null as IEnumerable;

            if (cssLibs != null)
            {
                do
                {
                    var type = cssLibs.GetType();

                    if (type == TypeHelper.TypeOfString)
                    {
                        x = cssLibs.ToString().Split(',', MyStringSplitOptions.TrimAndRemoveEmptyEntries);

                        break;
                    }

                    if (type == typeof(string[]))
                    {
                        x = cssLibs as string[];

                        break;
                    }

                    if (type == typeof(List<string>))
                    {
                        x = cssLibs as List<string>;

                        break;
                    }

                    break;
                } while (true);

                result = iterate(x, hash);
            }

            Logger?.Log($"result: {result}");

            return result;
        }
        public virtual string AddActionJsDependencies()
        {
            Logger?.LogCategory("AddActionJsDependencies()");

            var result = "";

            Func<IEnumerable, string, string> iterate = (_x, _hash) =>
            {
                var _result = "";
                if (_x != null)
                {
                    var e = _x.GetEnumerator();
                    while (e.MoveNext())
                    {
                        _result += $"<script type=\"text/javascript\" src=\"{e.Current}{_hash}\"></script>\n";
                    }
                }

                return _result;
            };

            var jsLibs = ViewData[WebConstants.JS_DEPENDENCIES_KEY];
            var hash = "";
            var x = null as IEnumerable;

            if (jsLibs != null)
            {
                do
                {
                    var type = jsLibs.GetType();

                    if (type == TypeHelper.TypeOfString)
                    {
                        x = jsLibs.ToString().Split(',', MyStringSplitOptions.TrimAndRemoveEmptyEntries);

                        break;
                    }

                    if (type == typeof(string[]))
                    {
                        x = jsLibs as string[];

                        break;
                    }

                    if (type == typeof(List<string>))
                    {
                        x = jsLibs as List<string>;

                        break;
                    }

                    break;
                } while (true);

                result = iterate(x, hash);
            }

            Logger?.Log($"result: {result}");

            return result;
        }
    }
}
