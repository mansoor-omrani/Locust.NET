using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Collections;

namespace Locust.Tracing
{
    
    public class MessageLog : IList<Message>
    {
        private int depth;
        private int order;
        private List<Message> messages;
        public bool DebugMode { get; set; }
        public bool TraceMode { get; set; }
        public MessageViewerType ViewerType { get; set; }
        public DebugLevel DebugLevel { get; set; }
        public bool SuppressedDialog { get; set; }
        public MessageType SuppressedMessageType { get; set; }
        public void EnterScope()
        {
            depth++;
        }

        public void ExitScope()
        {
            depth--;
        }
        public void Trace(string category, string operation, string code, string info = "")
        {
            if (TraceMode)
            {
                var m = new Message
                {
                    Category = category,
                    Info = info,
                    Operation = operation,
                    Code = code,
                    Source = MessageSource.System,
                    Type = MessageType.Trace
                };

                Add(m);
            }
        }
        public void Trace(string category, string operation, string info = "")
        {
            if (TraceMode)
            {
                var m = new Message
                {
                    Category = category,
                    Info = info,
                    Operation = operation,
                    Source = MessageSource.System,
                    Type = MessageType.Trace
                };

                Add(m);
            }
        }
        public void Dialog(string category, string operation, string code, SqlError err)
        {
            var m = new Message
            {
                Category = category,
                Operation = operation,
                Code = code,
                Source = MessageSource.Db,
                Type = SuppressedDialog ? SuppressedMessageType : MessageType.Dialog
            };

            if (DebugMode)
            {
                m.SqlError = err;
            }

            Add(m);
        }
        public void Dialog(string category, string operation, Exception e, MessageSource source = MessageSource.System)
        {
            var m = new Message
            {
                Category = category,
                Operation = operation,
                Source = source,
                Type = SuppressedDialog? SuppressedMessageType : MessageType.Dialog
            };

            if (DebugMode)
            {
                m.Exception = e;
            }

            Add(m);
        }
        public void Dialog(string category, string operation, string code, Exception e, MessageSource source = MessageSource.System)
        {
            var m = new Message
            {
                Category = category,
                Operation = operation,
                Source = source,
                Type = SuppressedDialog ? SuppressedMessageType : MessageType.Dialog,
                Code = code
            };

            if (DebugMode)
            {
                m.Exception = e;
            }

            Add(m);
        }
        public void Danger(string category, string operation, string code, Exception e, MessageSource source)
        {
            var m = new Message
            {
                Category = category,
                Operation = operation,
                Source = source,
                Type = MessageType.Danger,
                Code = code
            };

            if (DebugMode)
            {
                m.Exception = e;
            }

            Add(m);
        }
        public void Danger(string category, string operation, string code, Exception e, MessageSource source = MessageSource.System, string info = "")
        {
            var m = new Message
            {
                Category = category,
                Operation = operation,
                Source = source,
                Type = MessageType.Danger,
                Code = code,
                Info = info
            };

            if (DebugMode)
            {
                m.Exception = e;
            }

            Add(m);
        }
        public void Warning(string category, string operation, string info = "", MessageSource source = MessageSource.System)
        {
            if (DebugMode)
            {
                var m = new Message
                {
                    Category = category,
                    Source = source,
                    Type = MessageType.Warning,
                    Operation = operation,
                    Info = info
                };

                Add(m);
            }
        }
        public void Add(Message m)
        {
            m.Order = ++order;
            m.Depth = depth;
            m.Date = DateTime.Now;

            messages.Add(m);
        }
        public void Debug(string category, string info = "")
        {
            if (DebugMode)
            {
                var m = new Message
                {
                    Category = category,
                    Date = DateTime.Now,
                    Type = MessageType.Debug,
                    Source = MessageSource.System,
                    Info = info
                };

                Add(m);
            }
        }
        public void Debug(string category, string operation, string code, string info = "")
        {
            if (DebugMode)
            {
                var m = new Message
                {
                    Category = category,
                    Operation = operation,
                    Date = DateTime.Now,
                    Code = code,
                    Type = MessageType.Debug,
                    Source = MessageSource.System,
                    Info = info
                };

                Add(m);
            }
        }
        public void Debug(string category, string operation, string code, Func<string> info)
        {
            if (DebugMode)
            {
                var m = new Message
                {
                    Category = category,
                    Operation = operation,
                    Date = DateTime.Now,
                    Code = code,
                    Type = MessageType.Debug,
                    Source = MessageSource.System,
                    Info = (info != null)? info():""
                };

                Add(m);
            }
        }
        public void System(string category, string operation, string code, Func<string> info)
        {
            if (DebugMode)
            {
                var m = new Message
                {
                    Category = category,
                    Operation = operation,
                    Date = DateTime.Now,
                    Code = code,
                    Type = MessageType.System,
                    Source = MessageSource.System,
                    Info = (info != null) ? info() : ""
                };

                Add(m);
            }
        }
        public void Dialog(string category, string operation, string code, string info = "")
        {
            var m = new Message
            {
                Category = category,
                Operation = operation,
                Code = code,
                Date = DateTime.Now,
                Type = SuppressedDialog ? SuppressedMessageType : MessageType.Dialog,
                Info = info, Source = MessageSource.Application
            };

            Add(m);
        }
        public void Dialog(string category, string operation, string code, CaseInsensitiveStringDictionary args, string info = "")
        {
            var m = new Message
            {
                Category = category,
                Operation = operation,
                Code = code,
                Date = DateTime.Now,
                Type = SuppressedDialog ? SuppressedMessageType : MessageType.Dialog,
                Info = info,
                Source = MessageSource.Application
            };
            m.Args = args;

            Add(m);
        }
        public MessageLog()
        {
            messages = new List<Message>();
            DebugLevel = DebugLevel.Dialog;
        }
        public int IndexOf(Message item)
        {
            return messages.IndexOf(item);
        }

        public void Insert(int index, Message item)
        {
            messages.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            messages.RemoveAt(index);
        }

        public Message this[int index]
        {
            get { return messages[index]; }
            set { messages[index] = value; }
        }
        public Message this[string code]
        {
            get { return messages.FirstOrDefault(m => m.Code == code); }
        }
        public void Clear()
        {
            messages.Clear();
        }

        public bool Contains(Message item)
        {
            return messages.Contains(item);
        }

        public void CopyTo(Message[] array, int arrayIndex)
        {
            messages.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return messages.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Message item)
        {
            return messages.Remove(item);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return messages.GetEnumerator();
        }

        IEnumerator<Message> IEnumerable<Message>.GetEnumerator()
        {
            return messages.GetEnumerator();
        }
    }
}
