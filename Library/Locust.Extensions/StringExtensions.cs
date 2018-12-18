using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Locust.Base;
using Locust.Collections;
using System.Globalization;

namespace Locust.Extensions
{
    public enum MyStringSplitOptions
    {
        None = 0,
        RemoveEmptyEntries = 1,
        TrimEntries = 2,
        TrimAndRemoveEmptyEntries = 3,
        ToLowerEntries = 4,
        TrimToLowerAndRemoveEmptyEntries = 5,
        ToUpperEntries = 6,
        TrimToUpperAndRemoveEmptyEntries = 7
    }

    public static class StringHelper
    {
        public static bool IsEmpty(object x)
        {
            bool? result = null;
            var s = "";

            try
            {
                if (x is string)
                {
                    s = x as string;
                    result = string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
                }
                else
                {
                    result = DBNull.Value.Equals(x) || x == null;
                }
            }
            finally
            {
                if (result == null)
                {
                    result = true;
                }
            }

            return result.Value;
        }
        public static bool IsNullOrEmpty(string x)
        {
            var result = true;
            var s = "";

            try
            {
                result = string.IsNullOrEmpty(s);
            }
            finally
            {
                result = false;
            }

            return result;
        }

        public static string[] SplitLow(string s, char ch)
        {
            if (!IsEmpty(s))
                return s.SplitLow(ch);
            else
                return new string[] { };
        }

        public static string[] SplitUp(string s, char ch)
        {
            if (!IsEmpty(s))
                return s.SplitUp(ch);
            else
                return new string[] { };
        }

        public static string[] Split(string s, char ch, MyStringSplitOptions options)
        {
            if (!IsEmpty(s))
                return s.Split(ch, options);
            else
                return new string[] { };
        }
        public static string[] Split(string s, string separator, MyStringSplitOptions options)
        {
            if (!IsEmpty(s))
                return s.Split(separator, options);
            else
                return new string[] { };
        }
        public static string ChangeCase(string s)
        {
            if (!IsEmpty(s))
                return s.ChangeCase();
            else
                return "";
        }

        public static string Decapitalize(string s)
        {
            if (!IsEmpty(s))
                return s.Decapitalize();
            else
                return "";
        }

        public static string Capitalize(string s)
        {
            if (!IsEmpty(s))
                return s.Capitalize();
            else
                return "";
        }

        public static bool IsNumeric(string s)
        {
            if (!IsEmpty(s))
                return s.IsNumeric();
            else
                return false;
        }

        public static string Right(string s, int n)
        {
            if (!IsEmpty(s))
                return s.Right(n);
            else
                return "";
        }

        public static string Left(string s, int n)
        {
            if (!IsEmpty(s))
                return s.Left(n);
            else
                return "";
        }

        public static char CharAt(string s, int n)
        {
            if (!IsEmpty(s))
                return s.CharAt(n);
            else
                throw new ArgumentOutOfRangeException("n");
        }

