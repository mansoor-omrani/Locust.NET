using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Language;

namespace Locust.Measurement
{
    public static class MeasurementExtensions
    {
        public enum Word
        {
            And
        }
        public static string GetString(this Lang la, Word w)
        {
            var result = "";

            if (la is LangFa)
            {
                switch (w)
                {
                    case Word.And: result = "و"; break;
                    default: break;
                }
            }
            else
            {
                switch (w)
                {
                    case Word.And: result = "and"; break;
                    default: break;
                }
            }

            return result;
        }
        public static string GetString(this Lang la, List<TimeDurationValue> duration)
        {
            var result = "";

            foreach (var item in duration)
            {
                if (result == "")
                    result = la.Render(item.Value) + " " + la.GetString(item.Unit);
                else
                    result += " " + la.GetString(Word.And) + " " + la.Render(item.Value) + " " + la.GetString(item.Unit);
            }

            return result;
        }
        public static string GetString(this Lang la, TimeDurationUnit unit)
        {
            var result = "";

            if (la is LangFa)
            {
                switch (unit)
                {
                    case TimeDurationUnit.Second: result = "ثانیه"; break;
                    case TimeDurationUnit.Minute: result = "دقیقه"; break;
                    case TimeDurationUnit.Hour: result = "ساعت"; break;
                    default: result = ""; break;
                }
            }
            else
            {
                switch (unit)
                {
                    case TimeDurationUnit.Second: result = "second(s)"; break;
                    case TimeDurationUnit.Minute: result = "minute(s)"; break;
                    case TimeDurationUnit.Hour: result = "hour(s)"; break;
                    default: result = ""; break;
                }
            }

            return result;
        }
        public static string GetString(this Lang la, FileSizeUnit unit)
        {
            var result = "";

            if (la is LangFa)
            {
                switch (unit)
                {
                    case FileSizeUnit.Byte: result = "بایت"; break;
                    case FileSizeUnit.KiloByte: result = "کیلو بایت"; break;
                    case FileSizeUnit.MegaByte: result = "مگا بایت"; break;
                    case FileSizeUnit.GigaByte: result = "گیگا بایت"; break;
                    case FileSizeUnit.TeraByte: result = "ترا بایت"; break;
                    default: result = ""; break;
                }
            }
            else
            {
                switch (unit)
                {
                    case FileSizeUnit.Byte: result = "byte"; break;
                    case FileSizeUnit.KiloByte: result = "KB"; break;
                    case FileSizeUnit.MegaByte: result = "MB"; break;
                    case FileSizeUnit.GigaByte: result = "GB"; break;
                    case FileSizeUnit.TeraByte: result = "TB"; break;

                    default: result = ""; break;
                }
            }

            return result;
        }
    }
}
