using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Json
{
    public class JsonException : Exception
    {
        public char Char { get; set; }
        public int Row { get; private set; }

        public int Col { get; private set; }
        public int Position { get; private set; }
        public string Expectation { get; private set; }
        public JsonParseError Type { get; private set; }
        public int State { get; private set; }
        public JsonException()
            : base()
        { }
        public JsonException(string message)
            : base(message)
        { }
        public JsonException(string json, int state, int position, char ch, string expected, JsonParseError type)
        {
            this.Char = ch;
            this.Expectation = expected;
            this.Type = type;
            this.State = state;
            this.Position = position;

            var pos = 0;

            foreach (var c in json)
            {
                if (pos == position)
                {
                    Debug.WriteLine(c);
                    break;
                }

                if (c == '\n')
                {
                    Row++;

                    Col = 0;
                }

                Col++;
                pos++;
            }

            message =
                string.Format("Json Parse Error: {0}. Expected {1} at position {2} (row: {3}, col: {4}), state {5}. Current character is {6}",
                    type, expected, position, Row, Col, state, ch);
            
        }

        private string message;
        public new string Message
        {
            get { return message; }
        }
    }
}
