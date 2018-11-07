using Locust.Base;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Language;
using Locust.Logging;
using Locust.Translation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Locust.WebTools
{
    public abstract class ClientAwareWebViewPage: WebViewPage
    {
        private Lang _defaultLang;
        public Lang DefaultLang
        {
            get
            {
                if (_defaultLang == null)
                {
                    var _lang = ConfigurationManager.AppSettings["DefaultLanguage"];
                    _defaultLang = Lang.Get(_lang);

                    if (_defaultLang == null)
                        _defaultLang = Lang.En;
                }

                return _defaultLang;
            }
        }
        private Lang _lang;
        public virtual Lang Lang
        {
            get
            {
                if (_lang == null)
                {
                    var lang = ViewContext?.HttpContext?.Items["Lang"]?.ToString();

                    if (string.IsNullOrEmpty(lang))
                    {
                        lang = (ViewContext?.ViewData["Lang"] as Lang)?.ShortName;
                    }

                    if (!string.IsNullOrEmpty(lang))
                    {
                        _lang = Lang.Get(lang);
                    }

                    if (_lang == null)
                    {
                        _lang = DefaultLang;
                    }
                }

                return _lang;
            }
            set { _lang = value; }
        }
        private static Lazy<ITranslator> _static_translator = new Lazy<ITranslator>(() => { var result = new HybridTranslator(); result.Load(); return result; });
        private ILogger logger;
        protected virtual ILogger Logger
        {
            get
            {
                if (logger == null)
                    logger = new NullLogger();

                return logger;
            }
            set { logger = value; clientSideContentProvider.Logger = value; }
        }
        private IExceptionLogger exceptionLogger;
        protected virtual IExceptionLogger ExceptionLogger
        {
            get
            {
                if (exceptionLogger == null)
                    exceptionLogger = new NullExceptionLogger();

                return exceptionLogger;
            }
            set { exceptionLogger = value; clientSideContentProvider.ExceptionLogger = value; }
        }
        private ITranslator _translator;
        public virtual ITranslator Translator
        {
            get
            {
                if (_translator == null)
                {
                    var cac = ViewContext?.Controller as ClientAwareControllerBase;

                    if (cac != null)
                    {
                        _translator = cac.Translator;
                    }

                    if (_translator == null)
                    {
                        _translator = ViewData["Translator"] as ITranslator;
                    }

                    if (_translator == null)
                    {
                        Logger.Log("No Translator. Falling back to default translator");

                        _translator = _static_translator.Value;
                    }
                }

                return _translator;
            }
            set { _translator = value; }
        }
        public virtual string GetText(string key, string value)
        {
            return Translator.GetSingle(key, value, Lang.ShortName);
        }
        public virtual string GetText(string key, string globalValue, string culture)
        {
            return Translator.GetSingle(key, globalValue, culture, Lang.ShortName);
        }
        public virtual string Localize(string url)
        {
            return "/" + Lang.ShortName + url;
        }
        private ClientSideContentViewProvider clientSideContentProvider;
        protected virtual ClientSideContentViewProvider ClientSideContentProvider
        {
            get
            {
                if (clientSideContentProvider == null)
                {
                    clientSideContentProvider = new ClientSideContentViewProvider(this);
                    clientSideContentProvider.Logger = Logger;
                    clientSideContentProvider.ExceptionLogger = ExceptionLogger;
                }

                return clientSideContentProvider;
            }
        }
        protected virtual void BeforeAddAction(string type, string dynamicResourceExtraArgs)
        {
        }
        protected virtual string AfterAddAction(string type, string dynamicResourceExtraArgs, string result)
        {
            return result;
        }
        protected virtual void BeforeAddActionDependencies(string type)
        {
        }
        protected virtual string AfterAddActionDependencies(string type, string result)
        {
            return result;
        }
        public virtual MvcHtmlString AddActionCss(string dynamicResourceExtraArgs = "")
        {
            BeforeAddAction("Css", dynamicResourceExtraArgs);

            var result = ClientSideContentProvider.AddActionCss(dynamicResourceExtraArgs);

            result = AfterAddAction("Css", dynamicResourceExtraArgs, result);

            return new MvcHtmlString(result);
        }
        public virtual MvcHtmlString AddActionJs(string dynamicResourceExtraArgs = "")
        {
            BeforeAddAction("Js", dynamicResourceExtraArgs);

            var result = ClientSideContentProvider.AddActionJs(dynamicResourceExtraArgs);

            result = AfterAddAction("Js", dynamicResourceExtraArgs, result);

            return new MvcHtmlString(result);
        }
        public virtual MvcHtmlString AddActionCssDependencies()
        {
            BeforeAddActionDependencies("Css");

            var result = ClientSideContentProvider.AddActionCssDependencies();

            result = AfterAddActionDependencies("Css", result);

            return new MvcHtmlString(result);
        }
        public virtual MvcHtmlString AddActionJsDependencies()
        {
            BeforeAddActionDependencies("Js");

            var result = ClientSideContentProvider.AddActionJsDependencies();

            result = AfterAddActionDependencies("Js", result);

            return new MvcHtmlString(result);
        }
        public override void InitHelpers()
        {
            var lang = ViewContext?.HttpContext?.Items["Lang"]?.ToString();

            if (string.IsNullOrEmpty(lang))
            {
                lang = (ViewContext?.ViewData["Lang"] as Lang)?.ShortName;

                if (!string.IsNullOrEmpty(lang))
                {
                    ViewContext.HttpContext.Items["Lang"] = _lang;
                }
            }
            
            base.InitHelpers();
        }
    }
    public abstract class ClientAwareWebViewPage<T>: WebViewPage<T>
    {
        private Lang _defaultLang;
        public Lang DefaultLang
        {
            get
            {
                if (_defaultLang == null)
                {
                    var _lang = ConfigurationManager.AppSettings["DefaultLanguage"];
                    _defaultLang = Lang.Get(_lang);

                    if (_defaultLang == null)
                        _defaultLang = Lang.En;
                }

                return _defaultLang;
            }
        }
        private Lang _lang;
        public virtual Lang Lang
        {
            get
            {
                if (_lang == null)
                {
                    var lang = ViewContext?.HttpContext?.Items["Lang"]?.ToString();

                    _lang = Lang.Get(lang);

                    if (_lang == null)
                    {
                        _lang = DefaultLang;
                    }
                }

                return _lang;
            }
            set { _lang = value; }
        }
        private static Lazy<ITranslator> _static_translator = new Lazy<ITranslator>(() => { var result = new HybridTranslator(); result.Load(); return result; });
        private ILogger logger;
        protected virtual ILogger Logger
        {
            get
            {
                if (logger == null)
                    logger = new NullLogger();

                return logger;
            }
            set { logger = value; clientSideContentProvider.Logger = value; }
        }
        private IExceptionLogger exceptionLogger;
        protected virtual IExceptionLogger ExceptionLogger
        {
            get
            {
                if (exceptionLogger == null)
                    exceptionLogger = new NullExceptionLogger();

                return exceptionLogger;
            }
            set { exceptionLogger = value; clientSideContentProvider.ExceptionLogger = value; }
        }
        private ITranslator _translator;
        public virtual ITranslator Translator
        {
            get
            {
                if (_translator == null)
                {
                    var cac = ViewContext?.Controller as ClientAwareControllerBase;

                    if (cac != null)
                    {
                        _translator = cac.Translator;
                    }

                    if (_translator == null)
                    {
                        _translator = ViewData["Translator"] as ITranslator;
                    }

                    if (_translator == null)
                    {
                        Logger.Log("No Translator. Falling back to default translator");

                        _translator = _static_translator.Value;
                    }
                }

                return _translator;
            }
            set { _translator = value; }
        }
        public virtual string GetText(string key, string value)
        {
            return Translator.GetSingle(key, value, Lang.ShortName);
        }
        public virtual string GetText(string key, string globalValue, string culture)
        {
            return Translator.GetSingle(key, globalValue, culture, Lang.ShortName);
        }
        public virtual string Localize(string url)
        {
            return "/" + Lang.ShortName + url;
        }
        private ClientSideContentViewProvider clientSideContentProvider;
        protected virtual ClientSideContentViewProvider ClientSideContentProvider
        {
            get
            {
                if (clientSideContentProvider == null)
                {
                    clientSideContentProvider = new ClientSideContentViewProvider(this);
                    clientSideContentProvider.Logger = Logger;
                    clientSideContentProvider.ExceptionLogger = ExceptionLogger;
                }

                return clientSideContentProvider;
            }
        }
        protected virtual void BeforeAddAction(string type, string dynamicResourceExtraArgs)
        {
        }
        protected virtual string AfterAddAction(string type, string dynamicResourceExtraArgs, string result)
        {
            return result;
        }
        protected virtual void BeforeAddActionDependencies(string type)
        {
        }
        protected virtual string AfterAddActionDependencies(string type, string result)
        {
            return result;
        }
        public virtual MvcHtmlString AddActionCss(string dynamicResourceExtraArgs = "")
        {
            BeforeAddAction("Css", dynamicResourceExtraArgs);

            var result = ClientSideContentProvider.AddActionCss(dynamicResourceExtraArgs);

            result = AfterAddAction("Css", dynamicResourceExtraArgs, result);

            return new MvcHtmlString(result);
        }
        public virtual MvcHtmlString AddActionJs(string dynamicResourceExtraArgs = "")
        {
            BeforeAddAction("Js", dynamicResourceExtraArgs);

            var result = ClientSideContentProvider.AddActionJs(dynamicResourceExtraArgs);

            result = AfterAddAction("Js", dynamicResourceExtraArgs, result);

            return new MvcHtmlString(result);
        }
        public virtual MvcHtmlString AddActionCssDependencies()
        {
            BeforeAddActionDependencies("Css");

            var result = ClientSideContentProvider.AddActionCssDependencies();

            result = AfterAddActionDependencies("Css", result);

            return new MvcHtmlString(result);
        }
        public virtual MvcHtmlString AddActionJsDependencies()
        {
            BeforeAddActionDependencies("Js");

            var result = ClientSideContentProvider.AddActionJsDependencies();

            result = AfterAddActionDependencies("Js", result);

            return new MvcHtmlString(result);
        }
        public override void InitHelpers()
        {
            var lang = ViewContext?.HttpContext?.Items["Lang"]?.ToString();

            if (string.IsNullOrEmpty(lang))
            {
                lang = (ViewContext?.ViewData["Lang"] as Lang)?.ShortName;

                if (!string.IsNullOrEmpty(lang))
                {
                    ViewContext.HttpContext.Items["Lang"] = _lang;
                }
            }

            base.InitHelpers();
        }
    }
}
