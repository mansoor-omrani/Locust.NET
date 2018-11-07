using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Conversion;

namespace Locust.Language
{
    public class LangFa : Lang
    {
        public LangFa()
        {
            this.Type = LangType.fa;
            this.Name = "Farsi";
            this.Culture = "Persian";
            this.AltName = "Persian";
            this.LocalName = "فارسی";
            this.ShortName = "fa";
            this.DigitSeparator = '،';
            this.Direction = TextDirection.rtl;
            this.AltDirection = TextDirection.ltr;
            this.Align = TextAlign.right;
            this.AltAlign = TextAlign.left;
            this.Digits = new char[10] { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };
        }
        public override string Render(object text)
        {
            var result = "";

            foreach (var ch in SafeClrConvert.ToString(text))
            {
                if (Char.IsDigit(ch) && ((int)ch - 48) < 10)
                    //result += "&#" + (1632 + ((int)ch - 48)).ToString() + ";";
                    result += this.Digits[(int)ch - 48];
                else
                    result += ch;
            }

            return result;
        }
    }
}
