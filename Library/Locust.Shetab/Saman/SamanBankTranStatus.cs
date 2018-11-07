using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;

namespace Locust.Shetab.Saman
{
    [EnumDefault("Unknown")]
    public enum SamanBankTranStatus
    {
        Successful = 0,
        Unknown = 1,
        ProcessingError = -1,
        InvalidInput = -3,
        MerchantAuthenticationFailed = -4,
        AlreadyReversed = -6,
        NoRefNum = -7,
        InputLengthOverflow = -8,
        InvalidCharInAmount = -9,
        RefNumNotBase64 = -10,
        InputLengthUnderflow = -11,
        AmountNegative = -12,
        ReverseAmountMismatch = -13,
        TranUndefined = -14,
        ReverseAmountIsFloat = -15,
        InternalError = -16,
        PartialReverseNotAllowed = -17,
        InvalidMerchantIP = -18,

        CanceledByUser = 20,
        InvalidAmount = 21,
        InvalidTransaction = 22,
        InvalidCardNumber = 23,
        NoSuchIssuer = 24,
        ExpiredCardPickUp = 25,
        AllowablePINTriesExceededPickUp = 26,
        IncorrectPIN = 27,
        ExceedsWithdrawalAmountLimit = 28,
        TransactionCannotBeCompleted = 29,
        ResponseReceivedTooLate = 30,
        SuspectedFraudPickUp = 31,
        NoSufficientFunds = 32,
        IssuerDownSlm = 33,
        TMEError = 34
    }
}
