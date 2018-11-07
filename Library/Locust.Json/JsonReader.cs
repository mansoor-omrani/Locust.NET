using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Json
{
    public class JsonReader
    {
        private string json;
        private char currentChar;
        private char? lastChar;
        private int position;
        public JsonReader(string json)
        {
            this.json = json;
            Reset();
        }
        public char Next()
        {
            if (lastChar.HasValue)
            {
                currentChar = lastChar.Value;
                lastChar = null;
            }
            else
            {
                if (position < json.Length)
                {
                    currentChar = json[position];
                    position++;
                }
            }

            return currentChar;
        }
        public bool Finished
        {
            get
            {
                return string.IsNullOrEmpty(json) || position == json.Length;
            }
        }
        public int Position
        {
            get { return position; }
        }
        public void Reset()
        {
            position = 0;
            currentChar = default(char);
        }
        public string Json
        {
            get { return json; }
        }
        public void Store()
        {
            lastChar = currentChar;
        }
    }
}
