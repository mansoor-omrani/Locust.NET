using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;

namespace Locust.Calendar
{
    public enum ParseDateTimeResult
    {
        None,
        Success,
        Unknown,
        NoDateGiven,
        InvalidDate,
        InvalidYear,
        InvalidMonth,
        InvalidDay,
        InvalidHour,
        InvalidMinute,
        InvalidSecond,
        InvalidMillisecond
    }

    public delegate void DateChangedEventHandler(DateTimeValue x);
    public class DateTimeValue
    {
        private readonly System.Globalization.Calendar _calendar;
        public System.Globalization.Calendar Calendar { get { return _calendar; } }
        private readonly CalendarHelper _baseCalendar;
        public CalendarHelper Helper { get { return _baseCalendar; } }
        public DateTimeValue(System.Globalization.Calendar calendar, CalendarHelper calendarHelper)
        {
            _calendar = calendar;
            _baseCalendar = calendarHelper;
            _date = DateTime.Now;
        }
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Second { get; private set; }
        public int Millisecond { get; private set; }
        public DateTime ToDateTime()
        {
            return _date;
        }
        protected bool ValidateYear(int year)
        {
            if (year <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected bool ValidateMonth(int month)
        {
            if (month <= 0 || month > 12)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected bool ValidateDay(int day)
        {
            if (day <= 0 || day > 31)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected bool ValidateHour(int hour)
        {
            if (hour > 23)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected bool ValidateMinute(int minute)
        {
            if (minute > 59)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected bool ValidateSecond(int second)
        {
            if (second > 59)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        protected bool ValidateMillisecond(int milli)
        {
            if (milli < 0 || milli > 999)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            return ToString(separator: '/', zeroFill: true);
        }
        public string ToString(char separator, bool zeroFill = true)
        {
            var result = "";

            if (zeroFill)
            {
                result = (new string('0', 4) + Year.ToString()).Right(4) + separator +
                    (new string('0', 2) + Month.ToString()).Right(2) + separator +
                    (new string('0', 2) + Day.ToString()).Right(2);
            }
            else
            {
                result = Year.ToString() + separator +
                    Month.ToString() + separator +
                    Day.ToString();
            }

            return result;
        }
        private DateTime _date;
        public event DateChangedEventHandler DateChanged = delegate(DateTimeValue value) { };
        public void Read(int year, int month = 1, int day = 1, int hour = 0, int minute = 0, int second = 0, int milli = 0)
        {
            _date = _calendar.ToDateTime(year, month, day, hour, minute, second, milli);

            Year = year;
            Month = month;
            Day = day;
            DayOfWeek = _calendar.GetDayOfWeek(_date);
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = milli;

            DateChanged(this);
        }
        public ParseDateTimeResult TryRead(int year, int month, int day = 1, int hour = 0, int minute = 0, int second = 0, int milli = 0)
        {
            ParseDateTimeResult result = ParseDateTimeResult.None;

            try
            {
                if (!ValidateYear(year))
                    result = ParseDateTimeResult.InvalidYear;
                else
                    if (!ValidateMonth(month))
                        result = ParseDateTimeResult.InvalidMonth;
                    else
                        if (!ValidateDay(day))
                            result = ParseDateTimeResult.InvalidDay;
                        else
                            if (!ValidateHour(hour))
                                result = ParseDateTimeResult.InvalidHour;
                            else
                                if (!ValidateMinute(minute))
                                    result = ParseDateTimeResult.InvalidMinute;
                                else
                                    if (!ValidateSecond(second))
                                        result = ParseDateTimeResult.InvalidSecond;
                                    else if (!ValidateMillisecond(milli))
                                        result = ParseDateTimeResult.InvalidMillisecond;
                                    else
                                    {
                                        Read(year, month, day, hour, minute, second, milli);

                                        result = ParseDateTimeResult.Success;
                                    }
            }
            catch (Exception e)
            {
                result = ParseDateTimeResult.InvalidDate;
            }

            return result;
        }
        public void Parse(string date, char separator = '/', bool reverse = false)
        {
            var parseResult = TryParse(date, separator, reverse);

            switch (parseResult)
            {
                case ParseDateTimeResult.Success: break;
                case ParseDateTimeResult.NoDateGiven: throw new ArgumentException("date");
                case ParseDateTimeResult.InvalidYear: throw new InvalidDataException("invalid year");
                case ParseDateTimeResult.InvalidMonth: throw new InvalidDataException("invalid month");
                case ParseDateTimeResult.InvalidDay: throw new InvalidDataException("invalid day");
                case ParseDateTimeResult.InvalidHour: throw new InvalidDataException("invalid hour");
                case ParseDateTimeResult.InvalidMinute: throw new InvalidDataException("invalid minute");
                case ParseDateTimeResult.InvalidSecond: throw new InvalidDataException("invalid second");
                case ParseDateTimeResult.InvalidMillisecond: throw new InvalidDataException("invalid millisecond");
                default: throw new InvalidDataException("invalid date");
            }
        }

        private ParseDateTimeResult ParseTimePart(string part, ref bool reverse, ref byte h, ref byte m, ref byte s, ref short MM, out string remaining)
        {
            var result = ParseDateTimeResult.Success;
            remaining = "";

            if (!string.IsNullOrEmpty(part))
            {
                var arr = part.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (arr.Length > 2)
                {
                    reverse = false;
                    remaining = arr[0];

                    if (!byte.TryParse(arr[1], out h))
                    {
                        result = ParseDateTimeResult.InvalidHour;
                        goto exit_parse_time;
                    }
                    if (!byte.TryParse(arr[2], out m))
                    {
                        result = ParseDateTimeResult.InvalidMinute;
                        goto exit_parse_time;
                    }

                    if (arr.Length > 3)
                    {
                        var dotIndex = arr[3].IndexOf('.');

                        if (dotIndex >= 0)
                        {
                            if (!byte.TryParse(arr[3].Substring(0, dotIndex), out s))
                            {
                                result = ParseDateTimeResult.InvalidSecond;
                                goto exit_parse_time;
                            }

                            if (dotIndex < arr[3].Length - 1)
                            {
                                if (!short.TryParse(arr[3].Substring(dotIndex + 1), out MM))
                                {
                                    result = ParseDateTimeResult.InvalidMillisecond;
                                    goto exit_parse_time;
                                }
                            }
                        }
                        else
                        {
                            if (!byte.TryParse(arr[3], out s))
                            {
                                result = ParseDateTimeResult.InvalidSecond;
                                goto exit_parse_time;
                            }
                        }
                    }
                }
                else
                {
                    remaining = arr[0];
                }
            }
        exit_parse_time:

            return result;
        }
        public ParseDateTimeResult TryParse(string date, char separator = '/', bool reverse = false)
        {
            var result = ParseDateTimeResult.None;

            if (string.IsNullOrEmpty(date) || string.IsNullOrWhiteSpace(date))
                result = ParseDateTimeResult.NoDateGiven;
            else
            {
                var arr = date.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                if (arr.Length == 3)
                {
                    byte h = 0;
                    byte m = 0;
                    byte s = 0;
                    short MM = 0;
                    var partWithTime = "";
                    var arr0HasTime = false;
                    var arr2HasTime = false;

                    if (arr[2].IndexOf(':') > 0)
                    {
                        arr2HasTime = true;
                        partWithTime = arr[2];
                    }
                    else
                        if (arr[0].IndexOf(':') > 0)
                        {
                            arr0HasTime = true;
                            partWithTime = arr[0];
                        }

                    var remaining = "";

                    if (arr0HasTime || arr2HasTime)
                    {
                        result = ParseTimePart(partWithTime, ref reverse, ref h, ref m, ref s, ref MM, out remaining);
                    }
                    else
                    {
                        result = ParseDateTimeResult.Success;
                    }

                    if (result == ParseDateTimeResult.Success)
                    {
                        if (!string.IsNullOrEmpty(remaining))
                        {
                            if (arr2HasTime)
                            {
                                arr[2] = remaining;
                            }
                            else if (arr0HasTime)
                            {
                                arr[0] = remaining;
                            }
                        }

                        var yy = 0;
                        var mm = 0;
                        var dd = 0;

                        if (reverse || (!string.IsNullOrEmpty(arr[2]) && !string.IsNullOrEmpty(arr[0]) && arr[2].Length > arr[0].Length))
                        {
                            if (!Int32.TryParse(arr[2], out yy))
                                result = ParseDateTimeResult.InvalidYear;

                            if (!Int32.TryParse(arr[1], out mm))
                                result = ParseDateTimeResult.InvalidMonth;

                            if (!Int32.TryParse(arr[0], out dd))
                                result = ParseDateTimeResult.InvalidDay;

                            if (result == ParseDateTimeResult.Success)
                            {
                                if (mm > 12)
                                {
                                    var temp = mm;
                                    mm = dd;
                                    dd = temp;
                                }

                                result = TryRead(yy, mm, dd, h, m, s, MM);
                            }
                        }
                        else
                        {
                            if (!Int32.TryParse(arr[0], out yy))
                                result = ParseDateTimeResult.InvalidYear;

                            if (!Int32.TryParse(arr[1], out mm))
                                result = ParseDateTimeResult.InvalidMonth;

                            if (!Int32.TryParse(arr[2], out dd))
                                result = ParseDateTimeResult.InvalidDay;

                            if (result == ParseDateTimeResult.Success)
                            {
                                result = TryRead(yy, mm, dd, h, m, s, MM);
                            }
                        }
                    }
                }
                else
                {
                    result = ParseDateTimeResult.InvalidDate;
                }
            }

            return result;
        }
        public void Read(DateTime date)
        {
            var year = _calendar.GetYear(date);
            var month = _calendar.GetMonth(date);
            var day = _calendar.GetDayOfMonth(date);

            Read(year, month, day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }

        
    }
}
