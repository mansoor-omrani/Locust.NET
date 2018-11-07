using Locust.Language;
using Locust.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Measurement
{
    public enum TimeMeasurement
    {
        Auto,
        NanoSecond,
        MicroSecond,
        MilliSecond,
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year,
        Decade,
        Century,
        Millennium
    }
    public class TimeDifference
    {
        public ITranslator Translator { get; set; }
        public TimeDifference(ITranslator translator)
        {
            if (translator == null)
                throw new ArgumentNullException("translator");

            Translator = translator;
        }
        public string Difference(string lang, DateTime d1, DateTime d2, TimeMeasurement measurement = TimeMeasurement.Auto, bool ignoreMinor = true)
        {
            // WARNING: THIS METHOD IS INCOMPLETE. DO NOT USE IT.

            var result = "";
            var span = (d1 - d2);
            var _measurement = TimeMeasurement.Auto;

            if (measurement == TimeMeasurement.Auto)
            {
                if (span.TotalMilliseconds < 0.001)
                    _measurement = TimeMeasurement.NanoSecond;
                else if (span.TotalMilliseconds < 1)
                    _measurement = TimeMeasurement.MicroSecond;
                else if (span.TotalMilliseconds < 1000)
                    _measurement = TimeMeasurement.MilliSecond;
                else if (span.TotalSeconds < 60)
                    _measurement = TimeMeasurement.Second;
                else if (span.TotalMinutes < 60)
                    _measurement = TimeMeasurement.Minute;
                else if (span.TotalHours < 24)
                    _measurement = TimeMeasurement.Hour;
                else if (span.TotalDays < 7)
                    _measurement = TimeMeasurement.Day;
                else if (span.TotalDays < 30)
                    _measurement = TimeMeasurement.Week;
                else if (span.TotalDays < 365)
                    _measurement = TimeMeasurement.Month;
                else if (span.TotalDays < 3650)
                    _measurement = TimeMeasurement.Year;
                else if (span.TotalDays < 36500)
                    _measurement = TimeMeasurement.Decade;
                else if (span.TotalDays < 365000)
                    _measurement = TimeMeasurement.Century;
                else
                    _measurement = TimeMeasurement.Millennium;
            }
            else
            {
                _measurement = measurement;
            }

            int x = 0;
            int y = 0;
            int z = 0;

            switch (_measurement)
            {
                case TimeMeasurement.NanoSecond:
                    x = (int)(span.TotalMilliseconds * TimeSpan.TicksPerMillisecond);
                    result = x.ToString() + " " + Translator.GetSingle("measurement-unit", "Nano", lang) + " " + Translator.GetSingle("measurement-type-time", "second", lang);
                    break;
                case TimeMeasurement.MicroSecond:
                    x = (int)(span.TotalMilliseconds * 1000);
                    result = x.ToString() + " " + Translator.GetSingle("measurement-unit", "Micro", lang) + " " + Translator.GetSingle("measurement-type-time", "second", lang);
                    break;
                case TimeMeasurement.MilliSecond:
                    x = (int)(span.TotalMilliseconds);
                    result = x.ToString() + " " + Translator.GetSingle("measurement-unit", "Milli", lang) + " " + Translator.GetSingle("measurement-type-time", "second", lang);

                    if (!ignoreMinor)
                    {
                        y = (int)((span.TotalMilliseconds - Math.Floor(span.TotalMilliseconds)) * 1000);

                        if (y > 0)
                        {
                            result += " " + Translator.GetSingle("measurement-general", "and", lang) +
                                            " " + y + " " + Translator.GetSingle("measurement-unit", "Micro", lang) +
                                            " " + Translator.GetSingle("measurement-type-time", "second", lang);
                        }
                    }

                    break;
                case TimeMeasurement.Second:
                    x = (int)(span.TotalSeconds);
                    result = x.ToString() + " " + Translator.GetSingle("measurement-type-time", "Second", lang);

                    if (!ignoreMinor)
                    {
                        y = (int)((span.TotalSeconds - Math.Floor(span.TotalSeconds)) * 1000);

                        if (y > 0)
                        {
                            result += " " + Translator.GetSingle("measurement-general", "and", lang) +
                                            " " + y + " " + Translator.GetSingle("measurement-unit", "Milli", lang) +
                                            " " + Translator.GetSingle("measurement-type-time", "second", lang);
                        }
                    }

                    break;
                case TimeMeasurement.Minute:
                    x = (int)(span.TotalMinutes);
                    result = x.ToString() + " " + Translator.GetSingle("measurement-type-time", "Minute", lang);

                    if (!ignoreMinor)
                    {
                        y = (int)((span.TotalMinutes - Math.Floor(span.TotalMinutes)) * 60);

                        if (y > 0)
                        {
                            result += " " + Translator.GetSingle("measurement-general", "and", lang) +
                                      " " + y + " " + Translator.GetSingle("measurement-type-time", "second", lang);
                        }
                    }

                    break;
                case TimeMeasurement.Hour:
                    x = (int)(span.TotalHours);
                    result = x.ToString() + " " + Translator.GetSingle("measurement-type-time", "Hour", lang);

                    if (!ignoreMinor)
                    {
                        y = (int)((span.TotalHours - Math.Floor(span.TotalHours)) * 60);

                        if (y > 0)
                        {
                            result += " " + Translator.GetSingle("measurement-general", "and", lang) +
                                      " " + y + " " + Translator.GetSingle("measurement-type-time", "minute", lang);
                        }
                    }
                    break;
                case TimeMeasurement.Day:
                    x = (int)(span.TotalDays);
                    result = x.ToString() + " " + Translator.GetSingle("measurement-type-time", "Day", lang);

                    if (!ignoreMinor)
                    {
                        y = (int)((span.TotalDays - Math.Floor(span.TotalDays)) * 24);

                        if (y > 0)
                        {
                            result += " " + Translator.GetSingle("measurement-general", "and", lang) +
                                      " " + y + " " + Translator.GetSingle("measurement-type-time", "hour", lang);
                        }
                    }

                    break;
                case TimeMeasurement.Week:
                    x = (int)(Math.Floor(span.TotalDays / 7));
                    result = x.ToString() + " " + Translator.GetSingle("measurement-type-time", "Day", lang);

                    if (!ignoreMinor)
                    {
                        y = (int)(span.TotalDays - x * 7);

                        if (y > 0)
                        {
                            result += " " + Translator.GetSingle("measurement-general", "and", lang) +
                                      " " + y + " " + Translator.GetSingle("measurement-type-time", "day", lang);
                        }
                    }

                    break;
                case TimeMeasurement.Month:
                    x = (int)(Math.Floor(span.TotalDays / 30));
                    result = x.ToString() + " " + Translator.GetSingle("measurement-type-time", "Day", lang);

                    if (!ignoreMinor)
                    {
                        y = (int)(span.TotalDays - x * 30);

                        if (y > 0)
                        {
                            result += " " + Translator.GetSingle("measurement-general", "and", lang) +
                                      " " + y + " " + Translator.GetSingle("measurement-type-time", "week", lang);
                        }
                    }

                    break;
            }

            return result;
        }
    }
}
