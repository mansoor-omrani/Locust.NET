using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;

namespace Locust.Shetab.ZarinPal
{
    [EnumDefault("Unknown")]
    public enum ZarinPalBankTranStatus
    {
        Unknown = 0,
        IncompletedData = -1,            // اطلاعات ارسال شده ناقص است.
        InvalidMerchant = -2,            // IP و يا مرچنت كد پذيرنده صحيح نيست.
        IncorrectAmount = -3,            // با توجه به محدوديت هاي شاپرك امكان پرداخت با رقم درخواست شده ميسر نمي باشد.
        LowerThanSilverMembership = -4,  // سطح تاييد پذيرنده پايين تر از سطح نقره اي است.
        RequestNotFound = -11,            // درخواست مورد نظر يافت نشد.
        CantEditRequest = -12,            // امكان ويرايش درخواست ميسر نمي باشد.
        TransactionHasNoFinancialOperation = -21,  // هيچ نوع عمليات مالي براي اين تراكنش يافت نشد.
        TransactionFailed = -22,                     // تراكنش نا موفق ميباشد.
        AmountMismatch = -33,                        // رقم تراكنش با رقم پرداخت شده مطابقت ندارد.
        TransactionRamificationExceeded = -34,       // سقف تقسيم تراكنش از لحاظ تعداد يا رقم عبور نموده است
        InvokeAccessDenied = -40,                    // اجازه دسترسي به متد مربوطه وجود ندارد.
        InvalidAdditionalData = -41,                 // اطلاعات ارسال شده مربوط به AdditionalData غيرمعتبر ميباشد.
        AuthorityTimeout = -42,                      // مدت زمان معتبر طول عمر شناسه پرداخت بايد بين 30 دقيه تا 45 روز مي باشد.
        RequestArchived = -54,                       // درخواست مورد نظر آرشيو شده است.
        Succeeded = 100,                            // عمليات با موفقيت انجام گرديده است.
        PaymentAlreadyVerified = 101                // عمليات پرداخت موفق بوده و قبلا PaymentVerification تراكنش انجام شده است.
    }
}
