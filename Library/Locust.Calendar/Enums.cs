using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Calendar
{
    public enum CalendarType
    {
        Persian,
        Gregorian,
        Hebrew,
        Julian,
        Hijri,
        Japanese,
        Korean,
        Taiwan,
        Chinese
    }
    public enum Season
    {
        Unknown = -1, First = 1, Second = 2, Third = 3, Fourth = 4
    }
    public enum Month
    {
        Unknown = -1,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
        Sixth = 6,
        Seventh = 7,
        Eigth = 8,
        Ninth = 9,
        Tenth = 10,
        Eleventh = 11,
        Twelfth = 12
    }
    public enum ShortMonth
    {
        Unknown = -1,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
        Sixth = 6,
        Seventh = 7,
        Eigth = 8,
        Ninth = 9,
        Tenth = 10,
        Eleventh = 11,
        Twelfth = 12
    }
    public enum Weekday
    {
        Unknown = -1,
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Fifth = 4,
        Sixth = 5,
        Seventh = 6
    }
    public enum ShortWeekday
    {
        Unknown = -1,
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Fifth = 4,
        Sixth = 5,
        Seventh = 6
    }
}
