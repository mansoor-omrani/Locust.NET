using Locust.Expressions;
using Locust.Extensions;
using Locust.Language;
using Locust.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Translation
{
    public static class TranslationExtensions
    {
        public static string GetCultureDependentTextByEnumValue(this ITranslator translator, Type enumType, object n, string culture, Lang lang)
        {
            var result = "";
            var x = EnumHelper.ToEnum(enumType, n, true);

            if (x != null)
            {
                result = translator.GetSingle(enumType.Name, x.ToString(), culture, lang.ShortName);
            }

            return result;
        }
        public static string GetCultureDependentTextByEnumValue<T>(this ITranslator translator, object n, string culture, Lang lang) where T:struct
        {
            return translator.GetCultureDependentTextByEnumValue(enumType: typeof(T), n: n, culture: culture, lang: lang);
        }
        public static string GetNthNumber(this ITranslator translator, Lang lang, int n)
        {
            return translator.GetSingle("nth-num", n.ToString(), lang.ShortName);
        }
        public static string GetNumber(this ITranslator translator, Lang lang, int n)
        {
            return translator.GetSingle("number", n.ToString(), lang.ShortName);
        }
        public static string GetNthNumber(this ITranslator translator, string lang, int n)
        {
            return translator.GetNthNumber(Lang.Get(lang), n);
        }
        public static string GetNumber(this ITranslator translator, string lang, int n)
        {
            return translator.GetNumber(Lang.Get(lang), n);
        }
        public static void Translate(this ITranslator translator, ServiceResponse response, string lang, bool recursive = false, string defaultMessageKey = "")
        {
            if (response != null)
            {
                if (string.IsNullOrEmpty(response.Message))
                {
                    response.Message = translator.GetSingle(response.MessageKey, response.Status, lang);

                    if (!string.IsNullOrEmpty(response.Message) && response.HasMessageArgs())
                    {
                        foreach (var arg in response.MessageArgs)
                        {
                            response.Message = response.Message.Replace($"{{{arg.Key}}}", arg.Value?.ToString());
                        }
                    }

                    if (recursive && response.HasInnerResponses())
                    {
                        foreach (var res in response.InnerResponses)
                        {
                            if (string.IsNullOrEmpty(res.Value.MessageKey))
                            {
                                if (string.IsNullOrEmpty(defaultMessageKey))
                                {
                                    res.Value.MessageKey = response.MessageKey;
                                }
                                else
                                {
                                    res.Value.MessageKey = defaultMessageKey;
                                }
                            }

                            translator.Translate(res.Value, lang);
                        }
                    }
                }
            }
        }
    }
}
