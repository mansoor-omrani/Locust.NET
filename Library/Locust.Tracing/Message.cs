using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Locust.Base;
using Locust.Collections;
using Locust.Extensions;
using Locust.Language;
using Locust.Serialization;
using Locust.Translation;

namespace Locust.Tracing
{
    public enum MessageType { NotSet, Unknown, Debug, Dialog, Trace, Hidden, Warning, Danger, System }
    public enum MessageSource { Unknown, Db, System, Framework, Library, Service, Application, Model, View }
    public class Message:IJsonSerializable
    {
        public IMessageParamValueProvider ParamValueProvider { get; set; }
        public MessageType Type { get; set; }
        public MessageSource Source { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Operation { get; set; }
        public string Info { get; set; }
        public Exception Exception { get; set; }
        public bool HasError { get { return Exception != null; } }
        public DateTime Date { get; set; }
        public int Depth { get; set; }
        public int Order { get; set; }
        public string Caller { get; set; }
        public string FilePath { get; set; }
        public int Line { get; set; }
        public Message()
        {
            Date = DateTime.Now;
        }
        private CaseInsensitiveStringDictionary _args;
        public CaseInsensitiveStringDictionary Args
        {
            get
            {
                if (_args == null)
                {
                    _args = new CaseInsensitiveStringDictionary();
                }

                return _args;
            }
            set { _args = value; }
        }

        public string RawText { get; set; }
        public string Text { get; set; }
        public virtual void Render()
        {
            Text = "";

            if (!string.IsNullOrEmpty(RawText))
            {
                var state = 1;
                var pos = 0;
                var buffer = new CharBuffer(64);
                var arg = "";
                var key = "";
                var culture = "";
                var value = "";
                var rawText = RawText;

                while (true)
                {
                    var ch = rawText[pos];
                    switch (state)
                    {
                        case 1:
                            if (ch == '{')
                            {
                                state = 2;
                            }
                            else
                            {
                                if (ch == '\\')
                                {
                                    state = 3;
                                }
                                else
                                {
                                    buffer.Append(ch);
                                }
                            }
                            break;
                        case 2:
                            if (!char.IsWhiteSpace(ch))
                            {
                                if (char.IsLetterOrDigit(ch) || ch == '-' || ch == '_')
                                {
                                    arg += ch;
                                }
                                else
                                {
                                    if (ch == '}')
                                    {
                                        if (Args.ContainsKey(arg) && !string.IsNullOrEmpty(arg))
                                        {
                                            buffer.Append(Args[arg]);
                                        }
                                        
                                        arg = "";
                                        state = 1;
                                    }
                                    else
                                    {
                                        if (ch == ':' && !string.IsNullOrEmpty(arg))
                                        {
                                            key = arg;
                                            arg = "";
                                            state = 4;
                                        }
                                    }
                                }
                            }
                            break;
                        case 3:
                            switch (ch)
                            {
                                case '{':
                                    buffer.Append('{');
                                    break;
                                case '}':
                                    buffer.Append('}');
                                    break;
                                case '\\':
                                    buffer.Append('\\');
                                    break;
                                case 'n':
                                    buffer.Append('\n');
                                    break;
                                case 'r':
                                    buffer.Append('\r');
                                    break;
                                case 't':
                                    buffer.Append('\t');
                                    break;
                                case 'v':
                                    buffer.Append('\v');
                                    break;
                                case 'b':
                                    buffer.Append('\b');
                                    break;
                            }
                            
                            state = 1;
                            break;
                        case 4:
                            if (!char.IsWhiteSpace(ch))
                            {
                                if (char.IsLetterOrDigit(ch) || ch == '-' || ch == '_')
                                {
                                    value += ch;
                                }
                                else
                                {
                                    if (ch == '}')
                                    {
                                        if (ParamValueProvider != null && !string.IsNullOrEmpty(value))
                                        {
                                            var x = ParamValueProvider.GetValue(key, value);
                                            buffer.Append(x);
                                        }

                                        key = "";
                                        value = "";

                                        state = 1;
                                    }
                                    else
                                    {
                                        if (ch == ':' && !string.IsNullOrEmpty(value))
                                        {
                                            state = 5;
                                        }
                                    }
                                }
                            }
                            break;
                        case 5:
                            if (!char.IsWhiteSpace(ch))
                            {
                                if (char.IsLetterOrDigit(ch) || ch == '-' || ch == '_')
                                {
                                    culture += ch;
                                }
                                else
                                {
                                    if (ch == '}')
                                    {
                                        if (ParamValueProvider != null && !string.IsNullOrEmpty(culture))
                                        {
                                            var x = ParamValueProvider.GetValue(key, value, culture);
                                            buffer.Append(x);
                                        }

                                        key = "";
                                        value = "";
                                        culture = "";

                                        state = 1;
                                    }
                                }
                            }
                            break;
                    }

                    pos++;

                    if (pos == rawText.Length)
                        break;
                }

                Text = buffer.ToString();
            }
        }

        public virtual string ToJson(JsonSerializationOptions options = null)
        {
            /*
            var settings = new JsonSerializerSettings();

            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;

            var result = JsonConvert.SerializeObject(this, settings);

            return result;
            */

            var _options = options ?? new JsonSerializationOptions();
            var newLine = _options.UseIndentation ? Environment.NewLine : "";
            var indent = _options.UseIndentation ? _options.CurrentIndent + _options.Indent : "";

            var sDate = $"{indent}\"{nameof(Date)}\":\"{Date.ToUniversalTime()}\"{newLine}";
            var sOrder = $"{indent},\"{nameof(Order)}\":{Order}{newLine}";
            var sDepth = $"{indent},\"{nameof(Depth)}\":{Depth}{newLine}";
            var sType = $"{indent},\"{nameof(Type)}\":\"{Type}\"{newLine}";
            var sSource = $"{indent},\"{nameof(Source)}\":\"{Source}\"{newLine}";
            var sCategory = string.IsNullOrEmpty(Category) ? "" : $"{indent},\"{nameof(Category)}\":\"{HttpUtility.JavaScriptStringEncode(Category)}\"{newLine}";
            var sOperation = string.IsNullOrEmpty(Operation) ? "" : $"{indent},\"{nameof(Operation)}\":\"{HttpUtility.JavaScriptStringEncode(Operation)}\"{newLine}";
            var sCode = string.IsNullOrEmpty(Code) ? "" : $"{indent},\"{nameof(Code)}\":\"{HttpUtility.JavaScriptStringEncode(Code)}\"{newLine}";
            var sInfo = string.IsNullOrEmpty(Info) ? "" : $"{indent},\"{nameof(Info)}\":\"{HttpUtility.JavaScriptStringEncode(Info)}\"{newLine}";
            var sException = (Exception == null) ? "" : $"\"{nameof(Exception)}\":{JsonConvert.SerializeObject(Exception)}{newLine}";
            var sCaller = string.IsNullOrEmpty(Caller) ? "" : $"{indent},\"{nameof(Caller)}\":\"{HttpUtility.JavaScriptStringEncode(Caller)}\"{newLine}";
            var sFilePath = string.IsNullOrEmpty(FilePath) ? "" : $"{indent},\"{nameof(FilePath)}\":\"{HttpUtility.JavaScriptStringEncode(FilePath)}\"{newLine}";
            var sLine = Line == 0 ? "" : $"{indent},\"{nameof(Line)}\":{Line}{newLine}";
            var sRawText = string.IsNullOrEmpty(RawText) ? "" : $"{indent},\"{nameof(RawText)}\":\"{HttpUtility.JavaScriptStringEncode(RawText)}\"{newLine}";
            var sArgs = (Args == null || Args.Count == 0) ? "" : $"\"{nameof(Args)}\":{Args.ToJson()}{newLine}";
            var sText = string.IsNullOrEmpty(Text) ? "" : $"{indent},\"{nameof(Text)}\":\"{HttpUtility.JavaScriptStringEncode(Text)}\"{newLine}";

            return
                $@"{_options.CurrentIndent}{{{newLine}{sDate}{sOrder}{sDepth}{sType}{sSource}{sCategory}{sOperation}{sCode}{sInfo}{sException}{sCaller}{sFilePath}{sLine}{sRawText}{sArgs}{sText}{_options.CurrentIndent}}}";
        }
    }
}
