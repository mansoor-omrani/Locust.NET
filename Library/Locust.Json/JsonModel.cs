using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Collections;
using Locust.Extensions;
using Locust.Serialization;

namespace Locust.Json
{
    public enum JsonParseError
    {
        InvalidCharacter,
        PropertyNameIsEmpty,
        InvalidEscapeChar,
        ColonExpected,
        UnterminatedArray,
        UnterminatedObject,
        InvalidPropertyValue,
        ExpectedCommaOrBrace,
        InvalidNumber,
        InvalidArrayItem
    }

    public enum JsonValueType
    {
        Number, Char, Boolean, String, Null
    }
    public abstract class JsonModel: IJsonSerializable,IJsonListArraySerializable
    {
        protected int PropertyNameBufferSize { get; set; }
        protected int PropertyValueBufferSize { get; set; }
        private void ParseError(string json, int state, int position, JsonParseError type, char jch, string expected)
        {
            throw new JsonException(json, state, position, jch, expected, type);
        }
        protected virtual bool OnArrayPropertyDetected(string propertyName, JsonReader reader) { return false; }
        protected virtual bool OnObjectPropertyDetected(string propertyName, JsonReader reader) { return false; }
        protected virtual void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType propertyType) { }
        protected virtual bool OnArrayItemDetected(JsonReader reader) { return false; }
        protected virtual bool OnObjectItemDetected(JsonReader reader) { return false; }
        protected virtual void OnBasicItemDetected(string item, JsonValueType itemType) { }

