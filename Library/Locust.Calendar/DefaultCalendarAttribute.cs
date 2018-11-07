using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Calendar
{
    public enum Calendars
    {
        Gregorian,
        Persian,
        Hebrew,
        Hijri,
        Julian,
        Japanese,
        Korean,
        Taiwan,
        KoreanLunisolar,
        TaiwanLunisolar,
        JapaneseLunisolar,
        ChineseLunisolar
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DefaultCalendarAttribute:Attribute
    {
        public Calendars Value { get; set; }

        public DefaultCalendarAttribute(Calendars value)
        {
            this.Value = value;
        }
    }
}
