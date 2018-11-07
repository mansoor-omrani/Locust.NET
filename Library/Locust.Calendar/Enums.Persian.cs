using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Calendar
{
    public enum SeasonPersian
    {
        Unknown = -1, Bahar = 1, Tabestan = 2, Paeez = 3, Zemestan = 4
    }
    public enum MonthPersian
    {
        Unknown = -1,
        Farvardin = 1,
        Ordibehesht = 2,
        Khordad = 3,
        Tir = 4,
        Mordad = 5,
        Shahrivar = 6,
        Mehr = 7,
        Aban = 8,
        Azar = 9,
        Dei = 10,
        Bahman = 11,
        Esfand = 12
    }
    public enum ShortMonthPersian
    {
        Unknown = -1,
        Farvardin = 1,
        Ordibehesht = 2,
        Khordad = 3,
        Tir = 4,
        Mordad = 5,
        Shahrivar = 6,
        Mehr = 7,
        Aban = 8,
        Azar = 9,
        Dei = 10,
        Bahman = 11,
        Esfand = 12
    }
    public enum WeekdayPersian
    {
        Unknown = -1,
        Shanbeh = 0,
        Yekshanbeh = 1,
        Doshanbeh = 2,
        Seshanbeh = 3,
        Chaharshanbeh = 4,
        Panjshanbeh = 5,
        Jome = 6
    }
    public enum ShortWeekdayPersian
    {
        Unknown = -1,
        Sh = 0,
        Yek = 1,
        Do = 2,
        Se = 3,
        Cha = 4,
        Pan = 5,
        Jom = 6
    }
}