        protected virtual KeyValuePair<string, object> AddProperty(string propertyName, object propertyValue)
        {
            return new KeyValuePair<string, object>(propertyName, propertyValue);
        }
        protected virtual IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            return this.ToDictionary();
        }
        public virtual IEnumerable<string> GetPropertyNames()
        {
            foreach (var item in GetProperties())
            {
                yield return item.Key;
            }
        }
        public virtual string ToJson(JsonSerializationOptions options = null)
        {
            var _options = new JsonSerializationOptions(options);
            var result = new StringBuilder();

            foreach (var x in GetProperties())
            {
                var value = x.Value;
                if (value == null)
                {
                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\":{1}", x.Key, "null");
                    continue;
                }
                if (value is bool)
                {
                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\":{1}", x.Key, value.ToString().ToLower());
                    continue;
                }
                if (value.GetType().IsNumeric())
                {
                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\":{1}", x.Key, value);
                    continue;
                }
                if (value is char)
                {
                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\":'{1}'", x.Key, value);
                    continue;
                }
                if (value is Guid)
                {
                    if ((Guid)value != Guid.Empty)
                    {
                        result.AppendFormatWithCommaIfNotEmpty("\"{0}\":'{1}'", x.Key, value);
                        continue;
                    }
                    else
                    {
                        result.AppendFormatWithCommaIfNotEmpty("\"{0}\":null", x.Key);
                        continue;
                    }
                }
                if (value is string)
                {
                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\":\"{1}\"", x.Key, HttpUtility.JavaScriptStringEncode(value.ToString()));

                    continue;
                }

                var jm = value as IJsonSerializable;

                if (jm != null)
                {
                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\":{1}", x.Key, jm.ToJson(_options));
                    continue;
                }

                var e = value as IEnumerable;
                if (e != null)
                {
                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\": ", x.Key);
                    result.Append(e.ToJson(_options));
                    continue;
                }
                result.AppendFormatWithCommaIfNotEmpty("\"{0}\":\"{1}\"", x.Key, value);
            }

            return "{" + result + "}";
        }
        public void ReadJson(JsonReader reader)
        {
            ReadJsonInternal("", reader);
        }
        public void ReadJson(string json)
        {
            ReadJsonInternal(json, null);
        }
        private void ReadJsonInternal(string json, JsonReader givenReader)
        {
            JsonReader reader;
            
            if (givenReader == null)
            {
                reader = new JsonReader(json);
            }
            else
            {
                reader = givenReader;
            }

            var state = 1;
            var chContainer = '"';
            var propertyName = new CharBuffer(PropertyNameBufferSize);
            var propertyValue = new CharBuffer(PropertyValueBufferSize);
            var unicodeEscapeCode = new CharBuffer();
            var arrayItem = new CharBuffer();
            int code = 0;

            while (!reader.Finished)
            {
                var ch = reader.Next();

                switch (state)
                {
                    case 1:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (ch == '{')
                        {
                            state = 2;
                            continue;
                        }

                        if (ch == '[')
                        {
                            state = 20;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidCharacter, ch, "{ or [");

                        break;
                    case 2:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (ch == '\'' || ch == '"')
                        {
                            chContainer = ch;
                            state = 3;
                            continue;
                        }

                        if (!Char.IsPunctuation(ch) && !Char.IsControl(ch))
                        {
                            propertyName.Append(ch);
                            state = 6;
                            continue;
                        }

                        if (ch == '}')
                        {
                            goto exit_while;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidCharacter, ch, "property name starter char");

                        break;
                    case 3:
                        if (ch == chContainer)
                        {
                            if (propertyName.Length == 0)
                            {
                                ParseError(json, state, reader.Position, JsonParseError.PropertyNameIsEmpty, ch, "");
                            }

                            state = 7;
                            continue;
                        }

                        if (ch == '\\')
                        {
                            state = 4;
                            continue;
                        }

                        propertyName.Append(ch);

                        break;
                    case 4:
                        if (ch.ExistsIn(new char[] { 'b', 'f', 'n', 'r', 't', '\\', '"', '\'', '/' }))
                        {
                            propertyName.Append(ch.Escape());
                            state = 3;
                            continue;
                        }

                        if (ch == 'u' || ch == 'U')
                        {
                            state = 5;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidEscapeChar, ch, "");

                        break;
                    case 5:
                        if (ch.IsHexDigit())
                        {
                            unicodeEscapeCode.Append(ch);
                            continue;
                        }

                        code = int.Parse(unicodeEscapeCode.ToString(), System.Globalization.NumberStyles.HexNumber);
                        propertyName.Append(char.ConvertFromUtf32(code));
                        unicodeEscapeCode.Reset();

                        reader.Store();

                        break;
                    case 6:
                        if (ch == ':' || Char.IsWhiteSpace(ch))
                        {
                            if (ch != ':')
                            {
                                reader.Store();
                                state = 7;
                                continue;
                            }

                            if (propertyName.Length != 0)
                            {
                                state = 8;
                                continue;
                            }
                            else
                            {
                                ParseError(json, state, reader.Position, JsonParseError.PropertyNameIsEmpty, ch, ":");
                            }
                        }

                        propertyName.Append(ch);

                        break;
                    case 7:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (ch == ':')
                        {
                            state = 8;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.ColonExpected, ch, ":");

                        break;
                    case 8:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (Char.IsLetter(ch))
                        {
                            state = 9;
                            propertyValue.Append(ch);
                            continue;
                        }

                        if (Char.IsDigit(ch))
                        {
                            state = 11;
                            propertyValue.Append(ch);
                            continue;
                        }

                        if (ch == '.')
                        {
                            state = 110;
                            propertyValue.Append(ch);
                            continue;
                        }

                        if (ch == '-' || ch == '+')
                        {
                            state = 12;
                            propertyValue.Append(ch);
                            continue;
                        }

                        if (ch == '"' || ch == '\'')
                        {
                            state = 17;
                            chContainer = ch;
                            continue;
                        }

                        if (ch == '[')
                        {
                            reader.Store();

                            if (!OnArrayPropertyDetected(propertyName.ToString(), reader))
                            {
                                var x = new EmptyJsonArray();

                                x.ReadJson(reader);
                            }

                            propertyName.Reset();
                            propertyValue.Reset();

                            state = 10;

                            continue;
                        }

                        if (ch == '{')
                        {
                            reader.Store();

                            if (!OnObjectPropertyDetected(propertyName.ToString(), reader))
                            {
                                var x = new EmptyJson();

                                x.ReadJson(reader);
                            }

                            propertyName.Reset();
                            propertyValue.Reset();

                            state = 10;

                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidCharacter, ch, "{ | [ | ' | \" | - | + | letter | digit");

                        break;
                    case 9:
                        if (Char.IsLetter(ch))
                        {
                            propertyValue.Append(ch);
                            continue;
                        }
                        else
                        {
                            var value = propertyValue.ToString();

                            if (string.Compare(value, "true", false) == 0 || string.Compare(value, "false", false) == 0 || string.Compare(value, "null", false) == 0)
                            {
                                if (string.Compare(value, "true", false) == 0 ||
                                    string.Compare(value, "false", false) == 0)
                                {
                                    OnBasicPropertyDetected(propertyName.ToString(), value, JsonValueType.Boolean);
                                }
                                else
                                {
                                    OnBasicPropertyDetected(propertyName.ToString(), value, JsonValueType.Null);
                                }

                                propertyName.Reset();
                                propertyValue.Reset();

                                reader.Store();
                                state = 10;

                                continue;
                            }
                            else
                            {
                                ParseError(json, state, reader.Position, JsonParseError.InvalidPropertyValue, ch, "number | true | false | null | {array} | {object}");
                            }
                        }

                        break;
                    case 10:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (ch == ',')
                        {
                            state = 2;
                            continue;
                        }

                        if (ch == '}')
                        {
                            goto exit_while;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.ExpectedCommaOrBrace, ch, "',' | '{'");

                        break;
                    case 11:
                        if (Char.IsDigit(ch))
                        {
                            propertyValue.Append(ch);
                            continue;
                        }

                        if (ch == '.')
                        {
                            propertyValue.Append(ch);
                            state = 110;
                            continue;
                        }

                        if (ch == 'e' || ch == 'E')
                        {
                            propertyValue.Append(ch);
                            state = 13;
                            continue;
                        }

                        OnBasicPropertyDetected(propertyName.ToString(), propertyValue.ToString(), JsonValueType.Number);

                        propertyName.Reset();
                        propertyValue.Reset();

                        state = 10;
                        reader.Store();

                        break;
                    case 110:
                        if (Char.IsDigit(ch))
                        {
                            propertyValue.Append(ch);
                            continue;
                        }

                        if (ch == 'e' || ch == 'E')
                        {
                            propertyValue.Append(ch);
                            state = 13;
                            continue;
                        }

                        OnBasicPropertyDetected(propertyName.ToString(), propertyValue.ToString(), JsonValueType.Number);

                        propertyName.Reset();
                        propertyValue.Reset();

                        state = 10;
                        reader.Store();

                        break;
                    case 12:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (ch == '.' || Char.IsDigit(ch))
                        {
                            propertyValue.Append(ch);
                            state = 11;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidNumber, ch, "");

                        break;
                    case 13:
                        if (Char.IsDigit(ch))
                        {
                            propertyValue.Append(ch);
                            state = 14;
                            continue;
                        }

                        if (ch == '-' || ch == '+')
                        {
                            propertyValue.Append(ch);
                            state = 15;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidNumber, ch, "");

                        break;
                    case 14:
                        if (Char.IsDigit(ch))
                        {
                            propertyValue.Append(ch);
                            continue;
                        }

                        OnBasicPropertyDetected(propertyName.ToString(), propertyValue.ToString(), JsonValueType.Number);

                        propertyName.Reset();
                        propertyValue.Reset();

                        reader.Store();
                        state = 10;

                        break;
                    case 15:
                        if (Char.IsDigit(ch))
                        {
                            propertyValue.Append(ch);
                            state = 16;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidNumber, ch, "");

                        break;
                    case 16:
                        if (Char.IsDigit(ch))
                        {
                            propertyValue.Append(ch);
                            continue;
                        }

                        OnBasicPropertyDetected(propertyName.ToString(), propertyValue.ToString(), JsonValueType.Number);

                        propertyName.Reset();
                        propertyValue.Reset();

                        reader.Store();
                        state = 10;

                        break;
                    case 17:
                        if (ch == chContainer)
                        {
                            if (ch == '"')
                            {
                                OnBasicPropertyDetected(propertyName.ToString(), propertyValue.ToString(), JsonValueType.String);
                            }
                            else
                            {
                                OnBasicPropertyDetected(propertyName.ToString(), propertyValue.ToString(), JsonValueType.Char);
                            }

                            propertyName.Reset();
                            propertyValue.Reset();

                            state = 10;

                            continue;
                        }

                        if (ch == '\\')
                        {
                            state = 18;
                            continue;
                        }

                        propertyValue.Append(ch);

                        break;
                    case 18:
                        if (ch.ExistsIn(new char[] { 'b', 'f', 'n', 'r', 't', '\\', '"', '\'', '/' }))
                        {
                            propertyValue.Append(ch.Escape());
                            state = 17;
                            continue;
                        }

                        if (ch == 'u' || ch == 'U')
                        {
                            state = 19;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidEscapeChar, ch, "");

                        break;
                    case 19:
                        if (ch.IsHexDigit())
                        {
                            unicodeEscapeCode.Append(ch);
                            continue;
                        }

                        code = int.Parse(unicodeEscapeCode.ToString(), System.Globalization.NumberStyles.HexNumber);
                        propertyValue.Append(char.ConvertFromUtf32(code));
                        unicodeEscapeCode.Reset();

                        state = 17;
                        reader.Store();

                        break;
                    case 20:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            state = 21;
                            continue;
                        }

                        if (ch == '.')
                        {
                            arrayItem.Append(ch);
                            state = 200;
                            continue;
                        }

                        if (ch == '-' || ch == '+')
                        {
                            arrayItem.Append(ch);
                            state = 23;
                            continue;
                        }

                        if (ch == '"' || ch == '\'')
                        {
                            chContainer = ch;
                            state = 28;
                            continue;
                        }

                        if (Char.IsLetter(ch))
                        {
                            arrayItem.Append(ch);
                            state = 31;
                            continue;
                        }

                        if (ch == ']')
                        {
                            reader.Store();

                            state = 22;

                            continue;
                        }

                        if (ch == '[')
                        {
                            reader.Store();

                            arrayItem.Reset();

                            if (!OnArrayItemDetected(reader))
                            {
                                var x = new EmptyJsonArray();

                                x.ReadJson(reader);
                            }

                            state = 22;

                            continue;
                        }

                        if (ch == '{')
                        {
                            reader.Store();

                            arrayItem.Reset();

                            if (!OnObjectItemDetected(reader))
                            {
                                var x = new EmptyJson();

                                x.ReadJson(reader);
                            }

                            state = 22;

                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidCharacter, ch, "{ | [ | ' | \" | - | + | letter | digit");

                        break;
                    case 200:
                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            state = 210;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidCharacter, ch, "digit");

                        break;
                    case 21:
                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            continue;
                        }

                        if (ch == 'e' || ch == 'E')
                        {
                            arrayItem.Append(ch);
                            state = 24;
                            continue;
                        }

                        if (ch == '.')
                        {
                            arrayItem.Append(ch);
                            state = 210;
                            continue;
                        }

                        OnBasicItemDetected(arrayItem.ToString(), JsonValueType.Number);

                        arrayItem.Reset();

                        reader.Store();
                        state = 22;

                        break;
                    case 210:
                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            continue;
                        }

                        if (ch == 'e' || ch == 'E')
                        {
                            arrayItem.Append(ch);
                            state = 24;
                            continue;
                        }

                        OnBasicItemDetected(arrayItem.ToString(), JsonValueType.Number);

                        arrayItem.Reset();

                        reader.Store();
                        state = 22;

                        break;
                    case 22:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (ch == ']')
                        {
                            goto exit_while;
                        }

                        if (ch == ',')
                        {
                            state = 20;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidCharacter, ch, ", | ]");

                        break;
                    case 23:
                        if (Char.IsWhiteSpace(ch))
                        {
                            continue;
                        }

                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            state = 21;
                            continue;
                        }

                        if (ch == '.')
                        {
                            arrayItem.Append(ch);
                            state = 210;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidNumber, ch, "");

                        break;
                    case 24:
                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            state = 25;
                            continue;
                        }

                        if (ch == '-' || ch == '+')
                        {
                            arrayItem.Append(ch);
                            state = 26;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidNumber, ch, "");

                        break;
                    case 25:
                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            continue;
                        }

                        OnBasicItemDetected(arrayItem.ToString(), JsonValueType.Number);

                        arrayItem.Reset();

                        reader.Store();
                        state = 22;

                        break;
                    case 26:
                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            state = 27;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidNumber, ch, "");

                        break;
                    case 27:
                        if (Char.IsDigit(ch))
                        {
                            arrayItem.Append(ch);
                            continue;
                        }

                        OnBasicItemDetected(arrayItem.ToString(), JsonValueType.Number);

                        arrayItem.Reset();

                        reader.Store();
                        state = 22;

                        break;
                    case 28:
                        if (ch == chContainer)
                        {
                            if (ch == '"')
                            {
                                OnBasicItemDetected(arrayItem.ToString(), JsonValueType.String);
                            }
                            else
                            {
                                OnBasicItemDetected(arrayItem.ToString(), JsonValueType.Char);
                            }

                            arrayItem.Reset();

                            state = 22;

                            continue;
                        }

                        if (ch == '\\')
                        {
                            state = 29;
                            continue;
                        }

                        arrayItem.Append(ch);

                        break;
                    case 29:
                        if (ch.ExistsIn(new char[] { 'b', 'f', 'n', 'r', 't', '\\', '"', '\'', '/' }))
                        {
                            arrayItem.Append(ch.Escape());
                            state = 28;
                            continue;
                        }

                        if (ch == 'u' || ch == 'U')
                        {
                            state = 30;
                            continue;
                        }

                        ParseError(json, state, reader.Position, JsonParseError.InvalidEscapeChar, ch, "");

                        break;
                    case 30:
                        if (Char.IsDigit(ch))
                        {
                            unicodeEscapeCode.Append(ch);
                            continue;
                        }

                        code = int.Parse(unicodeEscapeCode.ToString(), System.Globalization.NumberStyles.HexNumber);
                        arrayItem.Append(char.ConvertFromUtf32(code));
                        unicodeEscapeCode.Reset();

                        state = 28;
                        reader.Store();

                        break;
                    case 31:
                        if (Char.IsLetter(ch))
                        {
                            arrayItem.Append(ch);
                            continue;
                        }

                        var arrayValue = arrayItem.ToString();

                        if (string.Compare(arrayValue, "true", false) == 0 || string.Compare(arrayValue, "false", false) == 0 || string.Compare(arrayValue, "null", false) == 0)
                        {
                            if (string.Compare(arrayValue, "true", false) == 0 ||
                                string.Compare(arrayValue, "false", false) == 0)
                            {
                                OnBasicItemDetected(arrayValue, JsonValueType.Boolean);
                            }
                            else
                            {
                                OnBasicItemDetected(arrayValue, JsonValueType.Null);
                            }

                            arrayItem.Reset();

                            reader.Store();
                            state = 22;

                            continue;
                        }
                        else
                        {
                            ParseError(json, state, reader.Position, JsonParseError.InvalidArrayItem, ch, "number | true | false | null | {array} | {object}");
                        }

                        break;
                }
            }
        exit_while:
            if (givenReader == null)
            {
                return;
            }
        }

        public KeyValuePair<string, string> ToJsonList(bool skipSchema = false, bool skipChildSchema = true, JsonSerializationOptions options = null)
        {
            var _options = new JsonSerializationOptions(options);
            var result = new StringBuilder();
            var properties = new StringBuilder();

            foreach (var x in GetProperties())
            {
                if (!skipSchema)
                {
                    properties.AppendFormatWithCommaIfNotEmpty("\"{0}\"", x.Key);
                }

                var value = x.Value;
                if (value == null)
                {
                    result.AppendWithCommaIfNotEmpty("null");
                    continue;
                }
                if (value is bool)
                {
                    result.AppendWithCommaIfNotEmpty(value.ToString().ToLower());
                    continue;
                }
                if (value.GetType().IsNumeric())
                {
                    result.AppendWithCommaIfNotEmpty(value.ToString());
                    continue;
                }
                if (value is char)
                {
                    result.AppendFormatWithCommaIfNotEmpty("'{0}'", value);
                    continue;
                }
                if (value is string)
                {
                    if (value != null)
                    {
                        result.AppendFormatWithCommaIfNotEmpty("\"{0}\"", HttpUtility.JavaScriptStringEncode(value.ToString()));
                    }
                    else
                    {
                        result.AppendWithCommaIfNotEmpty("");
                    }
                    continue;
                }

                var jm = value as JsonModel;

                if (jm != null)
                {
                    var jl = jm.ToJsonList(skipSchema, skipChildSchema, _options);

                    if (!skipChildSchema)
                    {
                        properties.AppendWithCommaIfNotEmpty(jl.Key);
                    }
                    
                    result.AppendWithCommaIfNotEmpty(jl.Value);
                    //result.AppendFormatWithCommaIfNotEmpty("{{\"Schema\":[{0}],\"Data\":{1}}}", jl.Key, jl.Value);

                    continue;
                }

                var e = value as IEnumerable;
                if (e != null)
                {
                    result.AppendWithCommaIfNotEmpty(e.ToJson(_options));
                    continue;
                }
                result.AppendWithCommaIfNotEmpty(value.ToString());
            }

            return new KeyValuePair<string, string>("[" + properties + "]", "[" + result + "]");
        }
    }
}
