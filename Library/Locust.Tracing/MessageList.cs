using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Extensions;
using Locust.Serialization;
using System.Runtime.CompilerServices;
using Locust.Date;

namespace Locust.Tracing
{
    public enum MessageViewerType
    {
        Guest,
        User,
        PowerUser,
        Manager,
        Admin,
        Developer,
        Super
    }
    public class MessageItem
    {
        public string Category { get; set; }
        public string Operation { get; set; }
        public string Code { get; set; }
        public string Info { get; set; }
        public Func<string> GetInfo { get; set; }
        public Exception Exception { get; set; }
        public MessageSource? Source { get; set; }
    }
    public class MessageListOptions
    {
        public MessageViewerType Viewer { get; set; }
        public bool TraceMode { get; set; }
        public bool DebugMode { get; set; }
        public DebugLevel DebugLevel { get; set; }
        public bool SuppressedDialog { get; set; }
        public MessageType SuppressedMessageType { get; set; }
        public MessageListOptions()
        {
            Viewer = MessageViewerType.Guest;
            DebugLevel = DebugLevel.Dialog;
        }
    }
    public class MessageList: IList<Message>,IJsonSerializable
    {
        private List<Message> messages;
        private int depth;
        private int order;
        public MessageListOptions Options { get; private set; }
        public INow Now { get; set; }
        public MessageList()
        {
            messages = new List<Message>();
            Options = new MessageListOptions();
            Now = new DateTimeNow();
        }
        public void EnterScope()
        {
            depth++;
        }

        public void ExitScope()
        {
            depth--;
        }
        #region IList<Message> Implementation
        public IEnumerator<Message> GetEnumerator()
        {
            return messages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Message item)
        {
            item.Order = ++order;
            item.Depth = depth;
            item.Date = GetNow();

            messages.Add(item);
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

        public bool Remove(Message item)
        {
            return Remove(item);
        }

        public int Count { get { return messages.Count; } }
        public bool IsReadOnly { get { return false; } }
        public int IndexOf(Message item)
        {
            return IndexOf(item);
        }

        public void Insert(int index, Message item)
        {
            messages.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            messages.RemoveAt(index);
        }
        #endregion
        #region useful methods
        public Message this[int index]
        {
            get { return messages[index]; }
            set { messages[index] = value; }
        }
        public Message this[string code]
        {
            get { return messages.FirstOrDefault(m => m.Code == code); }
        }
        #endregion
        #region Add-Specific methods
        private DateTime GetNow()
        {
            return Now == null ? DateTime.Now : Now.Value;
        }
        private void Add(
                            bool add,
                            MessageType type,
                            MessageItem msg,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0
                        )
        {
            if (add)
            {
                Add(new Message
                {
                    Type = type,
                    Category = msg.Category,
                    Operation = msg.Operation,
                    Info = msg.GetInfo == null ? msg.Info : msg.GetInfo(),
                    Code = msg.Code,
                    Source = msg.Source == null ? MessageSource.System : msg.Source.Value,
                    Exception = msg.Exception,
                    Caller = caller,
                    FilePath = filePath,
                    Line = line
                });
            }
        }
        public void Trace(  MessageItem msg,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0)
        {
            Add(Options.TraceMode, type: MessageType.Trace, msg: msg, caller: caller, filePath: filePath, line: line);
        }
        public void Dialog( MessageItem msg,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0)
        {
            if (msg.Source == null)
                msg.Source = MessageSource.Application;

            Add(true, type: MessageType.Dialog, msg: msg, caller: caller, filePath: filePath, line: line);
        }
        public void Danger( MessageItem msg,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0)
        {
            Add(Options.DebugMode, type: MessageType.Danger, msg: msg, caller: caller, filePath: filePath, line: line);
        }
        public void Debug(MessageItem msg,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0)
        {
            Add(Options.DebugMode, type: MessageType.Debug, msg: msg, caller: caller, filePath: filePath, line: line);
        }
        public void Debug(string category,
                            string operation,
                            string code,
                            string info,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0)
        {
            Add(Options.DebugMode, type: MessageType.Debug, msg: new MessageItem
            {
                Category = category,
                Operation = operation,
                Code = code,
                Info = info,
            }, caller: caller, filePath: filePath, line: line);
        }
        public void Warning(MessageItem msg,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0)
        {
            Add(Options.DebugMode, type: MessageType.Warning, msg: msg, caller: caller, filePath: filePath, line: line);
        }
        public void System(MessageItem msg,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0)
        {
            Add(Options.DebugMode, type: MessageType.System, msg: msg, caller: caller, filePath: filePath, line: line);
        }
        public void Hidden(MessageItem msg,
                            [CallerMemberName]
                            string caller = "",
                            [CallerFilePath]
                            string filePath = "",
                            [CallerLineNumber]
                            int line = 0)
        {
            Add(Options.DebugMode, type: MessageType.Hidden, msg: msg, caller: caller, filePath: filePath, line: line);
        }
        #endregion
        public string ToJson(JsonSerializationOptions options = null)
        {
            /*
            var settings = new JsonSerializerSettings();

            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;

            var result = JsonConvert.SerializeObject(this, settings);

            return result;
            */
            var _options = options ?? new JsonSerializationOptions();
            var childOption = new JsonSerializationOptions(_options);
            var newLine = _options.UseIndentation ? Environment.NewLine : "";
            var indent = _options.UseIndentation ? _options.CurrentIndent + _options.Indent : "";
            var sb = new StringBuilder();

            foreach (var msg in messages)
            {
                var comma = sb.Length == 0 ? "," : "";
                sb.Append($"{msg.ToJson(childOption)}{comma}{newLine}");
            }

            return $"{_options.CurrentIndent}[{newLine}{sb}{_options.CurrentIndent}]";
        }
    }
}
