using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Locust.Calendar
{
    public class DateTimeField
    {
        public bool HasValue { get; protected set; }
        private void initExclusive(DateTimeValue dateValue)
        {
            if (!(dateValue is GregorianDateValue) && gregorian != null)
            {
                dateValue.Read(gregorian.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is PersianDateValue) && persian != null)
            {
                dateValue.Read(persian.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is HijriDateValue) && hijri != null)
            {
                dateValue.Read(hijri.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is HebrewDateValue) && hebrew != null)
            {
                dateValue.Read(hebrew.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is JulianDateValue) && julian != null)
            {
                dateValue.Read(julian.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is KoreanDateValue) && korean != null)
            {
                dateValue.Read(korean.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is JapaneseDateValue) && japanese != null)
            {
                dateValue.Read(japanese.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is TaiwanDateValue) && taiwan != null)
            {
                dateValue.Read(taiwan.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is KoreanLunisolarDateValue) && koreanLunisolar != null)
            {
                dateValue.Read(koreanLunisolar.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is JapaneseLunisolarDateValue) && japaneseLunisolar != null)
            {
                dateValue.Read(japaneseLunisolar.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is TaiwanLunisolarDateValue) && taiwanLunisolar != null)
            {
                dateValue.Read(taiwanLunisolar.ToDateTime());
                HasValue = true;
                return;
            }
            if (!(dateValue is ChineseLunisolarDateValue) && chineseLunisolar != null)
            {
                dateValue.Read(chineseLunisolar.ToDateTime());
                HasValue = true;
                return;
            }
        }
        private GregorianDateValue gregorian;
        public GregorianDateValue Gregorian
        {
            get
            {
                return LazyInitializer.EnsureInitialized<GregorianDateValue>(ref gregorian, () =>
                {
                    var result = new GregorianDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private PersianDateValue persian;
        public PersianDateValue Persian
        {
            get
            {
                return LazyInitializer.EnsureInitialized<PersianDateValue>(ref persian, () =>
                {
                    var result = new PersianDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private HebrewDateValue hebrew;
        public HebrewDateValue Hebrew
        {
            get
            {
                return LazyInitializer.EnsureInitialized<HebrewDateValue>(ref hebrew, () =>
                {
                    var result = new HebrewDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private HijriDateValue hijri;
        public HijriDateValue Hijri
        {
            get
            {
                return LazyInitializer.EnsureInitialized<HijriDateValue>(ref hijri, () =>
                {
                    var result = new HijriDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private JulianDateValue julian;
        public JulianDateValue Julian
        {
            get
            {
                return LazyInitializer.EnsureInitialized<JulianDateValue>(ref julian, () =>
                {
                    var result = new JulianDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private JapaneseDateValue japanese;
        public JapaneseDateValue Japanese
        {
            get
            {
                return LazyInitializer.EnsureInitialized<JapaneseDateValue>(ref japanese, () =>
                {
                    var result = new JapaneseDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private KoreanDateValue korean;
        public KoreanDateValue Korean
        {
            get
            {
                return LazyInitializer.EnsureInitialized<KoreanDateValue>(ref korean, () =>
                {
                    var result = new KoreanDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private TaiwanDateValue taiwan;
        public TaiwanDateValue Taiwan
        {
            get
            {
                return LazyInitializer.EnsureInitialized<TaiwanDateValue>(ref taiwan, () =>
                {
                    var result = new TaiwanDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private KoreanLunisolarDateValue koreanLunisolar;
        public KoreanLunisolarDateValue KoreanLunisolar
        {
            get
            {
                return LazyInitializer.EnsureInitialized<KoreanLunisolarDateValue>(ref koreanLunisolar, () =>
                {
                    var result = new KoreanLunisolarDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private TaiwanLunisolarDateValue taiwanLunisolar;
        public TaiwanLunisolarDateValue TaiwanLunisolar
        {
            get
            {
                return LazyInitializer.EnsureInitialized<TaiwanLunisolarDateValue>(ref taiwanLunisolar, () =>
                {
                    var result = new TaiwanLunisolarDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private JapaneseLunisolarDateValue japaneseLunisolar;
        public JapaneseLunisolarDateValue JapaneseLunisolar
        {
            get
            {
                return LazyInitializer.EnsureInitialized<JapaneseLunisolarDateValue>(ref japaneseLunisolar, () =>
                {
                    var result = new JapaneseLunisolarDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private ChineseLunisolarDateValue chineseLunisolar;
        public ChineseLunisolarDateValue ChineseLunisolar
        {
            get
            {
                return LazyInitializer.EnsureInitialized<ChineseLunisolarDateValue>(ref chineseLunisolar, () =>
                {
                    var result = new ChineseLunisolarDateValue();

                    initExclusive(result);

                    result.DateChanged += OnDateChanged;

                    return result;
                });
            }
        }
        private void OnDateChanged(DateTimeValue x)
        {
            HasValue = true;

            DateTime date = DateTime.Now;

            if (x is PersianDateValue)
            {
                date = Persian.ToDateTime();
            }
            else if (x is GregorianDateValue)
            {
                date = Gregorian.ToDateTime();
            }
            else if (x is HebrewDateValue)
            {
                date = Hebrew.ToDateTime();
            }
            else if (x is HijriDateValue)
            {
                date = Hijri.ToDateTime();
            }
            else if (x is JulianDateValue)
            {
                date = Julian.ToDateTime();
            }
            else if (x is KoreanDateValue)
            {
                date = Korean.ToDateTime();
            }
            else if (x is JapaneseDateValue)
            {
                date = Japanese.ToDateTime();
            }
            else if (x is TaiwanDateValue)
            {
                date = Taiwan.ToDateTime();
            }
            else if (x is KoreanLunisolarDateValue)
            {
                date = KoreanLunisolar.ToDateTime();
            }
            else if (x is JapaneseLunisolarDateValue)
            {
                date = JapaneseLunisolar.ToDateTime();
            }
            else if (x is TaiwanLunisolarDateValue)
            {
                date = TaiwanLunisolar.ToDateTime();
            }
            else if (x is ChineseLunisolarDateValue)
            {
                date = ChineseLunisolar.ToDateTime();
            }

            if (persian != null && !(x is PersianDateValue))
            {
                Persian.DateChanged -= OnDateChanged;
                Persian.Read(date);
            }

            if (gregorian != null && !(x is GregorianDateValue))
            {
                Gregorian.DateChanged -= OnDateChanged;
                Gregorian.Read(date);
            }
            if (julian != null && !(x is JulianDateValue))
            {
                Julian.DateChanged -= OnDateChanged;
                Julian.Read(date);
            }
            if (hebrew != null && !(x is HebrewDateValue))
            {
                Hebrew.DateChanged -= OnDateChanged;
                Hebrew.Read(date);
            }
            if (hijri != null && !(x is HijriDateValue))
            {
                Hijri.DateChanged -= OnDateChanged;
                Hijri.Read(date);
            }
            if (korean != null && !(x is KoreanDateValue))
            {
                Korean.DateChanged -= OnDateChanged;
                Korean.Read(date);
            }
            if (japanese != null && !(x is JapaneseDateValue))
            {
                Japanese.DateChanged -= OnDateChanged;
                Japanese.Read(date);
            }
            if (taiwan != null && !(x is TaiwanDateValue))
            {
                Taiwan.DateChanged -= OnDateChanged;
                Taiwan.Read(date);
            }
            if (koreanLunisolar != null && !(x is KoreanLunisolarDateValue))
            {
                KoreanLunisolar.DateChanged -= OnDateChanged;
                KoreanLunisolar.Read(date);
            }
            if (japaneseLunisolar != null && !(x is JapaneseLunisolarDateValue))
            {
                JapaneseLunisolar.DateChanged -= OnDateChanged;
                JapaneseLunisolar.Read(date);
            }
            if (taiwanLunisolar != null && !(x is TaiwanLunisolarDateValue))
            {
                TaiwanLunisolar.DateChanged -= OnDateChanged;
                TaiwanLunisolar.Read(date);
            }
            if (chineseLunisolar != null && !(x is ChineseLunisolarDateValue))
            {
                ChineseLunisolar.DateChanged -= OnDateChanged;
                ChineseLunisolar.Read(date);
            }

            if (persian != null && !(x is PersianDateValue))
                Persian.DateChanged += OnDateChanged;

            if (gregorian != null && !(x is GregorianDateValue))
                Gregorian.DateChanged += OnDateChanged;

            if (julian != null && !(x is JulianDateValue))
                Julian.DateChanged += OnDateChanged;

            if (hebrew != null && !(x is HebrewDateValue))
                Hebrew.DateChanged += OnDateChanged;

            if (hijri != null && !(x is HijriDateValue))
                Hijri.DateChanged += OnDateChanged;

            if (korean != null && !(x is KoreanDateValue))
                Korean.DateChanged += OnDateChanged;

            if (japanese != null && !(x is JapaneseDateValue))
                Japanese.DateChanged += OnDateChanged;

            if (taiwan != null && !(x is TaiwanDateValue))
                Taiwan.DateChanged += OnDateChanged;

            if (koreanLunisolar != null && !(x is KoreanLunisolarDateValue))
                KoreanLunisolar.DateChanged += OnDateChanged;

            if (japaneseLunisolar != null && !(x is JapaneseLunisolarDateValue))
                JapaneseLunisolar.DateChanged += OnDateChanged;

            if (taiwanLunisolar != null && !(x is TaiwanLunisolarDateValue))
                TaiwanLunisolar.DateChanged += OnDateChanged;

            if (chineseLunisolar != null && !(x is ChineseLunisolarDateValue))
                ChineseLunisolar.DateChanged += OnDateChanged;
        }
        public static explicit operator DateTimeField(DateTime date)
        {
            var dtf = new DateTimeField();

            dtf.Gregorian.Read(date);

            return dtf;
        }
        public static implicit operator DateTime(DateTimeField dtf)
        {
            return dtf.Gregorian.ToDateTime();
        }

        public int Year(Calendars calendar)
        {
            switch (calendar)
            {
                case Calendars.Gregorian: return Gregorian.Year; 
                case Calendars.Persian: return Persian.Year; 
                case Calendars.Hebrew: return Hebrew.Year; 
                case Calendars.Hijri: return Hijri.Year; 
                case Calendars.Julian: return Julian.Year; 
                case Calendars.Japanese: return Japanese.Year; 
                case Calendars.Korean: return Korean.Year; 
                case Calendars.Taiwan: return Taiwan.Year; 
                case Calendars.KoreanLunisolar: return KoreanLunisolar.Year; 
                case Calendars.TaiwanLunisolar: return TaiwanLunisolar.Year; 
                case Calendars.JapaneseLunisolar: return JapaneseLunisolar.Year; 
                case Calendars.ChineseLunisolar: return ChineseLunisolar.Year;
            }

            return 0;
        }
        public int Month(Calendars calendar)
        {
            switch (calendar)
            {
                case Calendars.Gregorian: return Gregorian.Month;
                case Calendars.Persian: return Persian.Month;
                case Calendars.Hebrew: return Hebrew.Month;
                case Calendars.Hijri: return Hijri.Month;
                case Calendars.Julian: return Julian.Month;
                case Calendars.Japanese: return Japanese.Month;
                case Calendars.Korean: return Korean.Month;
                case Calendars.Taiwan: return Taiwan.Month;
                case Calendars.KoreanLunisolar: return KoreanLunisolar.Month;
                case Calendars.TaiwanLunisolar: return TaiwanLunisolar.Month;
                case Calendars.JapaneseLunisolar: return JapaneseLunisolar.Month;
                case Calendars.ChineseLunisolar: return ChineseLunisolar.Month;
            }

            return 0;
        }
        public int Day(Calendars calendar)
        {
            switch (calendar)
            {
                case Calendars.Gregorian: return Gregorian.Day;
                case Calendars.Persian: return Persian.Day;
                case Calendars.Hebrew: return Hebrew.Day;
                case Calendars.Hijri: return Hijri.Day;
                case Calendars.Julian: return Julian.Day;
                case Calendars.Japanese: return Japanese.Day;
                case Calendars.Korean: return Korean.Day;
                case Calendars.Taiwan: return Taiwan.Day;
                case Calendars.KoreanLunisolar: return KoreanLunisolar.Day;
                case Calendars.TaiwanLunisolar: return TaiwanLunisolar.Day;
                case Calendars.JapaneseLunisolar: return JapaneseLunisolar.Day;
                case Calendars.ChineseLunisolar: return ChineseLunisolar.Day;
            }

            return 0;
        }
        public System.DayOfWeek DayOfWeek(Calendars calendar)
        {
            switch (calendar)
            {
                case Calendars.Gregorian: return Gregorian.DayOfWeek;
                case Calendars.Persian: return Persian.DayOfWeek;
                case Calendars.Hebrew: return Hebrew.DayOfWeek;
                case Calendars.Hijri: return Hijri.DayOfWeek;
                case Calendars.Julian: return Julian.DayOfWeek;
                case Calendars.Japanese: return Japanese.DayOfWeek;
                case Calendars.Korean: return Korean.DayOfWeek;
                case Calendars.Taiwan: return Taiwan.DayOfWeek;
                case Calendars.KoreanLunisolar: return KoreanLunisolar.DayOfWeek;
                case Calendars.TaiwanLunisolar: return TaiwanLunisolar.DayOfWeek;
                case Calendars.JapaneseLunisolar: return JapaneseLunisolar.DayOfWeek;
                case Calendars.ChineseLunisolar: return ChineseLunisolar.DayOfWeek;
            }

            return System.DayOfWeek.Saturday;
        }
        public int Hour(Calendars calendar)
        {
            switch (calendar)
            {
                case Calendars.Gregorian: return Gregorian.Hour;
                case Calendars.Persian: return Persian.Hour;
                case Calendars.Hebrew: return Hebrew.Hour;
                case Calendars.Hijri: return Hijri.Hour;
                case Calendars.Julian: return Julian.Hour;
                case Calendars.Japanese: return Japanese.Hour;
                case Calendars.Korean: return Korean.Hour;
                case Calendars.Taiwan: return Taiwan.Hour;
                case Calendars.KoreanLunisolar: return KoreanLunisolar.Hour;
                case Calendars.TaiwanLunisolar: return TaiwanLunisolar.Hour;
                case Calendars.JapaneseLunisolar: return JapaneseLunisolar.Hour;
                case Calendars.ChineseLunisolar: return ChineseLunisolar.Hour;
            }

            return 0;
        }
        public int Minute(Calendars calendar)
        {
            switch (calendar)
            {
                case Calendars.Gregorian: return Gregorian.Minute;
                case Calendars.Persian: return Persian.Minute;
                case Calendars.Hebrew: return Hebrew.Minute;
                case Calendars.Hijri: return Hijri.Minute;
                case Calendars.Julian: return Julian.Minute;
                case Calendars.Japanese: return Japanese.Minute;
                case Calendars.Korean: return Korean.Minute;
                case Calendars.Taiwan: return Taiwan.Minute;
                case Calendars.KoreanLunisolar: return KoreanLunisolar.Minute;
                case Calendars.TaiwanLunisolar: return TaiwanLunisolar.Minute;
                case Calendars.JapaneseLunisolar: return JapaneseLunisolar.Minute;
                case Calendars.ChineseLunisolar: return ChineseLunisolar.Minute;
            }

            return 0;
        }
        public int Second(Calendars calendar)
        {
            switch (calendar)
            {
                case Calendars.Gregorian: return Gregorian.Second;
                case Calendars.Persian: return Persian.Second;
                case Calendars.Hebrew: return Hebrew.Second;
                case Calendars.Hijri: return Hijri.Second;
                case Calendars.Julian: return Julian.Second;
                case Calendars.Japanese: return Japanese.Second;
                case Calendars.Korean: return Korean.Second;
                case Calendars.Taiwan: return Taiwan.Second;
                case Calendars.KoreanLunisolar: return KoreanLunisolar.Second;
                case Calendars.TaiwanLunisolar: return TaiwanLunisolar.Second;
                case Calendars.JapaneseLunisolar: return JapaneseLunisolar.Second;
                case Calendars.ChineseLunisolar: return ChineseLunisolar.Second;
            }

            return 0;
        }
        public int Millisecond(Calendars calendar)
        {
            switch (calendar)
            {
                case Calendars.Gregorian: return Gregorian.Millisecond;
                case Calendars.Persian: return Persian.Millisecond;
                case Calendars.Hebrew: return Hebrew.Millisecond;
                case Calendars.Hijri: return Hijri.Millisecond;
                case Calendars.Julian: return Julian.Millisecond;
                case Calendars.Japanese: return Japanese.Millisecond;
                case Calendars.Korean: return Korean.Millisecond;
                case Calendars.Taiwan: return Taiwan.Millisecond;
                case Calendars.KoreanLunisolar: return KoreanLunisolar.Millisecond;
                case Calendars.TaiwanLunisolar: return TaiwanLunisolar.Millisecond;
                case Calendars.JapaneseLunisolar: return JapaneseLunisolar.Millisecond;
                case Calendars.ChineseLunisolar: return ChineseLunisolar.Millisecond;
            }

            return 0;
        }
    }
}
