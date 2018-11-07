using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;

namespace Locust.Shetab
{
    public enum HttpMethod { Post, Get }
    [EnumDefault("Parsian")]
    public enum BankType
    {
        Unknown = 0,
        ZarinPal = 100,
        Parsian = 201,
        Saman = 202,
        Ayandeh = 203
        //Mellat = 204
    }
    public enum PaymentStatus
    {
        NotStarted = 0,
        Pending = 1,
        Faulted = 2,
        Finished = 3,
        InComplete = 4,
        Reversal = 5,
        Unknown = 6
    }
}
