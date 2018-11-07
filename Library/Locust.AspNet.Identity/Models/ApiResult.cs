using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Locust.AspNet.Identity.Models
{
    public class ApiResultMessages
    {
        private List<string> messages;

        public ApiResultMessages()
        {
            messages = new List<string>();
        }

        public List<string> Items
        {
            get { return messages; }
        }
        public IEnumerator<string> GetEnumerator()
        {
            return messages.GetEnumerator();
        }
        public string First
        {
            get
            {
                if (messages.Count > 0)
                {
                    return messages[0];
                }
                else
                {
                    return "";
                }
            }
        }
        public string Last
        {
            get
            {
                if (messages.Count > 0)
                {
                    return messages[messages.Count - 1];
                }
                else
                {
                    return "";
                }
            }
        }
        public void Add(string item)
        {
            messages.Add(item);
        }

        public void Clear()
        {
            messages.Clear();
        }

        public bool Contains(string item)
        {
            return messages.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            messages.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            return messages.Remove(item);
        }

        public int Count
        {
            get { return messages.Count; }
        }
        public int IndexOf(string item)
        {
            return messages.IndexOf(item);
        }

        public void Insert(int index, string item)
        {
            messages.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            messages.RemoveAt(index);
        }

        public string this[int index]
        {
            get { return messages[index]; }
            set { messages[index] = value; }
        }
    }
    
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Status { get; set; }
        public ApiResultMessages Messages { get; set; }

        public ApiResult()
        {
            Messages = new ApiResultMessages();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
