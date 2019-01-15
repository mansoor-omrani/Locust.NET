using Locust.ApiClient;
using Locust.Configuration;
using Locust.Logging;
using Locust.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.IPStack
{
    public class IPStackLookupResultLanguage
    {
        public string code { get; set; }
        public string name { get; set; }
        public string native { get; set; }
    }
    public class IPStackLookupResultLocation
    {
        public int? geoname_id { get; set; }
        public string capital { get; set; }
        public List<IPStackLookupResultLanguage> languages { get; set; }
        public string country_flag { get; set; }
        public string country_flag_emoji { get; set; }
        public string country_flag_emoji_unicode { get; set; }
        public string calling_code { get; set; }
        public bool is_eu { get; set; }
    }
    public class IPStackLookupResultTimeZone
    {
        public string id { get; set; }
        public string current_time { get; set; }
        public int? gmt_offset { get; set; }
        public string code { get; set; }
        public bool is_daylight_saving { get; set; }
    }
    public class IPStackLookupResultCurrency
    {
        public string code { get; set; }
        public string name { get; set; }
        public string plural { get; set; }
        public string symbol { get; set; }
        public string symbol_native { get; set; }
    }
    public class IPStackLookupResultConnection
    {
        public int? asn { get; set; }
        public string isp { get; set; }
    }
    public class IPStackLookupResultSecurity
    {
        public bool is_proxy { get; set; }
        public string proxy_type { get; set; }
        public bool is_crawler { get; set; }
        public string crawler_name { get; set; }
        public string crawler_type { get; set; }
        public bool is_tor { get; set; }
        public string threat_level { get; set; }
        public object threat_types { get; set; }
    }
    public class IPStackLookupResult
    {
        public string ip { get; set; }
        public string hostname { get; set; }
        public string type { get; set; }
        public string continent_code { get; set; }
        public string continent_name { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public IPStackLookupResultLocation location { get; set; }
        public IPStackLookupResultTimeZone time_zone { get; set; }
        public IPStackLookupResultCurrency currency { get; set; }
        public IPStackLookupResultConnection connection { get; set; }
        public IPStackLookupResultSecurity security { get; set; }
    }
    public class IPStackLookupError
    {
        public int? code { get; set; }
        public string type { get; set; }
        public string info { get; set; }
    }
    public class IPStackLookupErrorResult
    {
        public bool success { get; set; }
       public IPStackLookupError error { get; set; }
    }
    public enum IPStackLookupOutputFormat { json, xml }
    public class IPStackLookupRequest
    {
        public string IP { get; set; }
        public string Fields { get; set; }
        public bool? HostName { get; set; }
        public bool? Security { get; set; }
        public string Language { get; set; }
        public string Callback { get; set; }
        public IPStackLookupOutputFormat? Output { get; set; }
        
        public override string ToString()
        {
            var result = "";

            if (!string.IsNullOrEmpty(Fields))
            {
                result = (result == "" ? "" : "&") + "fields=" + Fields;
            }

            if (HostName.HasValue)
            {
                result = (result == "" ? "" : "&") + "hostname=" + (HostName.Value ? "1" : "0");
            }

            if (Security.HasValue)
            {
                result = (result == "" ? "" : "&") + "security=" + (Security.Value ? "1" : "0");
            }

            if (!string.IsNullOrEmpty(Language))
            {
                result = (result == "" ? "" : "&") + "language=" + Language;
            }

            if (!string.IsNullOrEmpty(Callback))
            {
                result = (result == "" ? "" : "&") + "callback=" + Callback;
            }

            if (Output.HasValue)
            {
                result = (result == "" ? "" : "&") + "output=" + Output.Value.ToString();
            }

            return result;
        }
    }
    public class IPStackLookupResponse: ServiceResponse<IPStackLookupResult>
    {
        public ApiResponse WebResponse { get; set; }
        public IPStackLookupErrorResult Error { get; set; }
    }
    public interface IIPStackClient
    {
        IPStackLookupResponse Lookup(IPStackLookupRequest request);
        Task<IPStackLookupResponse> LookupAsync(IPStackLookupRequest request);
        IPStackLookupResponse Check(IPStackLookupRequest request);
        Task<IPStackLookupResponse> CheckAsync(IPStackLookupRequest request);
    }
    public class IPStackClient : IIPStackClient
    {
        public bool Https { get; set; }
        public string BaseUrl { get; set; }
        public string Host
        {
            get
            {
                return $"{(Https ? "https" : "http")}://{BaseUrl}/";
            }
        }
        public string Key { get; set; }
        public ILogger Logger { get; set; }
        private ApiClient.ApiClient client;
        public ApiClient.ApiClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new ApiClient.ApiClient(new ApiClientConfig { Logger = Logger, Host = Host });
                }

                return client;
            }
            set { client = value; }
        }
        public IPStackClient(): this(null)
        {

        }
        public IPStackClient(ILogger logger)
        {
            BaseUrl = "api.ipstack.com";
            Key = Config.AppSettings.IPStackKey;
            Logger = logger;
        }
        private void Finalize(IPStackLookupResponse response, ApiResponse cr)
        {
            response.Copy(cr);
            response.WebResponse = cr;

            if (cr.IsSucceeded())
            {
                if (!string.IsNullOrEmpty(cr.Result))
                {

                    try
                    {
                        response.Data = JsonConvert.DeserializeObject<IPStackLookupResult>(cr.Result);
                        response.Succeeded();
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            response.Error = JsonConvert.DeserializeObject<IPStackLookupErrorResult>(cr.Result);
                            if (response.Error != null && response.Error.error != null)
                            {
                                response.SetStatus(response.Error.error.type);
                            }
                            else
                            {
                                response.Errored(e);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.Faulted(ex);
                        }
                    }
                }
                else
                {
                    response.SetStatus("EmptyResponse");
                }
            }
            else
            {
                response.Failed(cr.Exception);
            }
        }
        public IPStackLookupResponse Lookup(IPStackLookupRequest request)
        {
            var response = new IPStackLookupResponse();

            var cr = Client.Get($"{request.IP}?access_key={Key}{request}");

            Finalize(response, cr);

            return response;
        }
        public async Task<IPStackLookupResponse> LookupAsync(IPStackLookupRequest request)
        {
            var response = new IPStackLookupResponse();

            var cr = await Client.GetAsync($"{request.IP}?access_key={Key}{request}");

            Finalize(response, cr);

            return response;
        }
        public IPStackLookupResponse Check(IPStackLookupRequest request)
        {
            var response = new IPStackLookupResponse();

            var cr = Client.Get($"check?access_key={Key}{request}");

            Finalize(response, cr);

            return response;
        }
        public async Task<IPStackLookupResponse> CheckAsync(IPStackLookupRequest request)
        {
            var response = new IPStackLookupResponse();

            var cr = await Client.GetAsync($"check?access_key={Key}{request}");

            Finalize(response, cr);

            return response;
        }
    }
}
