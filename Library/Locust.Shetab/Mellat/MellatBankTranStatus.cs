using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Mellat
{
    public enum MellatBankTranStatus
    {
        Successful = 0,
        //تراكنش با موفقيت انجام شد 0
        InvalidCardNo = 11,
        //شماره كارت نامعتبر است 11
        InsufficientDeposit = 12,
        //موجودي كافي نيست 12
        IncorrectPass = 13,
        //رمز نادرست است 13
        TryPassExceeded = 14,
        //تعداد دفعات وارد كردن رمز بيش از حد مجاز است 14
        InvalidCard = 15,
        //كارت نامعتبر است 15
        PurchaseTimeExceeded = 16,
        //دفعات برداشت وجه بيش از حد مجاز است 16
        UserCanceled = 17,
        //كاربر از انجام تراكنش منصرف شده است 17
        ExpiredCard = 18,
        //تاريخ انقضاي كارت گذشته است 18
        PurchaseAmountExceeded = 19,
        //مبلغ برداشت وجه بيش از حد مجاز است 19
        CardIssuerInvalid = 111,
        //صادر كننده كارت نامعتبر است 111
        CardIssuerSwitchError = 112,
        //خطاي سوييچ صادر كننده كارت 112
        CardIssuerNotResponded = 113,
        //پاسخي از صادر كننده كارت دريافت نشد 113
        CardOwnerNotAllowedToDoThisTran = 114,
        //دارنده كارت مجاز به انجام اين تراكنش نيست 114
        InvalidSeller = 21,
        //پذيرنده نامعتبر است 21
        SecurityError = 23,
        //خطاي امنيتي رخ داده است 23
        SellerUserInfoInvalid = 24,
        //اطلاعات كاربري پذيرنده نامعتبر است 24
        InvalidAmount = 25,
        //مبلغ نامعتبر است 25
        InvalidResponse = 31,
        //پاسخ نامعتبر است 31
        InputDataHasIncorrectFormat = 32,
        //فرمت اطلاعات وارد شده صحيح نمي باشد 32
        InvalidAccount = 33,
        //حساب نامعتبر است 33
        SystemError = 34,
        //خطاي سيستمي 34
        InvalidDate = 35,
        //تاريخ نامعتبر است 35
        RedundantRequestCode = 41,
        //شماره درخواست تكراري است 41
        SaleTranNotFound = 42,
        //يافت نشد 42 Sale تراكنش
        VerifyRequestAlreadyGiven = 43,
        //داده شده است 43 Verify قبلا درخواست
        VerifyRequestNotFound = 44,
        //يافت نشد 44 Verfiy درخواست
        TranSettled = 45,
        //شده است 45 Settle تراكنش
        TranNotSettled = 46,
        //نشده است 46 Settle تراكنش
        SettledTranNotFound = 47,
        //يافت نشد 47 Settle تراكنش
        TranReversed = 48,
        //شده است 48 Reverse تراكنش
        RefundTranNotFound = 49,
        //يافت نشد 49 Refund تراكنش
        BillNoIncorrect = 412,
        //شناسه قبض نادرست است 412
        PaymentNoIncorrect = 413,
        //شناسه پرداخت نادرست است 413
        BillIssuerInvalid = 414,
        //سازمان صادر كننده قبض نامعتبر است 414
        SessionHasEnded = 415,
        //زمان جلسه كاري به پايان رسيده است 415
        DataEntryError = 416,
        //خطا در ثبت اطلاعات 416
        PayerIdIncorrect = 417,
        //شناسه پرداخت كننده نامعتبر است 417
        ErrorInDefineCustomerInfo = 418,
        //اشكال در تعريف اطلاعات مشتري 418
        DataEntryTimeExceeded = 419,
        //تعداد دفعات ورود اطلاعات از حد مجاز گذشته است 419
        InvalidIP = 421,
        //نامعتبر است 421 IP
        RedundantTran = 51,
        //تراكنش تكراري است 51
        ReferenceTranNotAvailable = 54,
        //تراكنش مرجع موجود نيست 54
        InvalidTran = 55,
        //تراكنش نامعتبر است 55
        MoneyTransferError = 61,
        //خطا در واريز 61
        Unknown = 999
    }
}
