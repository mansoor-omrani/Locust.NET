using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Calendar
{
    public sealed class ShortDateFormat
    {
        public string Mdyyyy { get { return "{M}/{d}/{yyyy}"; } }
        public string Mdyy { get { return "{M}/{d}/{yy}"; } }
        public string MMddyy { get { return "{MM}/{dd}/{yy}"; } }
        public string MMddyyyy { get { return "{MM}/{dd}/{yyyy}"; } }
        public string yyMd { get { return "{yy}/{M}/{d}"; } }
        public string yyMMdd { get { return "{yy}/{MM}/{dd}"; } }
        public string yyyyMMdd { get { return "{yyyy}/{MM}/{dd}"; } }
        public string yyyyMd { get { return "{yyyy}/{M}/{d}"; } }
        public string yyyyMMdd2 { get { return "{yyyy}-{MM}-{dd}"; } }
        public string ddMMMyy { get { return "{dd}-{MMM}-{yy}"; } }
    }
    public sealed class LongDateFormat
    {
        public string DayMonthddyyy { get { return "{dddd}, {MMMM} {dd}, {yyyy}"; } }
        public string Monthddyyyy { get { return "{MMMM} {dd}, {yyyy}"; } }
        public string DayddMonthyyyy { get { return "{dddd}, {dd} {MMMM}, {yyyy}"; } }
        public string ddMonthyyyy { get { return "{dd} {MMMM}, {yyyy}"; } }
    }
    public sealed class ShortTimeFormat
    {
        public string hmmtt { get { return "{h}:{mm} {tt}"; } }
        public string hmm { get { return "{h}:{mm}"; } }
        public string hhmmtt { get { return "{hh}:{mm} {tt}"; } }
        public string hhmm { get { return "{hh}:{mm}"; } }
        public string Hmm { get { return "{H}:{mm}"; } }
        public string HHmm { get { return "{HH}:{mm}"; } }
        public string Hmmtt { get { return "{H}:{mm} {tt}"; } }
        public string HHmmtt { get { return "{HH}:{mm} {tt}"; } }
    }
    public sealed class LongTimeFormat
    {
        public string hmmsstt { get { return "{h}:{mm}:{ss} {tt}"; } }
        public string hhmmsstt { get { return "{hh}:{mm}:{ss} {tt}"; } }
        public string Hmmss { get { return "{H}:{mm}:{ss}"; } }
        public string HHmmss { get { return "{HH}:{mm}:{ss}"; } }
        public string Hmmsstt { get { return "{H}:{mm}:{ss} {tt}"; } }
        public string HHmmsstt { get { return "{HH}:{mm}:{ss} {tt}"; } }
    }
    public static class DateTimeFormat
    {
        private static readonly ShortDateFormat _shortDateFormat;
        private static readonly LongDateFormat _longDateFormat;
        private static readonly ShortTimeFormat _shortTimeFormat;
        private static readonly LongTimeFormat _longTimeFormat;
        public static ShortDateFormat ShortDate
        {
            get
            {
                return _shortDateFormat;
            }
        }
        public static LongDateFormat LongDate
        {
            get
            {
                return _longDateFormat;
            }
        }
        public static ShortTimeFormat ShortTime
        {
            get
            {
                return _shortTimeFormat;
            }
        }
        public static LongTimeFormat LongTime
        {
            get
            {
                return _longTimeFormat;
            }
        }
        static DateTimeFormat()
        {
            _shortDateFormat = new ShortDateFormat();
            _longDateFormat = new LongDateFormat();
            _shortTimeFormat = new ShortTimeFormat();
            _longTimeFormat = new LongTimeFormat();
        }
    }
}
