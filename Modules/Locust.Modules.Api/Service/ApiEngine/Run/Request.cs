using System;
using System.Collections.Generic;
using System.Web;
using Locust.Base;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Json;
using Locust.Modules.Api.Service.ApiEngine;
using Locust.ServiceModel;
using Locust.WebTools;
using MyStringSplitOptions = Locust.Extensions.MyStringSplitOptions;

namespace Locust.Modules.Api.Strategies
{
    public partial class ApiEngineRunRequest : JsonModel, IBaseServiceRequest
    {
        public Func<Type, BaseService> ResolveService { get; set; }
        private ApiCallContext callContext;

        public ApiCallContext CallContext
        {
            get
            {
                if (callContext == null)
                {
                    callContext = new ApiCallContext();
                }
                return callContext;
            }
        }
        public string ShortName { get; set; }
        public string Lang { get; set; }
        private string api;
        public string Api
        {
            get { return api; }
            set
            {
                api = value;
                service = "";
                strategy = "";

                if (!string.IsNullOrEmpty(value) && !api.IsNumeric())
                {
                    var arr = value.Split('/', MyStringSplitOptions.TrimToLowerAndRemoveEmptyEntries);

                    if (arr.Length > 0)
                        service = arr[0];
                    if (arr.Length > 1)
                        strategy = arr[1];
                }
            }
        }
        private string service;
        public string Service
        {
            get { return service; }
        }

        private string strategy;

        public string Strategy
        {
            get { return strategy; }
        }
        public bool IsEncrypted { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }

        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType itemType)
        {
            if (string.Compare(propertyName, "api", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Api = propertyValue;
                return;
            }
            if (string.Compare(propertyName, "date", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Date = SafeClrConvert.ToDateTime(propertyValue);
                return;
            }
            if (string.Compare(propertyName, "lang", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Lang = propertyValue;
                return;
            }
            if (string.Compare(propertyName, "data", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Data = propertyValue;
                return;
            }
        }

        protected override bool OnObjectPropertyDetected(string propertyName, JsonReader reader)
        {
            if (string.Compare(propertyName, "data", StringComparison.OrdinalIgnoreCase) == 0)
            {
                var x = new EmptyJson { Accumulate = true };

                x.ReadJson(reader);

                Data = "{" + x.JsonString + "}";

                return true;
            }

            return false;
        }

        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("api", Api));
            result.Add(new KeyValuePair<string, object>("service", Service));
            result.Add(new KeyValuePair<string, object>("strategy", Strategy));
            result.Add(new KeyValuePair<string, object>("lang", Lang));
            result.Add(new KeyValuePair<string, object>("data", Data));
            result.Add(new KeyValuePair<string, object>("ip", CallContext.ClientIP));
            result.Add(new KeyValuePair<string, object>("date", Date));

            return result;

        }
    }
}