using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Locust.Compression;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Json;
using Locust.Model;
using Locust.Modules.Api.Strategies;
using Locust.Serialization;
using Locust.ServiceModel;
using Locust.Tracing;

namespace Locust.Modules.Api.Service.ApiEngine
{
    public class ApiResponse : IJsonSerializable
    {
        private IBase64Compression compressor;
        public string Status { get; set; }

        public object Data { get; set; }
        public DateTime Date { get; set; }

        public bool Success { get; set; }
        public DataSource Source { get; set; }
        public MessageList Messages { get; set; }
        public ApiCallContext CallContext { get; protected set; }
        public ApiResponse(ApiCallContext callContext)
        {
            compressor = new ZlibCompression();
            Messages = new MessageList();
            Date = DateTime.Now;
            CallContext = callContext;
        }
        private bool IsCompressedResponseRequested()
        {
            if (CallContext != null && CallContext.HttpContext != null && CallContext.HttpContext.Request != null)
            {
                var Request = CallContext.HttpContext.Request;

                return CallContext.Api?.CompressedResponse || SafeClrConvert.ToBoolean(Request.Headers["x-request-compressed-response"]);
            }

            return false;
        }

        private bool SetCompressedResponseHeader(string value)
        {
            var Response = CallContext?.HttpContext?.Response;

            if (Response != null)
            {
                Response.Headers["x-compressed-response"] = value;

                return true;
            }

            return false;
        }
        private string compressResult(string result)
        {
            var buffer_length = SafeClrConvert.ToInt(CallContext?.EngineService?.Settings["Stream_Buffer_Length"]);

            return compressor.Base64Compress(result, new ZlibCompressionOptions {CompressBufferSize = buffer_length});
        }
        private async Task<string> compressResultAsync(string result)
        {
            var buffer_length = SafeClrConvert.ToInt(CallContext?.EngineService?.Settings["Stream_Buffer_Length"]);

            return await compressor.Base64CompressAsync(result, new ZlibCompressionOptions { CompressBufferSize = buffer_length });
        }
        public string ToJson(ApiEngineRunContext _context)
        {
            var context = CallContext;
            var data = "";
            var builder = new StringBuilder();
            var data_is_string = false;
            var json = Data as IJsonSerializable;

            if (json != null)
            {
                data = json.ToJson();
                goto end_serialize;
            }

            data_is_string = Data is string;

            if (data_is_string)
            {
                data = Data.ToString();
                
                goto end_serialize;
            }

            var enumerable = Data as IEnumerable;

            if (enumerable != null)
            {
                IEnumerable<JsonModel> jl = null;

                var useJsonList = (context != null && context.Api != null)
                    ? context.Api.UseArrayForJsonSerialization
                    : false;

                if (useJsonList)
                {
                    jl = Data as IEnumerable<JsonModel>;
                    useJsonList = jl != null;
                }

                if (useJsonList)
                {
                    data = jl.ToJsonList();
                }
                else
                {
                    foreach (var item in enumerable)
                    {
                        json = item as IJsonSerializable;

                        if (json != null)
                        {
                            builder.AppendWithComma(json.ToJson());
                        }
                        else
                        {
                            builder.AppendWithComma(JsonConvert.SerializeObject(item));
                        }
                    }

                    data = "[" + builder + "]";
                }

                goto end_serialize;
            }

            data = JsonConvert.SerializeObject(Data);
end_serialize:
            if (IsCompressedResponseRequested() && Success)
            {
                try
                {
                    var _data = compressResult(data);
                    if (SetCompressedResponseHeader("true"))
                    {
                        data = _data;
                        data_is_string = true;
                    }
                }
                catch (Exception e)
                {
                    if (_context != null)
                    {
                        _context.Log.Danger("ApiResponse", "ToJson", "CompressionFaulted", e);
                    }
                    SetCompressedResponseHeader("error");
                }
            }

            if (data_is_string)
            {
                data = '"' + data + '"';
            }

            var messages = Messages.ToJson();
            return string.Format("{{\"Success\":{0},\"Status\":\"{1}\",\"Date\":\"{2}\",\"Source\":\"{3}\",\"Data\":{4},\"Messages\":{5}}}",
                (Success ? "true" : "false"), Status, Date.ToUniversalTime().ToString("o"), Source.ToString(), data, messages);
        }
        public async Task<string> ToJsonAsync(ApiEngineRunContext _context)
        {
            var context = CallContext;
            var data = "";
            var builder = new StringBuilder();
            var data_is_string = false;
            var json = Data as IJsonSerializable;

            if (json != null)
            {
                data = json.ToJson();
                goto end_serialize;
            }

            data_is_string = Data is string;

            if (data_is_string)
            {
                data = Data.ToString();

                goto end_serialize;
            }

            var enumerable = Data as IEnumerable;

            if (enumerable != null)
            {
                IEnumerable<JsonModel> jl = null;

                var useJsonList = (context != null && context.Api != null)
                    ? context.Api.UseArrayForJsonSerialization
                    : false;

                if (useJsonList)
                {
                    jl = Data as IEnumerable<JsonModel>;
                    useJsonList = jl != null;
                }

                if (useJsonList)
                {
                    data = jl.ToJsonList();
                }
                else
                {
                    foreach (var item in enumerable)
                    {
                        json = item as IJsonSerializable;

                        if (json != null)
                        {
                            builder.AppendWithComma(json.ToJson());
                        }
                        else
                        {
                            builder.AppendWithComma(JsonConvert.SerializeObject(item));
                        }
                    }

                    data = "[" + builder + "]";
                }

                goto end_serialize;
            }

            data = JsonConvert.SerializeObject(Data);
            end_serialize:
            if (IsCompressedResponseRequested() && Success)
            {
                try
                {
                    var _data = await compressResultAsync(data);
                    if (SetCompressedResponseHeader("true"))
                    {
                        data = _data;
                        data_is_string = true;
                    }
                }
                catch (Exception e)
                {
                    if (_context != null)
                    {
                        _context.Log.Danger("ApiResponse", "ToJson", "CompressionFaulted", e);
                    }

                    SetCompressedResponseHeader("error");
                }
            }

            if (data_is_string)
            {
                data = '"' + data + '"';
            }

            var messages = Messages.ToJson();
            return string.Format("{{\"Success\":{0},\"Status\":\"{1}\",\"Date\":\"{2}\",\"Source\":\"{3}\",\"Data\":{4},\"Messages\":{5}}}",
                (Success ? "true" : "false"), Status, Date.ToUniversalTime().ToString("o"), Source.ToString(), data, messages);
        }
        public string ToJson(JsonSerializationOptions options = null)
        {
            return ToJson(_context: null);
        }
        public async Task<string> ToJsonAsync()
        {
            return await ToJsonAsync(null);
        }
    }
}
