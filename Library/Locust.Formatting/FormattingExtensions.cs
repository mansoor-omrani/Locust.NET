using Locust.Calendar;
using Locust.Extensions;
using Locust.Language;
using Locust.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Formatting
{
    public static class FormattingExtensions
    {
        #region GetMonthName
        public static string GetMonthName(this DateTimeValue dtv, ITranslator translator, object n, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Month>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetMonthName(this DateTimeValue dtv, object n, Lang lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Month>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetMonthName(this DateTimeValue dtv, ITranslator translator, object n, string lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Month>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetMonthName(this DateTimeValue dtv, object n, string lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Month>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetMonthName(this DateTimeValue dtv, ITranslator translator, object n)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Month>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        public static string GetMonthName(this DateTimeValue dtv, object n)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Month>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        #endregion
        #region GetShortMonthName
        public static string GetShortMonthName(this DateTimeValue dtv, ITranslator translator, object n, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<ShortMonth>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetShortMonthName(this DateTimeValue dtv, object n, Lang lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<ShortMonth>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetShortMonthName(this DateTimeValue dtv, ITranslator translator, object n, string lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<ShortMonth>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetShortMonthName(this DateTimeValue dtv, object n, string lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<ShortMonth>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetShortMonthName(this DateTimeValue dtv, ITranslator translator, object n)
        {
            var result = translator.GetCultureDependentTextByEnumValue<ShortMonth>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        public static string GetShortMonthName(this DateTimeValue dtv, object n)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<ShortMonth>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        #endregion
        #region GetSeasonName
        public static string GetSeasonName(this DateTimeValue dtv, ITranslator translator, object n, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Season>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetSeasonName(this DateTimeValue dtv, object n, Lang lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Season>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetSeasonName(this DateTimeValue dtv, ITranslator translator, object n, string lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Season>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetSeasonName(this DateTimeValue dtv, object n, string lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Season>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetSeasonName(this DateTimeValue dtv, ITranslator translator, object n)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Season>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        public static string GetSeasonName(this DateTimeValue dtv, object n)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Season>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        #endregion
        #region GetWeekdayName
        public static string GetWeekdayName(this DateTimeValue dtv, ITranslator translator, object n, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Weekday>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetWeekdayName(this DateTimeValue dtv, object n, Lang lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Weekday>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetWeekdayName(this DateTimeValue dtv, ITranslator translator, object n, string lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Weekday>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetWeekdayName(this DateTimeValue dtv, object n, string lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Weekday>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetWeekdayName(this DateTimeValue dtv, ITranslator translator, object n)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Weekday>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        public static string GetWeekdayName(this DateTimeValue dtv, object n)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<Weekday>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        #endregion
        #region GetShortWeekdayName
        public static string GetShortWeekdayName(this DateTimeValue dtv, ITranslator translator, object n, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<ShortWeekday>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetShortWeekdayName(this DateTimeValue dtv, object n, Lang lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<ShortWeekday>(n, dtv.Helper.CalendarType.ToString(), lang);

            return result;
        }
        public static string GetShortWeekdayName(this DateTimeValue dtv, ITranslator translator, object n, string lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<ShortWeekday>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetShortWeekdayName(this DateTimeValue dtv, object n, string lang)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<ShortWeekday>(n, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));

            return result;
        }
        public static string GetShortWeekdayName(this DateTimeValue dtv, ITranslator translator, object n)
        {
            var result = translator.GetCultureDependentTextByEnumValue<ShortWeekday>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        public static string GetShortWeekdayName(this DateTimeValue dtv, object n)
        {
            var result = Formatter.DefaultTranslator.GetCultureDependentTextByEnumValue<ShortWeekday>(n, dtv.Helper.CalendarType.ToString(), Lang.Default);

            return result;
        }
        #endregion
        #region Format
        public static string Format(this DateTimeValue dtv, ITranslator translator, string format, Lang lang)
        {
            return DateFormatter.Format(translator, dtv, format, dtv.Helper.CalendarType.ToString(), lang);
        }
        public static string Format(this DateTimeValue dtv, string format, Lang lang)
        {
            return DateFormatter.Format(Formatter.DefaultTranslator, dtv, format, dtv.Helper.CalendarType.ToString(), lang);
        }
        public static string Format(this DateTimeValue dtv, ITranslator translator, string format, string lang)
        {
            return DateFormatter.Format(translator, dtv, format, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));
        }
        public static string Format(this DateTimeValue dtv, string format, string lang)
        {
            return DateFormatter.Format(Formatter.DefaultTranslator, dtv, format, dtv.Helper.CalendarType.ToString(), Lang.Get(lang));
        }
        public static string Format(this DateTimeValue dtv, ITranslator translator, string format)
        {
            return DateFormatter.Format(translator, dtv, format, dtv.Helper.CalendarType.ToString(), Lang.Default);
        }
        public static string Format(this DateTimeValue dtv, string format)
        {
            return DateFormatter.Format(Formatter.DefaultTranslator, dtv, format, dtv.Helper.CalendarType.ToString(), Lang.Default);
        }
        #endregion
    }
}
