using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public enum CharComparison
    {
        IgnoreCase
    }
    public static class CharExtensions
    {
        public static byte As6Bit(this char c)
        {
            var lookupTable = new char[64]
            {  
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
            'O','P','Q','R','S','T','U','V','W','X','Y', 'Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n',
            'o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'
            };

            if (c == '=')
                return 0;
            else
            {
                for (int x = 0; x < 64; x++)
                {
                    if (lookupTable[x] == c)
                        return (byte)x;
                }

                //should not reach here

                return 0;
            }
        }

        public static bool IsHexDigit(this char ch)
        {
            return Char.IsDigit(ch) || (ch >= 65 && ch <= 70) || (ch >= 97 && ch <= 102);
        }
        public static bool IsEmpty(this char ch)
        {
            return ch == '\0';
        }
        public static bool ExistsIn(this char ch, char[] chars)
        {
            var result = false;

            result = chars.Any(c => c == ch);

            return result;
        }

        public static char SelectFrom(this char ch, char[] chars, CharComparison comparison = CharComparison.IgnoreCase, char defaultValue = default(char))
        {
            var result = ch;
            var found = false;

            foreach (var _ch in chars)
            {
                if (ch == _ch || (comparison == CharComparison.IgnoreCase && ((ch >= 65 && ch <= 90 && _ch >= 96 && _ch <= 122 && Math.Abs(ch - _ch) == 32) || (ch >= 96 && ch <= 122 && _ch >= 65 && _ch <= 90 && Math.Abs(ch - _ch) == 32))))
                {
                    found = true;
                    break;
                }
                
            }

            if (!found)
            {
                result = defaultValue;
            }

            return result;
        }
        public static char Escape(this char ch)
        {
            char result = default(char);

            switch (ch)
            {
                case 'b': result = '\b'; break;
                case 'f': result = '\f'; break;
                case 'r': result = '\r'; break;
                case 'n': result = '\n'; break;
                case 't': result = '\t'; break;
                case 'a': result = '\a'; break;
                case 'v': result = '\v'; break;
                case '\'': result = '\''; break;
                case '"': result = '"'; break;
                case '\\': result = '\\'; break;
                case '/': result = '/'; break;
            }

            return result;
        }
        public static bool In(this char ch, params char[] chars)
        {
            var result = false;

            if (chars != null && chars.Length > 0)
            {
                foreach (var c in chars)
                {
                    if (ch == c)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
