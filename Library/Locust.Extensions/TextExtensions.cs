using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class TextExtensions
    {
        public static void AppendIf(this StringBuilder builder, string text, bool condition)
        {
            if (condition)
            {
                builder.Append(text);
            }
        }
        public static void AppendIfNotEmpty(this StringBuilder builder, string text)
        {
            builder.AppendIf(text, !string.IsNullOrEmpty(text));
        }
        public static void AppendFormatIf(this StringBuilder builder, string format, bool condition, params  object[] args)
        {
            if (condition)
            {
                builder.AppendFormat(format, args);
            }
        }
        public static void AppendFormatIfNotEmpty(this StringBuilder builder, string format, params object[] args)
        {
            var value = string.Format(format, args);

            if (!string.IsNullOrEmpty(value))
            {
                builder.Append(value);
            }
        }
        public static void AppendWith(this StringBuilder builder, string text, string separator)
        {
            builder.Append((builder.Length > 0 ? separator : "") + text);
        }
        public static void AppendWithComma(this StringBuilder builder, string text)
        {
            builder.AppendWith(text, ",");
        }
        public static void AppendWithIf(this StringBuilder builder, string text, string separator, bool condition)
        {
            if (condition)
            {
                builder.AppendWith(text, separator);
            }
        }
        public static void AppendWithCommaIf(this StringBuilder builder, string text, bool condition)
        {
            builder.AppendWithIf(text, ",", condition);
        }
        public static void AppendWithIfNotEmpty(this StringBuilder builder, string text, string separator)
        {
            builder.AppendWithIf(text, separator, !string.IsNullOrEmpty(text));
        }
        public static void AppendWithCommaIfNotEmpty(this StringBuilder builder, string text)
        {
            builder.AppendWithIfNotEmpty(text, ",");
        }
        public static void AppendFormatWith(this StringBuilder builder, string format, string separator, params object[] args)
        {
            builder.AppendFormat((builder.Length > 0 ? separator : "") + format, args);
        }
        public static void AppendFormatWithIf(this StringBuilder builder, string format, string separator, bool condition, params object[] args)
        {
            if (condition)
            {
                builder.AppendFormatWith(format, separator, args);
            }
        }
        public static void AppendFormatWithCommaIf(this StringBuilder builder, string format, bool condition, params object[] args)
        {
            builder.AppendFormatWithIf(format, ",", condition, args);
        }
        public static void AppendFormatWithComma(this StringBuilder builder, string format, params object[] args)
        {
            builder.AppendFormatWith(format, ",", args);
        }
        public static void AppendFormatWithIfNotEmpty(this StringBuilder builder, string format, string separator, params object[] args)
        {
            var value = string.Format(format, args);

            builder.AppendWithIf(value, separator, !string.IsNullOrEmpty(value));
        }
        public static void AppendFormatWithCommaIfNotEmpty(this StringBuilder builder, string format, params object[] args)
        {
            builder.AppendFormatWithIfNotEmpty(format, ",", args);
        }
    }
}
