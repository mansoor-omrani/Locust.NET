using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Caching;
using Locust.Language;
using Locust.Translation;

namespace Locust.Tracing
{
    public interface IMessageTextProvider
    {
        Lang Lang { get; set; }
        ITranslator Translator { get; set; }
        MessageList Process(MessageList messages);
        string GetText(Message msg);
    }
    public interface IMessageParamValueProvider
    {
        string GetValue(string key, string value, string culture = "");
    }
    public abstract class MessageContentProvider: IMessageTextProvider, IMessageParamValueProvider
    {
        public Lang Lang { get; set; }
        public ITranslator Translator { get; set; }
        public MessageContentProvider(ITranslator translator)
        {
            Translator = translator;
        }
        public abstract void Load(string basePath);
        public string Divider { get; set; }
        public abstract string GetText(Message msg);
        protected virtual Message Format(Message msg, MessageListOptions options)
        {
            Message result = null;

            switch (options.Viewer)
            {
                case MessageViewerType.Manager:
                    result = new Message
                    {
                        Code = msg.Code,
                        Text = msg.Text,
                        Date = msg.Date,
                        Info = msg.Info,
                        Category = msg.Category,
                        Operation = msg.Operation,
                        Type = msg.Type
                    };
                    break;
                case MessageViewerType.Developer:
                case MessageViewerType.Super:
                    result = msg;
                    break;
                case MessageViewerType.PowerUser:
                    result = new Message
                    {
                        Code = msg.Code,
                        Text = msg.Text,
                        Date = msg.Date,
                        Info = msg.Info,
                        Category = msg.Category,
                        Operation = msg.Operation,
                        Type = msg.Type,
                        Source = msg.Source
                    };
                    break;
                case MessageViewerType.Admin:
                    result = new Message
                    {
                        Code = msg.Code,
                        Text = msg.Text,
                        Date = msg.Date,
                        Info = msg.Info,
                        Category = msg.Category,
                        Operation = msg.Operation,
                        Type = msg.Type,
                        Source = msg.Source,
                        Order = msg.Order,
                        Depth = msg.Depth
                    };
                    break;
                default:
                    result = new Message
                    {
                        Code = msg.Code,
                        Text = msg.Text,
                        Date = msg.Date,
                        Info = msg.Info,
                        Type = msg.Type
                    };
                    break;
            }

            return result;
        }
        public virtual MessageList Process(MessageList messages)
        {
            var result = new MessageList();
            Message x;
            bool addMsg;

            foreach (var msg in messages.OrderByDescending(m => m.Order))
            {
                x = null;

                switch (messages.Options.Viewer)
                {
                    case MessageViewerType.Guest:
                    case MessageViewerType.User:
                        x = (msg.Type == MessageType.Dialog) ? msg : null;
                        break;
                    case MessageViewerType.PowerUser:
                        x = (msg.Type == MessageType.Dialog || msg.Type == MessageType.Warning) ? msg : null;
                        break;
                    case MessageViewerType.Manager:
                        x = (msg.Type == MessageType.Dialog || msg.Type == MessageType.Warning || msg.Type == MessageType.Danger) ? msg : null;
                        break;
                    case MessageViewerType.Developer:
                        if (msg.Type != MessageType.Hidden)
                        {
                            addMsg = (
                                        msg.Type == MessageType.Dialog &&
                                        ((messages.Options.DebugLevel & DebugLevel.Dialog) == DebugLevel.Dialog)
                                     ) ||
                                     (
                                        msg.Type == MessageType.Trace &&
                                        ((messages.Options.DebugLevel & DebugLevel.Trace) == DebugLevel.Trace)
                                     ) ||
                                     (
                                        msg.Type == MessageType.Debug &&
                                        ((messages.Options.DebugLevel & DebugLevel.Debug) == DebugLevel.Debug)
                                     ) ||
                                     (
                                        msg.Type == MessageType.System &&
                                        ((messages.Options.DebugLevel & DebugLevel.System) == DebugLevel.System)
                                     ) ||
                                     (msg.Type == MessageType.Warning) ||
                                     msg.Type == MessageType.Danger;
                            
                            if (addMsg)
                            {
                                x = msg;
                            }
                        }
                        break;
                    case MessageViewerType.Super:
                        addMsg =    (
                                        msg.Type == MessageType.Dialog &&
                                        ((messages.Options.DebugLevel & DebugLevel.Dialog) == DebugLevel.Dialog)
                                    ) ||
                                    (
                                        msg.Type == MessageType.Trace &&
                                        ((messages.Options.DebugLevel & DebugLevel.Trace) == DebugLevel.Trace)
                                    ) ||
                                    (
                                        msg.Type == MessageType.Debug &&
                                        ((messages.Options.DebugLevel & DebugLevel.Debug) == DebugLevel.Debug)
                                    ) ||
                                    (
                                        msg.Type == MessageType.System &&
                                        ((messages.Options.DebugLevel & DebugLevel.System) == DebugLevel.System)
                                    ) ||
                                    msg.Type == MessageType.Hidden ||
                                    msg.Type == MessageType.Warning ||
                                    msg.Type == MessageType.Danger;
                            if (addMsg)
                            {
                                x = msg;
                            }
                        break;
                }

                if (x != null)
                {
                    x.ParamValueProvider = this;
                    x.RawText = GetText(x);
                    x.Render();

                    x = Format(x, messages.Options);

                    result.Add(x);
                }
            }

            return result;
        }
        public string GetValue(string key, string value, string culture = "")
        {
            if (string.IsNullOrEmpty(culture))
            {
                return Translator.GetSingle(key, value, Lang.ShortName);
            }
            else
            {
                return Translator.GetSingle(key, value, culture, Lang.ShortName);
            }
        }
    }
}