        public static byte[] ToByteArray(string s, Encoding encoding)
        {
            if (!IsEmpty(s))
                return s.ToByteArray(encoding);
            else
                return new byte[] { };
        }
        public static byte[] ToByteArray(string s, string encoding)
        {
            if (!IsEmpty(s))
                return s.ToByteArray(encoding);
            else
                return new byte[] { };
        }
    }
    public static partial class StringExtensions
    {
        public static byte[] ToByteArray(this string str, string encoding)
        {
            Encoding e;

            if (string.Compare(encoding, "ascii", true) == 0)
            {
                e = Encoding.ASCII;
            }
            else
            {
                if (string.Compare(encoding, "utf8", true) == 0)
                {
                    e = Encoding.UTF8;
                }
                else
                {
                    if (string.Compare(encoding, "utf7", true) == 0)
                    {
                        e = Encoding.UTF7;
                    }
                    else
                    {
                        if (string.Compare(encoding, "utf32", true) == 0)
                        {
                            e = Encoding.UTF32;
                        }
                        else
                        {
                            e = Encoding.UTF8;
                        }
                    }
                }
            }

            return e.GetBytes(str);
        }
        public static byte[] ToByteArray(this string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        public static char CharAt(this string s, int n)
        {
            return s[n];
        }
        public static string Left(this string s, int n)
        {
            var result = "";
            if (s.Length > 0 && n <= s.Length)
                result = s.Substring(0, n);
            else if (n > s.Length)
                result = s;
            return result;
        }
        public static string Right(this string s, int n)
        {
            var result = "";
            if (s.Length > 0 && s.Length - n >= 0)
                result = s.Substring(s.Length - n, n);
            else if (n > s.Length)
                result = s;
            return result;
        }
        public static bool IsNumeric(this string s)
        {
            double Result;
            return double.TryParse(s, out Result);
        }
        public static string Capitalize(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    var arr = s.Split(' ');
                    var sb = new StringBuilder();
                    var cnt = 0;
                    foreach (var item in arr)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (Char.IsLower(item[0]))
                            {
                                sb.Append(((cnt > 0) ? " " : "") + Char.ToUpper(item[0]) + item.Substring(1));
                            }
                            else
                            {
                                sb.Append(((cnt > 0) ? " " : "") + item);
                            }
                        }
                        else
                        {
                            sb.Append(' ');
                        }

                        cnt++;
                    }

