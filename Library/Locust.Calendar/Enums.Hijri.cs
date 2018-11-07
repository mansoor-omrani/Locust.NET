using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Calendar
{
    public enum SeasonHijri
    {
        Unknown = -1, Rabi = 1, Sayf = 2, Kharif = 3, Shetaa = 4
    }
    public enum MonthHijri
    {
        Unknown = -1,
        Moharram = 1,
        Safar = 2,
        RabiolAvval = 3,
        RabioThani = 4,
        JamadelAvval = 5,
        JamadeThani = 6,
        Rajab = 7,
        Shaban = 8,
        Ramazan = 9,
        Shavval = 10,
        Zelghade = 11,
        Zelhadje = 12
    }
    public enum ShortMonthHijri
    {
        Unknown = -1,
        Moh = 1,
        Saf = 2,
        Ra = 3,
        Rth = 4,
        Ja = 5,
        Jth = 6,
        Raj = 7,
        Sha = 8,
        Ram = 9,
        Shav = 10,
        Zgh = 11,
        Zhj = 12
    }
    public enum WeekdayHijri
    {
        Unknown = -1,
        Sabt = 0,
        Ahad = 1,
        Ethnayn = 2,
        Thalatha = 3,
        Arbaa = 4,
        Khamis = 5,
        Jome = 6
    }
    public enum ShortWeekdayHijri
    {
        Unknown = -1,
        S = 0,
        H = 1,
        N = 2,
        Th = 3,
        R = 4,
        Kh = 5,
        J = 6
    }
}
