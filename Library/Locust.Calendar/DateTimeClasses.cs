using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Calendar
{
    public class PersianDateValue : DateTimeValue
    {
        protected static readonly PersianCalendar calendar = new PersianCalendar();
        public PersianDateValue()
            : base(calendar, CalendarHelper.Persian)
        {
        }
    }
    public class GregorianDateValue : DateTimeValue
    {
        protected static readonly GregorianCalendar calendar = new GregorianCalendar();
        public GregorianDateValue()
            : base(calendar, CalendarHelper.Gregorian)
        {
        }
    }
    public class HebrewDateValue : DateTimeValue
    {
        protected static readonly HebrewCalendar calendar = new HebrewCalendar();
        public HebrewDateValue()
            : base(calendar, CalendarHelper.Hebrew)
        {

        }
    }
    public class JulianDateValue : DateTimeValue
    {
        protected static readonly JulianCalendar calendar = new JulianCalendar();
        public JulianDateValue()
            : base(calendar, CalendarHelper.Julian)
        {

        }
    }
    public class HijriDateValue : DateTimeValue
    {
        protected static readonly HijriCalendar calendar = new HijriCalendar();
        public HijriDateValue()
            : base(calendar, CalendarHelper.Hijri)
        {

        }
    }
    public class JapaneseDateValue : DateTimeValue
    {
        protected static readonly JapaneseCalendar calendar = new JapaneseCalendar();
        public JapaneseDateValue()
            : base(calendar, CalendarHelper.Julian)
        {

        }
    }
    public class KoreanDateValue : DateTimeValue
    {
        protected static readonly KoreanCalendar calendar = new KoreanCalendar();
        public KoreanDateValue()
            : base(calendar, CalendarHelper.Julian)
        {

        }
    }
    public class TaiwanDateValue : DateTimeValue
    {
        protected static readonly TaiwanCalendar calendar = new TaiwanCalendar();
        public TaiwanDateValue()
            : base(calendar, CalendarHelper.Julian)
        {

        }
    }
    public class KoreanLunisolarDateValue : DateTimeValue
    {
        protected static readonly KoreanLunisolarCalendar calendar = new KoreanLunisolarCalendar();
        public KoreanLunisolarDateValue()
            : base(calendar, CalendarHelper.Julian)
        {

        }
    }
    public class TaiwanLunisolarDateValue : DateTimeValue
    {
        protected static readonly TaiwanLunisolarCalendar calendar = new TaiwanLunisolarCalendar();
        public TaiwanLunisolarDateValue()
            : base(calendar, CalendarHelper.Julian)
        {
            
        }
    }
    public class JapaneseLunisolarDateValue : DateTimeValue
    {
        protected static readonly JapaneseLunisolarCalendar calendar = new JapaneseLunisolarCalendar();
        public JapaneseLunisolarDateValue()
            : base(calendar, CalendarHelper.Julian)
        {

        }
    }
    public class ChineseLunisolarDateValue : DateTimeValue
    {
        protected static readonly ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
        public ChineseLunisolarDateValue()
            : base(calendar, CalendarHelper.Julian)
        {

        }
    }
}
