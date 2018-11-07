using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Conversion;

namespace Locust.Measurement
{
    public enum TimeDurationUnit
    {
        Second,
        Minute,
        Hour,
    }
    public class TimeDurationValue
    {
        public double Value { get; set; }
        public TimeDurationUnit Unit { get; set; }
    }
    public class TimeDuration
    {
        private byte hour;
        private byte min;
        private double sec;
        private List<TimeDurationValue> calculatedDuration;
        public TimeDuration()
            : this(0)
        {
        }
        public TimeDuration(double duration)
        {
            this.calculatedDuration = new List<TimeDurationValue>();

            calculate(duration);
        }
        public TimeDuration(string duration)
        {
            this.calculatedDuration = new List<TimeDurationValue>();

            calculate(duration);
        }
        private void calculate(string duration)
        {
            hour = 0;
            min = 0;
            sec = 0;

            var arr = duration.Split(':');

            if (arr.Length == 1)
            {
                calculate(SafeClrConvert.ToDouble(arr[0]));

                return;
            }
            else if (arr.Length == 2)
            {
                hour = SafeClrConvert.ToByte(arr[0]);
                if (min > 23)
                    throw new ApplicationException("invalid hour: " + arr[0]);

                min = SafeClrConvert.ToByte(arr[1]);
                if (min > 59)
                    throw new ApplicationException("invalid minute: " + arr[1]);
            }
            else if (arr.Length == 3)
            {
                hour = SafeClrConvert.ToByte(arr[0]);
                if (min > 23)
                    throw new ApplicationException("invalid hour: " + arr[0]);

                min = SafeClrConvert.ToByte(arr[1]);
                if (min > 59)
                    throw new ApplicationException("invalid minute: " + arr[1]);

                sec = SafeClrConvert.ToByte(arr[2]);
                if (sec > 59)
                    throw new ApplicationException("invalid second: " + arr[2]);
            }
            else
            {
                throw new ApplicationException("invalid argument");
            }

            this.calculatedDuration.Clear();

            if (hour > 0)
                this.calculatedDuration.Add(new TimeDurationValue { Value = hour, Unit = TimeDurationUnit.Hour });
            if (min > 0 || hour > 0)
                this.calculatedDuration.Add(new TimeDurationValue { Value = min, Unit = TimeDurationUnit.Minute });
            if (sec > 0 || min > 0 || hour > 0)
                this.calculatedDuration.Add(new TimeDurationValue { Value = sec, Unit = TimeDurationUnit.Second });
        }
        private void calculate(double duration)
        {
            hour = 0;
            min = 0;
            sec = 0;

            if (duration < 60)
            {
                sec = duration;
            }
            else if (duration < 3600)
            {
                min = (byte)Math.Floor(duration / 60);
                sec = duration - min * 60;
            }
            else if (duration < 86400)
            {
                hour = (byte)Math.Floor(duration / 3600);
                min = (byte)Math.Floor((duration - hour * 3600) / 60);
                sec = duration - hour * 3600 - min * 60;
            }
            else
            {
                throw new ApplicationException("invalid argument");
            }

            this.calculatedDuration.Clear();

            if (hour > 0)
                this.calculatedDuration.Add(new TimeDurationValue { Value = hour, Unit = TimeDurationUnit.Hour });
            if (min > 0 || hour > 0)
                this.calculatedDuration.Add(new TimeDurationValue { Value = min, Unit = TimeDurationUnit.Minute });
            if (sec > 0 || min > 0 || hour > 0)
                this.calculatedDuration.Add(new TimeDurationValue { Value = sec, Unit = TimeDurationUnit.Second });
        }
        public byte Hour
        {
            get { return hour; }
            set
            {
                if (value < 0 || value > 23)
                    throw new ApplicationException("invalid hour");

                hour = value;

                if (hour == 0)
                {
                    if (this.calculatedDuration.Count > 2)
                    {
                        this.calculatedDuration.RemoveAt(0);
                    }
                }
                else
                {
                    if (this.calculatedDuration.Count < 3)
                    {
                        if (this.calculatedDuration.Count < 2)
                        {
                            this.calculatedDuration.Insert(0, new TimeDurationValue { Value = min, Unit = TimeDurationUnit.Minute });
                        }
                        this.calculatedDuration.Insert(0, new TimeDurationValue { Value = hour, Unit = TimeDurationUnit.Hour });
                    }
                    else
                    {
                        this.calculatedDuration[0].Value = hour;
                    }
                }
            }
        }
        public byte Minute
        {
            get { return min; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ApplicationException("invalid minute");

                min = value;

                if (min == 0 && this.calculatedDuration.Count == 2)
                {
                    this.calculatedDuration.RemoveAt(0);
                }
                else
                {
                    if (this.calculatedDuration.Count < 2)
                    {
                        this.calculatedDuration.Insert(0, new TimeDurationValue { Value = min, Unit = TimeDurationUnit.Minute });
                    }
                    else if (this.calculatedDuration.Count == 2)
                    {
                        this.calculatedDuration[0].Value = min;
                    }
                    else
                    {
                        this.calculatedDuration[1].Value = min;
                    }
                }
            }
        }
        public double Second
        {
            get { return sec; }
            set
            {
                if (value < 0 || value > 59)
                    throw new ApplicationException("invalid second");

                sec = value;

                if (sec == 0 && this.calculatedDuration.Count == 1)
                {
                    this.calculatedDuration.RemoveAt(0);
                }
                else
                {
                    if (this.calculatedDuration.Count < 1)
                    {
                        this.calculatedDuration.Insert(0, new TimeDurationValue { Value = sec, Unit = TimeDurationUnit.Second });
                    }
                    else if (this.calculatedDuration.Count == 1)
                    {
                        this.calculatedDuration[0].Value = sec;
                    }
                    else if (this.calculatedDuration.Count == 2)
                    {
                        this.calculatedDuration[1].Value = sec;
                    }
                    else
                    {
                        this.calculatedDuration[3].Value = sec;
                    }
                }
            }
        }
        public void SetDuration(string duration)
        {
            calculate(duration);
        }
        public void SetDuration(double duration)
        {
            calculate(duration);
        }
        public double GetDuration()
        {
            var result = hour * 3600 + min * 60 + sec;

            return result;
        }
        public List<TimeDurationValue> Render(bool IgnoreSeconds = true)
        {
            List<TimeDurationValue> result;

            if (IgnoreSeconds)
                result = calculatedDuration.Where(tdv => tdv.Unit != TimeDurationUnit.Second).ToList();
            else
                result = calculatedDuration;

            return result;
        }
    }
}
