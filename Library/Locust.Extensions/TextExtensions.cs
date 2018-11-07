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
            if (!string.IsNullOrEmpty(text))
            {
                builder.Append(text);
            }
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
            if (!string.IsNullOrEmpty(format))
            {
                builder.AppendFormat(format, args);
            }
        }
        public static void AppendWithComma(this StringBuilder builder, string text)
        {
            builder.Append((builder.Length > 0 ? "," : "") + text);
        }
        public static void AppendWithCommaIf(this StringBuilder builder, string text, bool condition)
        {
            if (condition)
            {
                builder.Append((builder.Length > 0?",":"") + text);
            }
        }
        public static void AppendWithCommaIfNotEmpty(this StringBuilder builder, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                builder.Append((builder.Length > 0 ? "," : "") + text);
            }
        }
        public static void AppendFormatWithCommaIf(this StringBuilder builder, string format, bool condition, params object[] args)
        {
            if (condition)
            {
                builder.AppendFormat((builder.Length > 0 ? "," : "") + format, args);
            }
        }
        public static void AppendFormatWithComma(this StringBuilder builder, string format, params object[] args)
        {
            builder.AppendFormat((builder.Length > 0 ? "," : "") + format, args);
        }
        public static void AppendFormatWithCommaIfNotEmpty(this StringBuilder builder, string format, params object[] args)
        {
            if (!string.IsNullOrEmpty(format))
            {
                builder.AppendFormat((builder.Length > 0 ? "," : "") + format, args);
            }
        }
    }
}
