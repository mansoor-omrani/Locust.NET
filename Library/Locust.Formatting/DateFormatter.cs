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
    public class DateFormatter
    {
        public static string GetMonthName(ITranslator translator, object n, string culture, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Month>(n, culture, lang);

            return result;
        }
        public static string GetShortMonthName(ITranslator translator, object n, string culture, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<ShortMonth>(n, culture, lang);

            return result;
        }
        public static string GetSeasonName(ITranslator translator, object n, string culture, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Season>(n, culture, lang);

            return result;
        }
        public static string GetWeekdayName(ITranslator translator, object n, string culture, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<Weekday>(n, culture, lang);

            return result;
        }
        public static string GetShortWeekdayName(ITranslator translator, object n, string culture, Lang lang)
        {
            var result = translator.GetCultureDependentTextByEnumValue<ShortWeekday>(n, culture, lang);

            return result;
        }
        public static string Format(ITranslator translator, DateTimeValue dtv, string format, string culture, Lang lang)
        {
            var result = "";

            if (!string.IsNullOrEmpty(format))
            {
                var state = 1;
                var index = 0;
                var arg = "";
                char ch;

                while (index < format.Length)
                {
                    ch = format[index++];

                    switch (state)
                    {
                        case 1:
                            if (ch == '{')
                            {
                                arg = "";
                                state = 2;
                            }
                            else
                            {
                                result += ch;
                            }
                            break;
                        case 2:
                            if (ch == '}')
                            {
                                switch (arg)
                                {
                                    case "y":
                                        result += dtv.Year;
                                        break;
                                    case "yy":
                                        result += dtv.Year.ToString().Right(2);
                                        break;
                                    case "yyyy":
                                        result += ("0000" + dtv.Year.ToString()).Right(4);
                                        break;
                                    case "year":
                                        result += dtv.Year;
                                        break;
                                    case "M":
                                        result += dtv.Month;
                                        break;
                                    case "MM":
                                        result += ("0" + dtv.Month.ToString()).Right(2);
                                        break;
                                    case "MMM":
                                        result += GetShortMonthName(translator, dtv.Month, culture, lang);
                                        break;
                                    case "MMMM":
                                        result += GetMonthName(translator, dtv.Month, culture, lang);
                                        break;
                                    case "month":
                                        result += GetMonthName(translator, dtv.Month, culture, lang);
                                        break;
                                    case "shortmonth":
                                        result += GetShortMonthName(translator, dtv.Month, culture, lang);
                                        break;
                                    case "d":
                                        result += dtv.Day;
                                        break;
                                    case "dd":
                                        result += ("0" + dtv.Day.ToString()).Right(2);
                                        break;
                                    case "day":
                                        result += GetWeekdayName(translator, dtv.DayOfWeek, culture, lang);
                                        break;
                                    case "#day":
                                        result += translator.GetNthNumber(lang, dtv.Day);
                                        break;
                                    case "#weekday":
                                        result += ((int)dtv.DayOfWeek + 1).ToString();
                                        break;
                                    case "dddd":
                                        result += GetWeekdayName(translator, dtv.DayOfWeek, culture, lang);
                                        break;
                                    case "weekday":
                                        result += GetWeekdayName(translator, dtv.DayOfWeek, culture, lang);
                                        break;
                                    case "shortweekday":
                                        result += GetShortWeekdayName(translator, dtv.DayOfWeek, culture, lang);
                                        break;
                                    case "h":
                                        result += dtv.Hour;
                                        break;
                                    case "H":
                                        var x1 = dtv.Hour;
                                        if (x1 >= 12)
                                            x1 -= 12;
                                        result += x1.ToString();
                                        break;
                                    case "HH":
                                        var x2 = dtv.Hour;
                                        if (x2 >= 12)
                                            x2 -= 12;
                                        result += ("0" + x2.ToString()).Right(2);
                                        break;
                                    case "hh":
                                        result += ("0" + dtv.Hour.ToString()).Right(2);
                                        break;
                                    case "hour":
                                        result += dtv.Hour;
                                        break;
                                    case "mm":
                                        result += dtv.Minute;
                                        break;
                                    case "minute":
                                        result += ("0" + dtv.Minute.ToString()).Right(2);
                                        break;
                                    case "s":
                                        result += dtv.Second;
                                        break;
                                    case "ss":
                                        result += ("0" + dtv.Second.ToString()).Right(2);
                                        break;
                                    case "second":
                                        result += dtv.Second;
                                        break;
                                    case "ms":
                                        result += ("0" + dtv.Second.ToString()).Right(2);
                                        break;
                                    case "mili":
                                        result += ("0" + dtv.Second.ToString()).Right(2);
                                        break;
                                    case "milisecond":
                                        result += dtv.Millisecond;
                                        break;
                                    case "tt":
                                        if (dtv.Hour >= 12)
                                            result += "PM";
                                        else
                                            result += "AM";
                                        break;
                                }
                                state = 1;
                            }
                            else
                            {
                                arg += ch;
                            }
                            break;
                    }
                }
            }

            return result;
        }
        /*
        public string FormatDate(DateTime d, string format, Lang lang)
        {
            var result = "";

            if (!string.IsNullOrEmpty(format))
            {
                var c = this.SystemCalendar;
                var state = 1;
                var index = 0;
                var arg = "";
                char ch;

                while (index < format.Length)
                {
                    ch = format[index++];

                    switch (state)
                    {
                        case 1:
                            if (ch == '{')
                            {
                                arg = "";
                                state = 2;
                            }
                            else
                            {
                                result += ch;
                            }
                            break;
                        case 2:
                            if (ch == '}')
                            {
                                switch (arg)
                                {
                                    case "y":
                                        result += c.GetYear(d);
                                        break;
                                    case "yy":
                                        result += c.GetYear(d).ToString().Right(2);
                                        break;
                                    case "yyyy":
                                        result += c.GetYear(d);
                                        break;
                                    case "year":
                                        result += c.GetYear(d);
                                        break;
                                    case "M":
                                        result += c.GetMonth(d);
                                        break;
                                    case "MM":
                                        result += ("0" + c.GetMonth(d).ToString()).Right(2);
                                        break;
                                    case "MMM":
                                        result += GetShortMonthName(c.GetMonth(d), lang);
                                        break;
                                    case "MMMM":
                                        result += GetMonthName(c.GetMonth(d), lang);
                                        break;
                                    case "month":
                                        result += GetMonthName(c.GetMonth(d), lang);
                                        break;
                                    case "shortmonth":
                                        result += GetShortMonthName(c.GetMonth(d), lang);
                                        break;
                                    case "d":
                                        result += c.GetDayOfMonth(d);
                                        break;
                                    case "dd":
                                        result += ("0" + c.GetDayOfMonth(d).ToString()).Right(2);
                                        break;
                                    case "day":
                                        result += GetWeekdayName(c.GetDayOfWeek(d), lang);
                                        break;
                                    case "#day":
                                        result += lang.GetNthNumber(c.GetDayOfMonth(d));
                                        break;
                                    case "#weekday":
                                        result += ((int)c.GetDayOfWeek(d) + 1).ToString();
                                        break;
                                    case "dddd":
                                        result += GetWeekdayName(c.GetDayOfWeek(d), lang);
                                        break;
                                    case "weekday":
                                        result += GetWeekdayName(c.GetDayOfWeek(d), lang);
                                        break;
                                    case "shortweekday":
                                        result += GetShortWeekdayName(c.GetDayOfWeek(d), lang);
                                        break;
                                    case "h":
                                        result += c.GetHour(d);
                                        break;
                                    case "H":
                                        var x1 = c.GetHour(d);
                                        if (x1 >= 12)
                                            x1 -= 12;
                                        result += x1.ToString();
                                        break;
                                    case "HH":
                                        var x2 = c.GetHour(d);
                                        if (x2 >= 12)
                                            x2 -= 12;
                                        result += ("0" + x2.ToString()).Right(2);
                                        break;
                                    case "hh":
                                        result += ("0" + c.GetHour(d).ToString()).Right(2);
                                        break;
                                    case "hour":
                                        result += c.GetHour(d);
                                        break;
                                    case "mm":
                                        result += c.GetMinute(d);
                                        break;
                                    case "minute":
                                        result += ("0" + c.GetMinute(d).ToString()).Right(2);
                                        break;
                                    case "s":
                                        result += c.GetSecond(d);
                                        break;
                                    case "ss":
                                        result += ("0" + c.GetSecond(d).ToString()).Right(2);
                                        break;
                                    case "second":
                                        result += c.GetSecond(d);
                                        break;
                                    case "ms":
                                        result += ("0" + c.GetSecond(d).ToString()).Right(2);
                                        break;
                                    case "mili":
                                        result += ("0" + c.GetSecond(d).ToString()).Right(2);
                                        break;
                                    case "milisecond":
                                        result += c.GetMilliseconds(d);
                                        break;
                                    case "tt":
                                        if (c.GetHour(d) >= 12)
                                            result += "PM";
                                        else
                                            result += "AM";
                                        break;
                                }
                                state = 1;
                            }
                            else
                            {
                                arg += ch;
                            }
                            break;
                    }
                }
            }

            return result;
        }
        */
        /*
        private static string GetName<T, T1, T2>(object n, string culture, Lang lang)
            where T : struct
            where T1 : struct
            where T2 : struct
        {
            var result = "";

            if (n != null)
            {
                sbyte b = 1;

                if (n is string)
                {
                    T m1;
                    T1 m2;
                    T2 m3;

                    if (!Enum.TryParse<T>((string)n, true, out m1))
                    {
                        b = SafeClrConvert.ToSByte(m1);
                    }
                    else
                    {
                        if (Enum.TryParse<T1>((string)n, true, out m2))
                        {
                            b = SafeClrConvert.ToSByte(m2);
                        }
                        else
                        {
                            if (Enum.TryParse<T2>((string)n, true, out m3))
                            {
                                b = SafeClrConvert.ToSByte(m3);
                            }
                        }
                    }
                }
                else
                {
                    b = SafeClrConvert.ToSByte(n);
                }

                result = Translator.GetSingle(typeof(T).Name, b.ToString(), culture, lang.ShortName);
            }

            return result;
        }
        public static string GetMonthName(object n, Lang lang)
        {
            var result = GetName<Month, MonthPersian, MonthChristian>(n, this.Type.ToString(), lang);

            return result;
        }
        public static string GetShortMonthName(object n, Lang lang)
        {
            var result = GetName<ShortMonth, ShortMonthPersian, ShortMonthChristian>(n, this.Type.ToString(), lang);

            return result;
        }
        public static string GetSeasonName(object n, Lang lang)
        {
            var result = GetName<Season, SeasonPersian, SeasonChristian>(n, this.Type.ToString(), lang);

            return result;
        }
        public static string GetWeekdayName(object n, Lang lang)
        {
            var result = GetName<Weekday, WeekdayPersian, WeekdayChristian>(n, this.Type.ToString(), lang);

            return result;
        }
        */
    }
}
