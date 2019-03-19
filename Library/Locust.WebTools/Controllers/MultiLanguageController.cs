using Locust.Extensions;
using Locust.Language;
using Locust.Translation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.WebTools
{
    public abstract class MultiLanguageController: Controller
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
                    var lang = HttpContext?.Items["Lang"]?.ToString();

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
        private static Lazy<ITranslator> _static_translator = new Lazy<ITranslator>(() =>
        {
            var result = new HybridTranslator();

            result.Load();

            return result;
        });
        private ITranslator _translator;
        public virtual ITranslator Translator
        {
            get
            {
                if (_translator == null)
                {
                    _translator = ViewData["Translator"] as ITranslator;

                    if (_translator == null)
                    {
                        _translator = _static_translator.Value;
                    }
                }

                return _translator;
            }
            set { _translator = value; }
        }
        private bool _area_set;
        private string _area;
        public virtual string Area
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
        public MultiLanguageController() { }
        public MultiLanguageController(ITranslator translator)
        {
            _translator = translator;
        }
        public virtual string GetText(string key, string value)
        {
            return Translator?.GetSingle(key, value, Lang.ShortName);
        }
        public string GetText(string key, string globalValue, string culture)
        {
            return Translator?.GetSingle(key, globalValue, culture, Lang.ShortName);
        }
        public virtual string Localize(string url)
        {
            return "/" + Lang.ShortName + url;
        }
        protected virtual ActionResult RedirectToLocal(string returnUrl, string action = "", string controller = "", string defaultUrl = "")
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = defaultUrl;
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
            }

            if (!string.IsNullOrEmpty(action))
            {
                if (string.IsNullOrEmpty(controller))
                {
                    return RedirectToAction(action);
                }
                else
                {
                    return RedirectToAction(action, controller);
                }
            }

            if (!string.IsNullOrEmpty(defaultUrl))
            {
                if (Url.IsLocalUrl(defaultUrl))
                {
                    return Redirect(defaultUrl);
                }
            }

            return Redirect("/");
        }
    }
}
