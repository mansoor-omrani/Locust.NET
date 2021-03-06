﻿using Locust.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Service
{
    public class ServiceResponse : IJsonSerializable
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Bag { get; set; }
        public DateTime Date { get; set; }
        public virtual bool Success { get; set; }
        public string MessageKey { get; set; }
        public string Status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Info { get; set; }
        private Dictionary<string, object> messageArgs;
        public Dictionary<string, object> MessageArgs
        {
            get
            {
                if (messageArgs == null)
                    messageArgs = new Dictionary<string, object>();

                return messageArgs;
            }
            set { messageArgs = value; }
        }
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Exception Exception { get; set; }
        private Dictionary<string, ServiceResponse> innerResponses;
        public Dictionary<string, ServiceResponse> InnerResponses
        {
            get
            {
                if (innerResponses == null)
                    innerResponses = new Dictionary<string, ServiceResponse>();

                return innerResponses;
            }
            set
            {
                innerResponses = value;
            }
        }
        public bool ShouldSerializeInnerResponses()
        {
            return innerResponses?.Count > 0;
        }
        public bool ShouldSerializeMessageArgs()
        {
            return messageArgs?.Count > 0;
        }
        public virtual bool IsNotFound()
        {
            return string.Compare(Status, "NotFound", true) == 0;
        }
        public virtual bool IsFailed()  // business error
        {
            return string.Compare(Status, "Failed", true) == 0;
        }
        public virtual bool IsErrored() // calling sproc or executing sql failed (invalid number of params, invalid args, missing sproc, error in sql, etc.)
        {
            return string.Compare(Status, "Errored", true) == 0;
        }
        public virtual bool IsFaulted() // error reported by sql or sproc (an error happened inside sproc, the sproc handled the error and reported it)
                                        // executing the sproc altogether didn't fail.
        {
            return string.Compare(Status, "Faulted", true) == 0;
        }
        public virtual bool IsFlawed() // calling action failed
        {
            return string.Compare(Status, "Flawed", true) == 0;
        }
        public virtual bool IsSucceeded()
        {
            return Success;
        }
        public virtual void Succeeded()
        {
            Success = true;
            Status = "Success";
        }
        public virtual void Failed(Exception e = null)
        {
            Success = false;
            Status = "Failed";
            Exception = e;
        }
        public virtual void Faulted(Exception e = null)
        {
            Success = false;
            Status = "Faulted";
            Exception = e;
        }
        public virtual void Flawed(Exception e = null)
        {
            Success = false;
            Status = "Flawed";
            Exception = e;
        }
        public virtual void NotFound()
        {
            Success = false;
            Status = "NotFound";
        }
        public virtual void Errored(Exception e = null)
        {
            Success = false;
            Status = "Errored";
            Exception = e;
        }
        public virtual void Deleted()
        {
            Success = false;
            Status = "Deleted";
        }
        public virtual void SetStatus(object value, Exception e = null)
        {
            Success = false;

            Status = value?.ToString() ?? "";

            if (Status.ToLower().Contains("success") || Status.ToLower().Contains("succeed"))
            {
                Success = true;
            }

            Exception = e;
        }
        public virtual bool HasStatus(object value)
        {
            var status = value?.ToString();

            return string.Compare(Status, status, true) == 0;
        }
        public ServiceResponse()
        {
            Date = DateTime.Now;
        }
        public virtual void Copy(ServiceResponse response)
        {
            this.Bag = response.Bag;
            this.Date = response.Date;
            this.Success = response.Success;
            this.MessageKey = response.MessageKey;
            this.Status = response.Status;
            this.Info = response.Info;
            this.MessageArgs = response.messageArgs;
            this.Message = response.Message;
            this.Exception = response.Exception;
            this.InnerResponses = response.InnerResponses;
        }
        public virtual void Copy<U>(ServiceResponse<U> response)
        {
            Copy(response as ServiceResponse);
        }
        public void AppendMessage(string message)
        {
            Message += "\n" + message;
        }
        public bool HasMessageArgs()
        {
            return messageArgs != null && messageArgs.Count > 0;
        }
        public bool HasInnerResponses()
        {
            return innerResponses != null && innerResponses.Count > 0;
        }

        public string ToJson(JsonSerializationOptions options = null)
        {
            var _innerResponses = "";

            if (HasInnerResponses())
            {
                var sb = new StringBuilder();

                foreach (var res in InnerResponses)
                {
                    if (sb.Length == 0)
                    {
                        sb.Append(",\"InnerResponses\": [" + res.Value.ToJson());
                    }
                    else
                    {
                        sb.Append("," + res.Value.ToJson());
                    }
                }

                sb.Append("]");

                _innerResponses = sb.ToString();
            }

            var exception = "";
            if (Exception != null)
            {
                exception = ",\"Exception\": " + JsonConvert.SerializeObject(Exception);
            }

            var info = "";
            if (Info != null)
            {
                info = ",\"Info\": " + JsonConvert.SerializeObject(Info);
            }

            var data = "";
            var prop = this.GetType().GetProperty("Data");
            if (prop != null)
            {
                var dataValue = prop.GetValue(this, null);
                if (dataValue != null)
                {
                    data = ",\"Data\": " + JsonConvert.SerializeObject(dataValue);
                }
            }
            var result = $@"{{""Success"": {Success.ToString().ToLower()},""Status"": ""{Status}"", ""Date"":""{Date:yyyy/MM/dd HH:mm:ss.fffffff}"",""Message"": ""{HttpUtility.JavaScriptStringEncode(Message)}""{data}{info}{exception}{_innerResponses}}}";

            return result;
        }
        public string[] ExtractMessages()
        {
            var result = new List<string>();

            result.Add(this.Message);

            if (this.innerResponses != null && this.innerResponses.Count > 0)
            {
                foreach (var msg in this.InnerResponses)
                {
                    var _r = msg.Value.ExtractMessages();

                    foreach (var m in _r)
                    {
                        result.Add(m);
                    }
                }
            }

            return result.ToArray();
        }
        public string FlattenMessage(string separator = "\n")
        {
            var messages = ExtractMessages();
            var sb = new StringBuilder();

            foreach (var msg in messages)
            {
                if (sb.Length == 0)
                {
                    sb.Append(msg);
                }
                else
                {
                    sb.Append(separator + msg);
                }
            }

            return sb.ToString();
        }
        private int innerResponseCount;
        public void AddInnerResponse(string status, string key = "", bool useInternalCounter = true)
        {
            var _key = string.IsNullOrEmpty(key) ? ("InnerResponse-" + innerResponseCount++) : key + (useInternalCounter ? "-" + (innerResponseCount++).ToString() : "");

            InnerResponses.Add(_key, new ServiceResponse { Status = status });
        }
    }
    public class ServiceResponse<T> : ServiceResponse
    {
        private T data;
        private bool ignoreDefaultData { get; set; }
        public ServiceResponse()
        {
            ignoreDefaultData = true;
        }
        public T Data
        {
            get
            {
                var type = typeof(T);

                if (!ignoreDefaultData && type.IsClass && !type.IsAbstract && !type.IsArray && ((object)data) == null)
                {
                    CreateData();
                }

                return data;
            }
            set { data = value; }
        }
        public override void Copy<U>(ServiceResponse<U> response)
        {
            var x = (object)response.Data;

            try
            {
                this.Data = (T)x;
            }
            catch
            { }

            base.Copy<U>(response);
        }
        public virtual void CreateData()
        {
            try
            {
                this.Data = Activator.CreateInstance<T>();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        public void Succeeded(T data)
        {
            this.Data = data;
            Succeeded();
        }
        public void IgnoreDefaultData(bool value)
        {
            this.ignoreDefaultData = value;
        }
    }

    public class PagingResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public long RecordCount { get; set; }
        public List<T> Items { get; set; }
    }
    public class ServicePagingResponse<T> : ServiceResponse<PagingResult<T>>
    {
    }
}
