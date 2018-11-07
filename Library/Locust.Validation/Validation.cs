using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Locust.Extensions;

namespace Locust.Validation
{
    public enum IsNationalCodeResult
    {
        None,
        NoCode,
        IncorrectLength,
        NotNumeric,
        RepeatingDigit,
        Invalid,
        Valid
    }
    public class Validation
    {
        public static bool IsEmail(string x)
        {
            if (string.IsNullOrEmpty(x))
                return false;
            else
                return Regex.IsMatch(x, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        public static bool IsMobile(string x)
        {
            if (string.IsNullOrEmpty(x))
                return false;
            else
                return Regex.IsMatch(x, @"^(0|(\+?\d{1,5}))?\s?\(?\d{3}\)?(-|\s)?\d{3}(-|\s)?\d{4}$", RegexOptions.IgnoreCase);
        }
        public static bool IsUserName(string x, byte minLength = 6, byte maxLength = 15)
        {
            if (string.IsNullOrEmpty(x))
                return false;
            else
                return Regex.IsMatch(x, $"^[a-zA-Z]\\w{{{minLength},{maxLength}}}$", RegexOptions.IgnoreCase);
        }
        public static IsNationalCodeResult IsNationalCode(string nationalCode)
        {
            if (String.IsNullOrEmpty(nationalCode))
                return IsNationalCodeResult.NoCode;

            if (nationalCode.Length != 10)
                return IsNationalCodeResult.IncorrectLength;
            
            var regex = new Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
                return IsNationalCodeResult.NotNumeric;

            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode))
                return IsNationalCodeResult.RepeatingDigit;

            var check = Convert.ToInt32(nationalCode.Substring(9, 1));
            var result = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(nationalCode.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            var remainder = result % 11;

            return (check == (remainder < 2 ? remainder : 11 - remainder)) ? IsNationalCodeResult.Valid : IsNationalCodeResult.Invalid;
        }

        public static bool IsIPv4(string ip, bool mask = false)
        {
            var result = false;

            if (!string.IsNullOrEmpty(ip))
            {
                if (ip == "::1")
                {
                    ip = "127.0.0.1";
                }

                var arr = ip.Split(".", MyStringSplitOptions.TrimAndRemoveEmptyEntries);

                if (arr.Length > 0)
                {
                    var count = 0;

                    foreach (var part in arr)
                    {
                        byte x;

                        if (part != "*")
                        {
                            if (!byte.TryParse(part, out x))
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (!mask)
                                break;
                        }

                        count++;

                        if (count > 4)
                        {
                            break;
                        }
                    }

                    if (count == 4)
                    {
                        result = true;
                    }
                }
            }

            return result && ip.Count('.') == 3;
        }
    }
}