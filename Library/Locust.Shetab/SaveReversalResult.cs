using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab
{
    public enum SaveReversalResult
    {
        None = 0,
        NoPaymentCode = 1,
        InvalidPaymentCode = 2,
        InconsistentBank = 3,
        IncorrectPayment = 4,
        Success = 5,
        Error = 6
    }
}
