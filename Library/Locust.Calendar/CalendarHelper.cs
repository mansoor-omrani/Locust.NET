using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;
using System.Threading;
using Locust.Conversion;

namespace Locust.Calendar
{
    public abstract class CalendarHelper
    {
        public CalendarType CalendarType { get; protected set; }
        public Type MonthType { get; protected set; }
        public Type ShortMonthType { get; protected set; }
        public Type SeasonType { get; protected set; }
        public Type WeekdayType { get; protected set; }
        public Type ShortWeekdayType { get; protected set; }
        public abstract object ToMonth(object n, bool ignoreCase = true);
        public abstract object ToShortMonth(object n, bool ignoreCase = true);
        public abstract object ToSeason(object n, bool ignoreCase = true);
        public abstract object ToWeekday(object n, bool ignoreCase = true);
        public abstract object ToShortWeekday(object n, bool ignoreCase = true);
        
        private static readonly CalendarPersian _persian;
        private static readonly CalendarGregorian _gregorian;
        private static readonly CalendarHebrew _hebrew;
        private static readonly CalendarJulian _julian;
        private static readonly CalendarHijri _hijri;
        private static readonly CalendarJapanese _japanese;
        private static readonly CalendarKorean _korean;
        private static readonly CalendarTaiwan _taiwan;
        private static readonly CalendarJapaneseLunisolar _japaneseLunisolar;
        private static readonly CalendarKoreanLunisolar _koreanLunisolar;
        private static readonly CalendarTaiwanLunisolar _taiwanLunisolar;
        private static readonly CalendarChineseLunisolar _chineseLunisolar;
        public static CalendarPersian Persian
        {
            get
            {
                return _persian;
            }
        }
        public static CalendarGregorian Gregorian
        {
            get
            {
                return _gregorian;
            }
        }
        public static CalendarHebrew Hebrew
        {
            get
            {
                return _hebrew;
            }
        }
        public static CalendarJulian Julian
        {
            get
            {
                return _julian;
            }
        }
        public static CalendarHijri Hijri
        {
            get
            {
                return _hijri;
            }
        }
        public static CalendarJapanese Japanese
        {
            get
            {
                return _japanese;
            }
        }
        public static CalendarKorean Korean
        {
            get
            {
                return _korean;
            }
        }
        public static CalendarTaiwan Taiwan
        {
            get
            {
                return _taiwan;
            }
        }
        public static CalendarJapaneseLunisolar JapaneseLunisolar
        {
            get
            {
                return _japaneseLunisolar;
            }
        }
        public static CalendarKoreanLunisolar KoreanLunisolar
        {
            get
            {
                return _koreanLunisolar;
            }
        }
        public static CalendarTaiwanLunisolar TaiwanLunisolar
        {
            get
            {
                return _taiwanLunisolar;
            }
        }
        public static CalendarChineseLunisolar ChineseLunisolar
        {
            get
            {
                return _chineseLunisolar;
            }
        }
        private static readonly List<CalendarHelper> _calendars;
        static CalendarHelper()
        {
            _persian = new CalendarPersian();
            _gregorian = new CalendarGregorian();
            _hebrew = new CalendarHebrew();
            _julian = new CalendarJulian();
            _hijri = new CalendarHijri();
            _japanese = new CalendarJapanese();
            _korean = new CalendarKorean();
            _taiwan = new CalendarTaiwan();
            _japaneseLunisolar = new CalendarJapaneseLunisolar();
            _koreanLunisolar = new CalendarKoreanLunisolar();
            _taiwanLunisolar = new CalendarTaiwanLunisolar();
            _chineseLunisolar = new CalendarChineseLunisolar();

            _calendars = new List<CalendarHelper>();

            _calendars.Add(_persian);
            _calendars.Add(_gregorian);
            _calendars.Add(_hebrew);
            _calendars.Add(_julian);
            _calendars.Add(_hijri);
            _calendars.Add(_japanese);
            _calendars.Add(_korean);
            _calendars.Add(_taiwan);
            _calendars.Add(_japaneseLunisolar);
            _calendars.Add(_koreanLunisolar);
            _calendars.Add(_taiwanLunisolar);
            _calendars.Add(_chineseLunisolar);

            _default = _gregorian;
        }
        public static List<CalendarHelper> GetAll()
        {
            return _calendars;
        }
        private static CalendarHelper _default;
        public static CalendarHelper Default
        {
            get { return _default; }
            set { _default = value; }
        }
    }
    public class CalendarPersian : CalendarHelper
    {
        public CalendarPersian()
        {
            CalendarType = CalendarType.Persian;
            MonthType = typeof(MonthPersian);
            ShortMonthType = typeof(ShortMonthPersian);
            SeasonType = typeof(SeasonPersian);
            WeekdayType = typeof(WeekdayPersian);
            ShortWeekdayType = typeof(ShortWeekdayPersian);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthPersian>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthPersian>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonPersian>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayPersian>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayPersian>(n, ignoreCase);
        }
    }
    public class CalendarGregorian : CalendarHelper
    {
        public CalendarGregorian()
        {
            CalendarType = CalendarType.Gregorian;
            MonthType = typeof(MonthGregorian);
            ShortMonthType = typeof(ShortMonthGregorian);
            SeasonType = typeof(SeasonGregorian);
            WeekdayType = typeof(WeekdayGregorian);
            ShortWeekdayType = typeof(ShortWeekdayGregorian);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthGregorian>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthGregorian>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonGregorian>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayGregorian>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayGregorian>(n, ignoreCase);
        }
    }
    public class CalendarHijri : CalendarHelper
    {
        public CalendarHijri()
        {
            CalendarType = CalendarType.Hijri;
            MonthType = typeof(MonthHijri);
            ShortMonthType = typeof(ShortMonthHijri);
            SeasonType = typeof(SeasonHijri);
            WeekdayType = typeof(WeekdayHijri);
            ShortWeekdayType = typeof(ShortWeekdayHijri);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthHijri>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthHijri>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonHijri>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayHijri>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayHijri>(n, ignoreCase);
        }
    }
    public class CalendarHebrew : CalendarHelper
    {
        public CalendarHebrew()
        {
            CalendarType = CalendarType.Hebrew;
            MonthType = typeof(MonthHebrew);
            ShortMonthType = typeof(ShortMonthHebrew);
            SeasonType = typeof(SeasonHebrew);
            WeekdayType = typeof(WeekdayHebrew);
            ShortWeekdayType = typeof(ShortWeekdayHebrew);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthHebrew>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthHebrew>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonHebrew>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayHebrew>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayHebrew>(n, ignoreCase);
        }
    }
    public class CalendarJulian: CalendarHelper
    {
        public CalendarJulian()
        {
            CalendarType = CalendarType.Julian;
            MonthType = typeof(MonthJulian);
            ShortMonthType = typeof(ShortMonthJulian);
            SeasonType = typeof(SeasonJulian);
            WeekdayType = typeof(WeekdayJulian);
            ShortWeekdayType = typeof(ShortWeekdayJulian);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthJulian>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthJulian>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonJulian>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayJulian>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayJulian>(n, ignoreCase);
        }
    }
    public class CalendarJapanese : CalendarHelper
    {
        public CalendarJapanese()
        {
            CalendarType = CalendarType.Japanese;
            MonthType = typeof(MonthJapanese);
            ShortMonthType = typeof(ShortMonthJapanese);
            SeasonType = typeof(SeasonJapanese);
            WeekdayType = typeof(WeekdayJapanese);
            ShortWeekdayType = typeof(ShortWeekdayJapanese);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthJapanese>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthJapanese>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonJapanese>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayJapanese>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayJapanese>(n, ignoreCase);
        }
    }
    public class CalendarKorean : CalendarHelper
    {
        public CalendarKorean()
        {
            CalendarType = CalendarType.Korean;
            MonthType = typeof(MonthKorean);
            ShortMonthType = typeof(ShortMonthKorean);
            SeasonType = typeof(SeasonKorean);
            WeekdayType = typeof(WeekdayKorean);
            ShortWeekdayType = typeof(ShortWeekdayKorean);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthKorean>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthKorean>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonKorean>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayKorean>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayKorean>(n, ignoreCase);
        }
    }
    public class CalendarTaiwan : CalendarHelper
    {
        public CalendarTaiwan()
        {
            CalendarType = CalendarType.Taiwan;
            MonthType = typeof(MonthTaiwan);
            ShortMonthType = typeof(ShortMonthTaiwan);
            SeasonType = typeof(SeasonTaiwan);
            WeekdayType = typeof(WeekdayTaiwan);
            ShortWeekdayType = typeof(ShortWeekdayTaiwan);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthTaiwan>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthTaiwan>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonTaiwan>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayTaiwan>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayTaiwan>(n, ignoreCase);
        }
    }
    public class CalendarJapaneseLunisolar : CalendarHelper
    {
        public CalendarJapaneseLunisolar()
        {
            CalendarType = CalendarType.Japanese;
            MonthType = typeof(MonthJapaneseLunisolar);
            ShortMonthType = typeof(ShortMonthJapaneseLunisolar);
            SeasonType = typeof(SeasonJapaneseLunisolar);
            WeekdayType = typeof(WeekdayJapaneseLunisolar);
            ShortWeekdayType = typeof(ShortWeekdayJapaneseLunisolar);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthJapaneseLunisolar>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthJapaneseLunisolar>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonJapaneseLunisolar>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayJapaneseLunisolar>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayJapaneseLunisolar>(n, ignoreCase);
        }
    }
    public class CalendarKoreanLunisolar : CalendarHelper
    {
        public CalendarKoreanLunisolar()
        {
            CalendarType = CalendarType.Korean;
            MonthType = typeof(MonthKoreanLunisolar);
            ShortMonthType = typeof(ShortMonthKoreanLunisolar);
            SeasonType = typeof(SeasonKoreanLunisolar);
            WeekdayType = typeof(WeekdayKoreanLunisolar);
            ShortWeekdayType = typeof(ShortWeekdayKoreanLunisolar);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthKoreanLunisolar>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthKoreanLunisolar>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonKoreanLunisolar>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayKoreanLunisolar>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayKoreanLunisolar>(n, ignoreCase);
        }
    }
    public class CalendarTaiwanLunisolar : CalendarHelper
    {
        public CalendarTaiwanLunisolar()
        {
            CalendarType = CalendarType.Taiwan;
            MonthType = typeof(MonthTaiwanLunisolar);
            ShortMonthType = typeof(ShortMonthTaiwanLunisolar);
            SeasonType = typeof(SeasonTaiwanLunisolar);
            WeekdayType = typeof(WeekdayTaiwanLunisolar);
            ShortWeekdayType = typeof(ShortWeekdayTaiwanLunisolar);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthTaiwanLunisolar>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthTaiwanLunisolar>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonTaiwanLunisolar>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayTaiwanLunisolar>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayTaiwanLunisolar>(n, ignoreCase);
        }
    }
    public class CalendarChineseLunisolar : CalendarHelper
    {
        public CalendarChineseLunisolar()
        {
            CalendarType = CalendarType.Chinese;
            MonthType = typeof(MonthChineseLunisolar);
            ShortMonthType = typeof(ShortMonthChineseLunisolar);
            SeasonType = typeof(SeasonChineseLunisolar);
            WeekdayType = typeof(WeekdayChineseLunisolar);
            ShortWeekdayType = typeof(ShortWeekdayChineseLunisolar);
        }
        public override object ToMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<MonthChineseLunisolar>(n, ignoreCase);
        }
        public override object ToShortMonth(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortMonthChineseLunisolar>(n, ignoreCase);
        }
        public override object ToSeason(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<SeasonChineseLunisolar>(n, ignoreCase);
        }
        public override object ToWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<WeekdayChineseLunisolar>(n, ignoreCase);
        }
        public override object ToShortWeekday(object n, bool ignoreCase = true)
        {
            return EnumHelper.ToEnum<ShortWeekdayChineseLunisolar>(n, ignoreCase);
        }
    }
}
