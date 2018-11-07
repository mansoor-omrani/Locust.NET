using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Collections
{
    public class CharBuffer
    {
        private int bufferSize;
        private char[] buffer;
        private int position;
        public CharBuffer(): this(16)
        {
            
        }

        public CharBuffer(int bufferSize)
        {
            if (bufferSize <= 0)
                bufferSize = 16;

            this.bufferSize = bufferSize;
            this.buffer = new char[bufferSize];
        }

        public int Length
        {
            get { return position; }
        }

        public int BufferLength
        {
            get { return buffer.Length; }
        }

        public void Reset()
        {
            position = 0;
        }

        public void Append(char ch)
        {
            if (position == buffer.Length)
            {
                Array.Resize(ref buffer, buffer.Length + bufferSize);
            }

            buffer[position] = ch;
            position++;
        }
        public void Append(string s)
        {
            foreach (var ch in s)
            {
                Append(ch);
            }
        }
        public void AppendFormat(string format, params object[] args)
        {
            var s = string.Format(format, args);

            foreach (var ch in s)
            {
                Append(ch);
            }
        }
        public override string ToString()
        {
            return new string(buffer, 0, position);
        }
    }
}
