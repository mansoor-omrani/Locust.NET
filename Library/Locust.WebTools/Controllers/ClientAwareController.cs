using Locust.AppSetting;
using Locust.Configuration;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Language;
using Locust.Logging;
using Locust.Service;
using Locust.Translation;
using Locust.WebExtensions;
using Locust.WebTools.Utilities;
using Newtonsoft.Json;
using NUglify;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace Locust.WebTools
{
    public abstract class ClientAwareControllerBase : MultiLanguageController
    {
        private string cfg_DigestExceptions;
        private string cfg_RevealExceptions;
        private IAppSettingsRead settings;
        private bool settingsInitialized;
        public virtual IAppSettingsRead Settings
        {
            get { return settings; }
            set
            {
                settings = value;
                ClientSideContentProvider.Settings = value;
            }
        }
        private IJavascriptObfuscator javascriptObfuscator;
        public IJavascriptObfuscator JavascriptObfuscator
        {
            get
            {
                if (javascriptObfuscator == null)
                    javascriptObfuscator = new ECMAScriptPacker(ECMAScriptPacker.PackerEncoding.Normal, fastDecode: true, specialChars: false);

                return javascriptObfuscator;
            }
            set { javascriptObfuscator = value; }
        }
        private ICssMinifier cssMinifier;
        public ICssMinifier CssMinifier
        {
            get
            {
                if (cssMinifier == null)
                    cssMinifier = new UglifyCssMinifier();

                return cssMinifier;
            }
            set { cssMinifier = value; }
        }
        private ClientSideContentControllerProvider clientSideContentProvider;
        private ILogger logger;
        protected virtual ILogger Logger
        {
            get
            {
                return logger;
            }
            set
            {
                logger = value;
                ClientSideContentProvider.Logger = value;
            }
        }
        private IExceptionLogger exceptionLogger;
        protected virtual IExceptionLogger ExceptionLogger
        {
            get
            {
                return exceptionLogger;
            }
            set
            {
                exceptionLogger = value;
                ClientSideContentProvider.ExceptionLogger = value;
            }
        }
        protected virtual ClientSideContentControllerProvider ClientSideContentProvider
        {
            get
            {
                if (clientSideContentProvider == null)
                {
                    clientSideContentProvider = new ClientSideContentControllerProvider(ControllerContext);
                }

                return clientSideContentProvider;
            }
        }
        private bool? revealExceptions;
        protected virtual bool RevealExceptions
        {
            get
            {
                if (revealExceptions.HasValue)
                    return revealExceptions.Value;

                InitSettings();

                return cfg_RevealExceptions == "true";
            }
            set { revealExceptions = value; }
        }
        private bool? digestExceptions;
        protected virtual bool DigestExceptions
        {
            get
            {
                if (digestExceptions.HasValue)
                    return digestExceptions.Value;

                InitSettings();

                return cfg_DigestExceptions == "true";
            }
            set { digestExceptions = value; }
        }
        /*
        protected virtual string GetViewPath(string area, string controller, string lang, string name, string extension)
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
        */
        protected virtual string GetContentFromView(string name, string extension)
        {
            var partial = Request.QueryString["par"] == "1";
            var path = ClientSideContentProvider.GetViewPath(ClientSideContentProvider.Area, ClientSideContentProvider.Controller, ClientSideContentProvider.Lang, name, extension);
            //var lang = "";
            //var ext = extension.Replace(".", "_") + ".";

            //if (!string.IsNullOrEmpty(ClientSideContentProvider.Area))
            //{
            //    if (WebConstants.SeparateClientSideStaticFilesByLanguage && (WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.Both || WebConstants.MultiLanguageClientAwareController == MultiLanguageRoutingOptions.OnlyLanguageBased)
            //                && !string.IsNullOrEmpty(ClientSideContentProvider.Lang))
            //    {
            //        lang = "." + ClientSideContentProvider.Lang;
            //    }

            //    path = $"~/Areas/{ClientSideContentProvider.Area}/Views/{ClientSideContentProvider.Controller}/{ext}{name}{lang}.cshtml";
            //}
            //else
            //{
            //    path = $"~/Views/{ClientSideContentProvider.Controller}/{ext}{name}{lang}.cshtml";
            //}

            Logger?.Log($"GetContentFromView: {path}");

            var result = this.RenderViewToString(path, null, partial);

            return result;
        }
        protected virtual void InitDynamicContent()
        { }
        protected virtual string GetBaseCssPath(string name)
        {
            return "";
        }
        protected virtual string GetBaseJsPath(string name)
        {
            return "";
        }
        protected virtual ActionResult HandleException(Exception e, string mime)
        {
            var result = "";

            ExceptionLogger?.LogException(e, Request.Url.AbsoluteUri);

            if (DigestExceptions)
            {
                if (RevealExceptions)
                {
                    result = $"/* {e.ToString("\n")}\n\n{e.StackTrace}*/";
                }
                else
                {
                    result = "/* error loading resource */";
                }

                return Content(result, mime);
            }

            return null;
        }
        protected virtual ActionResult GetContent(string name,
                                        string type,
                                        string mime,
                                        string extension,
                                        string dynamicResourceResourceBasePathKey,
                                        string dynamicResourceResourceDefaultBasePath,
                                        string dynamicResourcePathKey,
                                        string dynamicResourceDefaultBasePath,
                                        Func<string, string> minify)
        {
            var basePath = "";
            var result = "";
            var ok = true;

            InitDynamicContent();

            Logger?.LogCategory($"GetContent(): {nameof(name)} = {name},{nameof(type)} = {type}");
            Logger?.Log($@"Args({nameof(mime)}:{mime},
{nameof(extension)}:{extension},
{nameof(dynamicResourceResourceBasePathKey)}:{dynamicResourceResourceBasePathKey},
{nameof(dynamicResourceResourceDefaultBasePath)}:{dynamicResourceResourceDefaultBasePath},
{nameof(dynamicResourcePathKey)}:{dynamicResourcePathKey},
{nameof(dynamicResourceDefaultBasePath)}:{dynamicResourceDefaultBasePath})");

            if (ExternalClientSideItemType.Resource.EqualsTrimmedIgnoreCase(type))
            {
                try
                {
                    basePath = ClientSideContentProvider.GetResourceBasePath(dynamicResourceResourceBasePathKey, dynamicResourceResourceDefaultBasePath);
                    result = ClientSideContentProvider.GetResource(this, basePath, name, extension);
                }
                catch (Exception e)
                {
                    var r = HandleException(e, mime);

                    if (r != null)
                        return r;

                    if (RevealExceptions)
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, e.ToString("\n"));
                    else
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Reading file error");
                }
            }
            else
            if (ExternalClientSideItemType.DynamicFile.EqualsTrimmedIgnoreCase(type))
            {
                try
                {
                    switch (extension)
                    {
                        case ".css":
                            basePath = GetBaseCssPath(name);
                            break;
                        case ".js":
                            basePath = GetBaseJsPath(name);
                            break;
                    }

                    if (string.IsNullOrEmpty(basePath))
                    {
                        basePath = ClientSideContentProvider.GetDynamicFileBasePath(extension, dynamicResourcePathKey, dynamicResourceDefaultBasePath);
                    }

                    result = ClientSideContentProvider.GetFile(basePath, name, extension);
                }
                catch (HttpNotFoundException e)
                {
                    var r = HandleException(e, mime);

                    if (r != null)
                        return r;

                    if (RevealExceptions)
                        return HttpNotFound(e.ToString("\n"));
                    else
                        return HttpNotFound();
                }
                catch (Exception e)
                {
                    var r = HandleException(e, mime);

                    if (r != null)
                        return r;

                    if (RevealExceptions)
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, e.ToString("\n"));
                    else
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Reading file error");
                }
            }
            else
            if (ExternalClientSideItemType.RazorView.EqualsTrimmedIgnoreCase(type))
            {
                try
                {
                    result = GetContentFromView(name, extension);
                }
                catch (Exception e)
                {
                    var r = HandleException(e, mime);

                    if (r != null)
                        return r;

                    if (RevealExceptions)
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, e.ToString("\n"));
                    else
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Generating result error");
                }
            }
            else
            if (ExternalClientSideItemType.DatabaseRecord.EqualsTrimmedIgnoreCase(type))
            {
                Logger?.Log("DatabaseRecord resource are not supported yet");
                // not implemented yet
                ok = false;
            }
            else
            {
                Logger?.Log("invalid type");
                ok = false;
            }

            if (ok)
            {
                Logger?.Log($"result length:");
                Logger?.Log($"non-minified: {result.Length}");

                try
                {
                    result = minify(result);

                    Logger?.Log($"minified: {result.Length}");
                }
                catch (Exception e)
                {
                    ExceptionLogger.LogException(e, $"name: {name}, type: {type}, mime: {mime}");
                    Logger?.Log("Minification failed: refer to exception logs.");
                }
                
                return Content(result, mime);
            }

            Logger?.Log("FAILED: refer to exception logs.");

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Invalid type");
        }
        protected virtual async Task<ActionResult> GetContentAsync(string name,
                                                            string type,
                                                            string mime,
                                                            string extension,
                                                            string dynamicResourceResourceBasePathKey,
                                                            string dynamicResourceResourceDefaultBasePath,
                                                            string dynamicResourcePathKey,
                                                            string dynamicResourceDefaultBasePath,
                                                            Func<string, string> minify)
        {
            var basePath = "";
            var result = "";
            var ok = true;

            InitDynamicContent();

            Logger?.LogCategory($"GetContent(): {nameof(name)} = {name},{nameof(type)} = {type}");
            Logger?.Log($@"Args({nameof(mime)}:{mime},
{nameof(extension)}:{extension},
{nameof(dynamicResourceResourceBasePathKey)}:{dynamicResourceResourceBasePathKey},
{nameof(dynamicResourceResourceDefaultBasePath)}:{dynamicResourceResourceDefaultBasePath},
{nameof(dynamicResourcePathKey)}:{dynamicResourcePathKey},
{nameof(dynamicResourceDefaultBasePath)}:{dynamicResourceDefaultBasePath})");

            if (ExternalClientSideItemType.Resource.EqualsTrimmedIgnoreCase(type))
            {
                try
                {
                    basePath = ClientSideContentProvider.GetResourceBasePath(dynamicResourceResourceBasePathKey, dynamicResourceResourceDefaultBasePath);
                    result = await ClientSideContentProvider.GetResourceAsync(this, basePath, name, extension);
                }
                catch (Exception e)
                {
                    var r = HandleException(e, mime);

                    if (r != null)
                        return r;

                    if (RevealExceptions)
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, e.ToString("\n"));
                    else
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Reading file error");
                }
            }
            else
            if (ExternalClientSideItemType.DynamicFile.EqualsTrimmedIgnoreCase(type))
            {
                try
                {
                    switch (extension)
                    {
                        case ".css":
                            basePath = GetBaseCssPath(name);
                            break;
                        case ".js":
                            basePath = GetBaseJsPath(name);
                            break;
                    }

                    if (string.IsNullOrEmpty(basePath))
                    {
                        basePath = ClientSideContentProvider.GetDynamicFileBasePath(extension, dynamicResourcePathKey, dynamicResourceDefaultBasePath);
                    }

                    result = await ClientSideContentProvider.GetFileAsync(basePath, name, extension);
                }
                catch (HttpNotFoundException e)
                {
                    var r = HandleException(e, mime);

                    if (r != null)
                        return r;

                    if (RevealExceptions)
                        return HttpNotFound(e.ToString("\n"));
                    else
                        return HttpNotFound();
                }
                catch (Exception e)
                {
                    var r = HandleException(e, mime);

                    if (r != null)
                        return r;

                    if (RevealExceptions)
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, e.ToString("\n"));
                    else
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Reading file error");
                }
            }
            else
            if (ExternalClientSideItemType.RazorView.EqualsTrimmedIgnoreCase(type))
            {
                try
                {
                    result = GetContentFromView(name, extension);
                }
                catch (Exception e)
                {
                    var r = HandleException(e, mime);

                    if (r != null)
                        return r;

                    if (RevealExceptions)
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, e.ToString("\n"));
                    else
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Generating result error");
                }
            }
            else
            if (ExternalClientSideItemType.DatabaseRecord.EqualsTrimmedIgnoreCase(type))
            {
                Logger?.Log("DatabaseRecord resource are not supported yet");
                // not implemented yet
                ok = false;
            }
            else
            {
                Logger?.Log("invalid type");
                ok = false;
            }

            if (ok)
            {
                Logger?.Log($"result length:");
                Logger?.Log($"non-minified: {result.Length}");

                result = minify(result);

                Logger?.Log($"minified: {result.Length}");

                return Content(result, mime);
            }

            Logger?.Log("FAILED: refer to exception logs.");

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, "Invalid type");
        }
        public ClientAwareControllerBase()
        {
        }
        public ClientAwareControllerBase(ITranslator translator) : base(translator)
        {
        }
        private void InitSettings()
        {
            if (!settingsInitialized)
            {
                Settings = new ConfigAppSettings();

                cfg_DigestExceptions = Settings["ClientAwareController.DigestExceptions"];
                cfg_RevealExceptions = Settings["ClientAwareController.RevealExceptions"];

                settingsInitialized = true;
            }
        }
        protected virtual string RenderView(string viewPath, object model = null, bool partial = false)
        {
            return this.RenderViewToString(viewPath, model, partial);
        }
        protected virtual ActionResult JsonContent(object x)
        {
            var result = "null";

            if (x != null)
            {
                try
                {
                    result = JsonConvert.SerializeObject(x);
                }
                catch (Exception e)
                {
                    ExceptionLogger?.LogException(e, Request.Url.AbsoluteUri);

                    Logger?.LogCategory($"JsonContent(): Url = {Request.Url.AbsoluteUri}");
                    Logger?.Log($"Serializing {x.GetType().Name} Object failed. {e.Message}");

                    var sr = x as ServiceResponse;

                    if (sr != null)
                    {
                        if (sr.Exception != null)
                        {
                            Logger?.Log("Found a ServiceResponse instance. Clearing the Exception and try to serialize again.");

                            sr.Exception = null;

                            try
                            {
                                result = JsonConvert.SerializeObject(sr);
                            }
                            catch (Exception ex)
                            {
                                Logger?.Log($"Serialization failed again! {ex.Message}");

                                result = JsonConvert.SerializeObject(new ServiceResponse { Status = "SerializationFailed" });
                            }
                        }
                        else
                        {
                            result = JsonConvert.SerializeObject(new ServiceResponse { Status = "SerializationFailed" });
                        }
                    }
                }

            }

            return Content(result, "appliction/json");
        }
    }
    public abstract class ClientAwareController : ClientAwareControllerBase
    {
        [OutputCache(Location = OutputCacheLocation.Client, Duration = 31536000)]
        public virtual ActionResult Css(string name, string type)
        {
            var dynamicResourceResourceDefaultBasePath = WebConstants.CssDynamicResourceResourceDefaultBasePath;
            var dynamicResourceDefaultBasePath = WebConstants.CssDynamicResourceDefaultBasePath;

            if (string.IsNullOrEmpty(dynamicResourceResourceDefaultBasePath))
            {
                dynamicResourceResourceDefaultBasePath = "/css";
            }
            if (string.IsNullOrEmpty(dynamicResourceDefaultBasePath))
            {
                dynamicResourceDefaultBasePath = "/css/app";
            }

            return GetContent(name: name,
                                type: type,
                                mime: "text/css",
                                extension: ".css",
                                dynamicResourceResourceBasePathKey: WebConstants.CSS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY,
                                dynamicResourceResourceDefaultBasePath: dynamicResourceResourceDefaultBasePath,
                                dynamicResourcePathKey: WebConstants.CSS_DYNAMIC_RESOURCE_PATH_KEY,
                                dynamicResourceDefaultBasePath: dynamicResourceDefaultBasePath,
                                minify: (content) => ClientSideContentProvider.MinifyCss ? CssMinifier.Minify(content) : content);
        }
        [OutputCache(Location = OutputCacheLocation.Client, Duration = 31536000)]
        public virtual ActionResult Js(string name, string type)
        {
            var dynamicResourceResourceDefaultBasePath = WebConstants.JsDynamicResourceResourceDefaultBasePath;
            var dynamicResourceDefaultBasePath = WebConstants.JsDynamicResourceDefaultBasePath;

            if (string.IsNullOrEmpty(dynamicResourceResourceDefaultBasePath))
            {
                dynamicResourceResourceDefaultBasePath = "/js";
            }
            if (string.IsNullOrEmpty(dynamicResourceDefaultBasePath))
            {
                dynamicResourceDefaultBasePath = "/js/app";
            }

            return GetContent(name: name,
                                type: type,
                                mime: "application/javascript",
                                extension: ".js",
                                dynamicResourceResourceBasePathKey: WebConstants.JS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY,
                                dynamicResourceResourceDefaultBasePath: dynamicResourceResourceDefaultBasePath,
                                dynamicResourcePathKey: WebConstants.JS_DYNAMIC_RESOURCE_PATH_KEY,
                                dynamicResourceDefaultBasePath: dynamicResourceDefaultBasePath,
                                minify: (content) =>
                                {
                                    var result = content;

                                    if (ClientSideContentProvider.MinifyJs)
                                    {
                                        result = JavascriptObfuscator.Obfuscate(result);
                                    }

                                    return result;
                                });
        }
        public ClientAwareController(ITranslator translator) : base(translator)
        { }
        public ClientAwareController()
        { }
    }
    public abstract class ClientAwareAsyncController : ClientAwareControllerBase
    {
        [OutputCache(Location = OutputCacheLocation.Client, Duration = 31536000)]
        public virtual async Task<ActionResult> Css(string name, string type)
        {
            var dynamicResourceResourceDefaultBasePath = WebConstants.CssDynamicResourceResourceDefaultBasePath;
            var dynamicResourceDefaultBasePath = WebConstants.CssDynamicResourceDefaultBasePath;

            if (string.IsNullOrEmpty(dynamicResourceResourceDefaultBasePath))
            {
                dynamicResourceResourceDefaultBasePath = "/css";
            }
            if (string.IsNullOrEmpty(dynamicResourceDefaultBasePath))
            {
                dynamicResourceDefaultBasePath = "/css/app";
            }

            return await GetContentAsync(name: name,
                                type: type,
                                mime: "text/css",
                                extension: ".css",
                                dynamicResourceResourceBasePathKey: WebConstants.CSS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY,
                                dynamicResourceResourceDefaultBasePath: dynamicResourceResourceDefaultBasePath,
                                dynamicResourcePathKey: WebConstants.CSS_DYNAMIC_RESOURCE_PATH_KEY,
                                dynamicResourceDefaultBasePath: dynamicResourceDefaultBasePath,
                                minify: (content) => ClientSideContentProvider.MinifyCss ? CssMinifier.Minify(content) : content);
        }
        [OutputCache(Location = OutputCacheLocation.Client, Duration = 31536000)]
        public virtual async Task<ActionResult> Js(string name, string type)
        {
            var dynamicResourceResourceDefaultBasePath = WebConstants.JsDynamicResourceResourceDefaultBasePath;
            var dynamicResourceDefaultBasePath = WebConstants.JsDynamicResourceDefaultBasePath;

            if (string.IsNullOrEmpty(dynamicResourceResourceDefaultBasePath))
            {
                dynamicResourceResourceDefaultBasePath = "/js";
            }
            if (string.IsNullOrEmpty(dynamicResourceDefaultBasePath))
            {
                dynamicResourceDefaultBasePath = "/js/app";
            }

            return await GetContentAsync(name: name,
                                type: type,
                                mime: "application/javascript",
                                extension: ".js",
                                dynamicResourceResourceBasePathKey: WebConstants.JS_DYNAMIC_RESOURCE_RESOURCE_BASEPATH_KEY,
                                dynamicResourceResourceDefaultBasePath: dynamicResourceResourceDefaultBasePath,
                                dynamicResourcePathKey: WebConstants.JS_DYNAMIC_RESOURCE_PATH_KEY,
                                dynamicResourceDefaultBasePath: dynamicResourceDefaultBasePath,
                                minify: (content) =>
                                {
                                    var result = content;

                                    if (ClientSideContentProvider.MinifyJs)
                                    {
                                        result = JavascriptObfuscator.Obfuscate(result);
                                    }

                                    return result;
                                });
        }
        public ClientAwareAsyncController(ITranslator translator) : base(translator)
        { }
        public ClientAwareAsyncController()
        { }
    }
}