                    return sb.ToString();
                }
                else
                {
                    return s;
                }
            }
            else
            {
                return s;
            }
        }
        public static string Decapitalize(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    var arr = s.Split(' ');
                    var sb = new StringBuilder();
                    var cnt = 0;
                    foreach (var item in arr)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            if (Char.IsUpper(item[0]))
                            {
                                sb.Append(((cnt > 0) ? " " : "") + Char.ToLower(item[0]) + item.Substring(1));
                            }
                            else
                            {
                                sb.Append(((cnt > 0) ? " " : "") + item);
                            }
                        }
                        else
                        {
                            sb.Append(' ');
                        }

                        cnt++;
                    }

                    return sb.ToString();
                }
                else
                {
                    return s;
                }
            }
            else
            {
                return s;
            }
        }
        public static string ChangeCase(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    var arr = new Char[s.Length];

                    for (var i = 0; i < s.Length; i++)
                    {
                        if (Char.IsLetter(s[i]))
                        {
                            if (Char.IsLower(s[i]))
                            {
                                arr[i] = Char.ToUpper(s[i]);
                            }
                            else
                                if (Char.IsUpper(s[i]))
                                {
                                    arr[i] = Char.ToLower(s[i]);
                                }
                                else
                                {
                                    arr[i] = s[i];
                                }
                        }
                        else
                        {
                            arr[i] = s[i];
                        }
                    }

                    return new string(arr);
                }
                else
                {
                    return s;
                }
            }
            else
            {
                return s;
            }
        }
        public static string[] Split(this string s, char ch, Func<string, string> tran, bool ignoreEmptyEntries = false)
        {
            var x = s.Split(ch);
            var l = new List<string>();

            foreach (var y in x)
            {
                var z = tran(y);

                if (!ignoreEmptyEntries || (ignoreEmptyEntries && !string.IsNullOrEmpty(z)))
                {
                    l.Add(z);
                }
            }

            return l.ToArray();
        }
        public static string[] Split(this string s, string separator, Func<string, string> tran, bool ignoreEmptyEntries = false)
        {
            var x = s.Split(new string[]{separator},StringSplitOptions.None);
            var l = new List<string>();

            foreach (var y in x)
            {
                var z = tran(y);

                if (!ignoreEmptyEntries || (ignoreEmptyEntries && !string.IsNullOrEmpty(z)))
                {
                    l.Add(z);
                }
            }

            return l.ToArray();
        }
        public static string[] SplitLow(this string s, char ch)
        {
            return s.Split(ch, MyStringSplitOptions.TrimToLowerAndRemoveEmptyEntries);
        }
        public static string[] SplitUp(this string s, char ch)
        {
            return s.Split(ch, MyStringSplitOptions.TrimToUpperAndRemoveEmptyEntries);
        }
        public static string[] Split(this string s, char ch, MyStringSplitOptions options)
        {
            var result = new string[] { };

            switch (options)
            {
                case MyStringSplitOptions.None:
                    result = s.Split(new char[] { ch }, StringSplitOptions.None);
                    break;
                case MyStringSplitOptions.RemoveEmptyEntries:
                    result = s.Split(new char[] { ch }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case MyStringSplitOptions.TrimEntries:
                    result = s.Split(ch, x => x.Trim());
                    break;
                case MyStringSplitOptions.TrimAndRemoveEmptyEntries:
                    result = s.Split(ch, x => x.Trim(), true);
                    break;
                case MyStringSplitOptions.ToLowerEntries:
                    result = s.Split(ch, x => x.ToLower());
                    break;
                case MyStringSplitOptions.ToUpperEntries:
                    result = s.Split(ch, x => x.ToUpper());
                    break;
                case MyStringSplitOptions.TrimToLowerAndRemoveEmptyEntries:
                    result = s.Split(ch, x => x.ToLower(), true);
                    break;
                case MyStringSplitOptions.TrimToUpperAndRemoveEmptyEntries:
                    result = s.Split(ch, x => x.ToUpper(), true);
                    break;
            }

            return result;
        }
        public static string[] Split(this string s, string separator, MyStringSplitOptions options)
        {
            var result = new string[] { };

            switch (options)
            {
                case MyStringSplitOptions.None:
                    result = s.Split(new string[] { separator }, StringSplitOptions.None);
                    break;
                case MyStringSplitOptions.RemoveEmptyEntries:
                    result = s.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case MyStringSplitOptions.TrimEntries:
                    result = s.Split(separator, x => x.Trim());
                    break;
                case MyStringSplitOptions.TrimAndRemoveEmptyEntries:
                    result = s.Split(separator, x => x.Trim(), true);
                    break;
                case MyStringSplitOptions.ToLowerEntries:
                    result = s.Split(separator, x => x.ToLower());
                    break;
                case MyStringSplitOptions.ToUpperEntries:
                    result = s.Split(separator, x => x.ToUpper());
                    break;
                case MyStringSplitOptions.TrimToLowerAndRemoveEmptyEntries:
                    result = s.Split(separator, x => x.ToLower(), true);
                    break;
                case MyStringSplitOptions.TrimToUpperAndRemoveEmptyEntries:
                    result = s.Split(separator, x => x.ToUpper(), true);
                    break;
            }

            return result;
        }
        // source: https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
        public static string Reverse(this string s)
        {
            var arr = s.ToCharArray();

            Array.Reverse(arr);

            return new string(arr);
        }

        public static void Print(this string s, params object[] args)
        {
            System.Console.Write(s, args);
        }
        public static void PrintLine(this string s, params object[] args)
        {
            System.Console.WriteLine(s, args);
        }
        public static int Count(this string s, char ch)
        {
            return s.Count(x => x == ch);
        }
        public static int Count(this string s, string tofind)
        {
            return s.Split(tofind, MyStringSplitOptions.None).Length - 1;
        }
        public static string Format(this string s, params object[] args)
        {
            return string.Format(s, args);
        }
        public static string Substr(this string s, int start, int length = 0)
        {
            var result = "";

            if (!string.IsNullOrEmpty(s))
            {
                var i = start < 0 ? 0 : start >= s.Length ? s.Length - 1 : start;
                var len = length <= 0 || i + length > s.Length ? s.Length - i : length;

                if (len > 0)
                {
                    result = s.Substring(i, len);
                }
            }

            return result;
        }
        public static string UnCamel(this string s, char separator = '-', int buffersize = 16)
        {
            var buff = new CharBuffer(buffersize);

            foreach (var ch in s)
            {
                if (char.IsUpper(ch))
                {
                    buff.Append(separator);
                    buff.Append((char)(ch + 32));
                }
                else
                {
                    buff.Append(ch);
                }
            }

            return buff.ToString();
        }
        public static string UnCamel(this string s, Func<char, bool> fnDashLow, char separator = '-', int buffersize = 16)
        {
            var buff = new CharBuffer(buffersize);

            foreach (var ch in s)
            {
                if (fnDashLow(ch))
                {
                    buff.Append(separator);
                    buff.Append((char)(ch + 32));
                }
                else
                {
                    buff.Append(ch);
                }
            }

            return buff.ToString();
        }
        public static string Camel(this string s, char separator = '-', bool ignoreSingles = true, int buffersize = 16)
        {
            var buff = new CharBuffer(buffersize);
            var i = 0;

            while (i < s.Length)
            {
                var ch = s[i];

                if (ch == separator)
                {
                    if (i < s.Length - 1)
                    {
                        if (char.IsLower(s[i + 1]))
                        {
                            buff.Append((char)(s[i + 1] - 32));
                            i = i + 2;
                            continue;
                        }
                    }

                    if (!ignoreSingles)
                    {
                        buff.Append(ch);
                    }
                }
                else
                {
                    buff.Append(ch);
                }

                i++;
            }

            return buff.ToString();
        }
        #region In()
        public static bool In(this string s, IEnumerable<string> arr)
        {
            var result = false;

            foreach (var item in arr)
            {
                if (string.Compare(s, item) == 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public static string Map(this string s, string sourceValues, string targetValues, string @default = "")
        {
            var result = @default;
            var source = sourceValues.Split(',', MyStringSplitOptions.TrimAndRemoveEmptyEntries);
            var target = targetValues.Split(',', MyStringSplitOptions.TrimAndRemoveEmptyEntries);

            if (source.Length > 0 && source.Length == target.Length)
            {
                for (var i = 0; i < source.Length; i++)
                {
                    if (string.Compare(s, source[i], true) == 0)
                    {
                        result = target[i];
                        break;
                    }
                }
            }
            
            return result;
        }
        public static bool In(this string s, string values)
        {
            return s.In(values, true, ',', MyStringSplitOptions.TrimToLowerAndRemoveEmptyEntries);
        }
        public static bool In(this string s, string values, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.In(arr);
        }
        public static bool In(this string s, IEnumerable<string> arr, StringComparison comparisonType)
        {
            var result = false;

            foreach (var item in arr)
            {
                if (string.Compare(s, item, comparisonType) == 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public static bool In(this string s, string values, StringComparison comparisonType, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.In(arr, comparisonType);
        }
        public static bool In(this string s, IEnumerable<string> arr, bool ignoreCase)
        {
            var result = false;

            foreach (var item in arr)
            {
                if (string.Compare(s, item, ignoreCase) == 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public static bool In(this string s, string values, bool ignoreCase, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.In(arr, ignoreCase);
        }
        public static bool In(this string s, IEnumerable<string> arr, bool ignoreCase, CultureInfo culture)
        {
            var result = false;

            foreach (var item in arr)
            {
                if (string.Compare(s, item, ignoreCase, culture) == 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public static bool In(this string s, string values, bool ignoreCase, CultureInfo culture, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.In(arr, ignoreCase, culture);
        }
        public static bool In(this string s, IEnumerable<string> arr, CultureInfo culture, CompareOptions options)
        {
            var result = false;

            foreach (var item in arr)
            {
                if (string.Compare(s, item, culture, options) == 0)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public static bool In(this string s, string values, CultureInfo culture, CompareOptions compareOptions, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.In(arr, culture, compareOptions);
        }
        #endregion
        #region NotIn()
        public static bool NotIn(this string s, IEnumerable<string> arr)
        {
            return !s.In(arr);
        }
        public static bool NotIn(this string s, string values)
        {
            return s.NotIn(values, true, ',', MyStringSplitOptions.TrimToLowerAndRemoveEmptyEntries);
        }
        public static bool NotIn(this string s, string values, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.NotIn(arr);
        }
        public static bool NotIn(this string s, IEnumerable<string> arr, StringComparison comparisonType)
        {
            return !s.In(arr, comparisonType);
        }
        public static bool NotIn(this string s, string values, StringComparison comparisonType, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.NotIn(arr, comparisonType);
        }
        public static bool NotIn(this string s, IEnumerable<string> arr, bool ignoreCase)
        {
            return !s.In(arr, ignoreCase);
        }
        public static bool NotIn(this string s, string values, bool ignoreCase, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.NotIn(arr, ignoreCase);
        }
        public static bool NotIn(this string s, IEnumerable<string> arr, bool ignoreCase, CultureInfo culture)
        {
            return !s.In(arr, ignoreCase, culture);
        }
        public static bool NotIn(this string s, string values, bool ignoreCase, CultureInfo culture, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.NotIn(arr, ignoreCase, culture);
        }
        public static bool NotIn(this string s, IEnumerable<string> arr, CultureInfo culture, CompareOptions options)
        {
            return !s.In(arr, culture, options);
        }
        public static bool NotIn(this string s, string values, CultureInfo culture, CompareOptions compareOptions, char separator, MyStringSplitOptions options = MyStringSplitOptions.TrimAndRemoveEmptyEntries)
        {
            var arr = values?.Split(separator, options) ?? new string[] { };

            return s.NotIn(arr, culture, compareOptions);
        }
        #endregion
        #region Compare()
        public static int CompareCurrentCulture(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.CurrentCulture);
        }
        public static int CompareCurrentCultureIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.CurrentCultureIgnoreCase);
        }
        public static int CompareInvariantCulture(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.InvariantCulture);
        }
        public static int CompareInvariantCultureIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.InvariantCultureIgnoreCase);
        }
        public static int CompareOrdinal(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.Ordinal);
        }
        public static int CompareOrdinalIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.OrdinalIgnoreCase);
        }
        public static int CompareIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, ignoreCase: true);
        }
        public static int CompareTrimmedCurrentCulture(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.CurrentCulture);
        }
        public static int CompareTrimmedCurrentCultureIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }
        public static int CompareTrimmedInvariantCulture(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.InvariantCulture);
        }
        public static int CompareTrimmedInvariantCultureIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        public static int CompareTrimmedOrdinal(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.Ordinal);
        }
        public static int CompareTrimmedOrdinalIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.OrdinalIgnoreCase);
        }
        public static int CompareTrimmedIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), ignoreCase: true);
        }
        #endregion
        #region Equals
        public static bool EqualsOnCurrentCulture(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.CurrentCulture) == 0;
        }
        public static bool EqualsOnCurrentCultureIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.CurrentCultureIgnoreCase) == 0;
        }
        public static bool EqualsOnInvariantCulture(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.InvariantCulture) == 0;
        }
        public static bool EqualsOnInvariantCultureIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
        public static bool EqualsOnOrdinal(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.Ordinal) == 0;
        }
        public static bool EqualsOnOrdinalIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, StringComparison.OrdinalIgnoreCase) == 0;
        }
        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1, s2, ignoreCase: true) == 0;
        }
        public static bool EqualsTrimmedOnCurrentCulture(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.CurrentCulture) == 0;
        }
        public static bool EqualsTrimmedOnCurrentCultureIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.CurrentCultureIgnoreCase) == 0;
        }
        public static bool EqualsTrimmedOnInvariantCulture(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.InvariantCulture) == 0;
        }
        public static bool EqualsTrimmedOnInvariantCultureIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.InvariantCultureIgnoreCase) == 0;
        }
        public static bool EqualsTrimmedOnOrdinal(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.Ordinal) == 0;
        }
        public static bool EqualsTrimmedOnOrdinalIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), StringComparison.OrdinalIgnoreCase) == 0;
        }
        public static bool EqualsTrimmedIgnoreCase(this string s1, string s2)
        {
            return string.Compare(s1.Trim(), s2?.Trim(), ignoreCase: true) == 0;
        }
        #endregion
    }
}