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
        public static string NamePattern => @"^[\w\s\.\-_]+$";
        public static bool IsName(string x)
        {
            return Regex.IsMatch(x, NamePattern);
        }
        public static bool IsNameList(string names, string separator = ",")
        {
            var result = true;
            
            if (!string.IsNullOrEmpty(names))
            {
                var arr = names.Split(separator, MyStringSplitOptions.TrimAndRemoveEmptyEntries);

                foreach (var name in arr)
                {
                    if (!IsName(name))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
        public static bool IsEmail(string x, bool ignoreEmpty = true)
        {
            if (string.IsNullOrEmpty(x))
                return ignoreEmpty;
            else
                return Regex.IsMatch(x, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        public static bool IsMobile(string x, bool ignoreEmpty = true)
        {
            if (string.IsNullOrEmpty(x))
                return ignoreEmpty;
            else
                return Regex.IsMatch(x, @"^(0|(\+?\d{1,5}))?\s?\(?\d{3}\)?(-|\s)?\d{3}(-|\s)?\d{4}$", RegexOptions.IgnoreCase);
        }
        public static bool IsPhone(string x, bool ignoreEmpty = true)
        {
            if (string.IsNullOrEmpty(x))
                return ignoreEmpty;
            else
                return Regex.IsMatch(x, @"^(0|(\+?\d{1,5}))?\s?\(?\d{3}\)?(-|\s)?\d{3}(-|\s)?\d{4}$", RegexOptions.IgnoreCase);
        }
        public static bool IsDate(string x, bool ignoreEmpty = true)
        {
            if (string.IsNullOrEmpty(x))
                return ignoreEmpty;
            else
            {
                DateTime d;

                return DateTime.TryParse(x, out d);
            }
        }
        public static bool IsUserName(string x, byte minLength = 6, byte maxLength = 15, bool ignoreEmpty = true)
        {
            if (string.IsNullOrEmpty(x))
                return ignoreEmpty;
            else
                return Regex.IsMatch(x, $"^[a-zA-Z]\\w{{{minLength},{maxLength}}}$", RegexOptions.IgnoreCase);
        }
        public static bool IsPositiveInteger(string x)
        {
            x = x?.Trim();

            if (!string.IsNullOrEmpty(x))
            {
                return Regex.IsMatch(x, @"^\d+$");
            }

            return false;
        }
        public static bool IsNumeric(string x)
        {
            x = x?.Trim();

            if (!string.IsNullOrEmpty(x))
            {
                return Regex.IsMatch(x, @"^(-|\+)?[0-9]+(\.[0-9]+)?$");
            }

            return false;
        }
        public static bool IsInteger(string x)
        {
            x = x?.Trim();

            if (!string.IsNullOrEmpty(x))
            {
                return Regex.IsMatch(x, @"^(-|\+)?[0-9]+$");
            }

            return false;
        }
        public static IsNationalCodeResult IsNationalCode(string nationalCode)
        {
            nationalCode = nationalCode?.Trim();

            if (String.IsNullOrEmpty(nationalCode))
                return IsNationalCodeResult.NoCode;

            if (!(nationalCode.Length == 10 || nationalCode.Length == 11))
                return IsNationalCodeResult.IncorrectLength;

            if (!Regex.IsMatch(nationalCode, @"\d+"))
                return IsNationalCodeResult.NotNumeric;

            if (nationalCode.ToArray().All(c => c == nationalCode[0]))
                return IsNationalCodeResult.RepeatingDigit;

            if (nationalCode == "0123456789")
                return IsNationalCodeResult.Invalid;
            
            var check = nationalCode[nationalCode.Length - 1] - 48;

            if (nationalCode.Length == 10)
            {
                // real entities, individual persons
                
                var result = Enumerable.Range(0, nationalCode.Length - 1)
                    .Select(x => (nationalCode[x] - 48) * (10 - x))
                    .Sum() % 11;

                var remainder = result % 11;

                return (check == (remainder < 2 ? remainder : 11 - remainder)) ? IsNationalCodeResult.Valid : IsNationalCodeResult.Invalid;
            }
            else
            {
                // legal entities, legal persons, owner of companies
                
                var add = nationalCode[9] - 48 + 2;
                var sum = new int[] { 29, 27, 23, 19, 17, 29, 27, 23, 19, 17 }
                    .Select((x, index) => (nationalCode[index] - 48 + add) * x)
                    .Sum();

                var result = sum % 11;
                var remainder = result == 10 ? 0: result;

                return check == remainder ? IsNationalCodeResult.Valid: IsNationalCodeResult.Invalid;
            }
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
