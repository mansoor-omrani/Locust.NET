using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Language
{
    public enum TextAlign
    {
        Unspecified, left, right, center, justified
    }
    public enum TextDirection
    {
        Unspecified, rtl, ltr
    }
    public enum LangType
    {
        Unknown, fa, en
    }
    public abstract class Lang
    {
        public LangType Type { get; protected set; }
        public char DigitSeparator { get; protected set; }
        public string Name { get; protected set; }
        public string Culture { get; protected set; }
        public string LocalName { get; protected set; }
        public string AltName { get; protected set; }
        public string ShortName { get; protected set; }
        public TextDirection Direction { get; protected set; }
        public TextDirection AltDirection { get; protected set; }
        public TextAlign Align { get; protected set; }
        public TextAlign AltAlign { get; protected set; }
        public char[] Digits { get; protected set; }
        public abstract string Render(object text);
        private static readonly LangFa _fa;
        public static LangFa Fa
        {
            get
            {
                return _fa;
            }
        }

        private static readonly LangEn _en;
        public static LangEn En
        {
            get
            {
                return _en;
            }
        }
        public static Lang Get(string shortname)
        {
            Lang result = null;

            if (string.Compare(shortname, _fa.ShortName, StringComparison.CurrentCultureIgnoreCase) == 0)
                result = _fa;
            else
            if (string.Compare(shortname, _en.ShortName, StringComparison.CurrentCultureIgnoreCase) == 0)
                result = _en;
            else
            if (string.Compare(shortname, _fa.Name, StringComparison.CurrentCultureIgnoreCase) == 0)
                result = _fa;
            else
            if (string.Compare(shortname, _en.Name, StringComparison.CurrentCultureIgnoreCase) == 0)
                result = _en;

            return result;
        }
        public static List<Lang> GetMany(params string[] shortnames)
        {
            var result = new List<Lang>();
            
            foreach (var la in shortnames)
            {
                var lang = Lang.Get(la);

                if (lang != null)
                {
                    result.Add(lang);
                }
            }

            return result;
        }
        public static Lang Get(LangType type)
        {
            Lang result;

            if (type == LangType.fa)
                result = _fa;
            if (type == LangType.en)
                result = _en;

            throw new ApplicationException("language not supported");
        }
        private static readonly List<Lang> _langs;
        static Lang()
        {
            _fa = new LangFa();
            _en = new LangEn();

            _langs = new List<Lang>();

            _langs.Add(_fa);
            _langs.Add(_en);

            Default = _en;
        }
        public static List<Lang> GetAll()
        {
            return _langs;
        }
        public static Lang Default { get;set; }
    }
}
