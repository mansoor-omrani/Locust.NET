using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.ApiClient
{
    public class SendFile
    {
        public string FilePath { get; set; }
        public string ContentType { get; set; }
    }
    public class SendData
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
    }
    public interface IApiClientBase
    {
        ApiClientConfig Config { get; set; }
        ApiResponse Invoke(ApiRequest request);
        Task<ApiResponse> InvokeAsync(ApiRequest request, CancellationToken token);
        ApiResponse Invoke(ApiRequest request, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        Task<ApiResponse> InvokeAsync(ApiRequest request, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
    }

    public interface IApiClient: IApiClientBase
    {
        ApiResponse Get(string api, string contentType = "");
        ApiResponse Get(string api, string contentType, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        ApiResponse Delete(string api, string contentType = "");
        ApiResponse Delete(string api, string contentType, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        ApiResponse Post(string api, string contentType, byte[] data);
        ApiResponse Post(string api, string contentType, byte[] data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        ApiResponse Post(string api, Dictionary<string, object> formData);
        ApiResponse Post(string api, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        ApiResponse Post(string api, string contentType, string data);
        ApiResponse Post(string api, string contentType, string data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        ApiResponse Put(string api, string contentType, byte[] data);
        ApiResponse Put(string api, string contentType, byte[] data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        ApiResponse Put(string api, string contentType, string data);
        ApiResponse Put(string api, string contentType, string data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        ApiResponse Send(string api, string filepath, Dictionary<string, object> formData = null, string contentType = "");
        ApiResponse Send(string api, string filepath, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, string contentType);
        ApiResponse Send(string api, string filename, byte[] data, Dictionary<string, object> formData = null, string contentType = "");
        ApiResponse Send(string api, string filename, byte[] data, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, string contentType);
        // ---------------------------- Async --------------------------
        Task<ApiResponse> GetAsync(string api, string contentType = "");
        Task<ApiResponse> GetAsync(string api, string contentType, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
        Task<ApiResponse> DeleteAsync(string api, string contentType = "");
        Task<ApiResponse> DeleteAsync(string api, string contentType, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
        Task<ApiResponse> PostAsync(string api, string contentType, byte[] data);
        Task<ApiResponse> PostAsync(string api, string contentType, byte[] data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
        Task<ApiResponse> PostAsync(string api, Dictionary<string, object> formData);
        Task<ApiResponse> PostAsync(string api, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
        Task<ApiResponse> PostAsync(string api, string contentType, string data);
        Task<ApiResponse> PostAsync(string api, string contentType, string data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
        Task<ApiResponse> PutAsync(string api, string contentType, byte[] data);
        Task<ApiResponse> PutAsync(string api, string contentType, byte[] data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
        Task<ApiResponse> PutAsync(string api, string contentType, string data);
        Task<ApiResponse> PutAsync(string api, string contentType, string data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
        Task<ApiResponse> SendAsync(string api, string filepath, Dictionary<string, object> formData = null, string contentType = "");
        Task<ApiResponse> SendAsync(string api, string filepath, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, string contentType, CancellationToken token);
        Task<ApiResponse> SendAsync(string api, string filename, byte[] data, Dictionary<string, object> formData = null, string contentType = "");
        Task<ApiResponse> SendAsync(string api, string filename, byte[] data, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, string contentType, CancellationToken token);
        // ------------------- Send (multiple files ----------------------
        ApiResponse Send(string api, SendFile[] files, Dictionary<string, object> formData = null);
        ApiResponse Send(string api, SendFile[] files, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);
        ApiResponse Send(string api, SendData[] files, Dictionary<string, object> formData = null);
        ApiResponse Send(string api, SendData[] files, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer);

        Task<ApiResponse> SendAsync(string api, SendFile[] files, Dictionary<string, object> formData = null);
        Task<ApiResponse> SendAsync(string api, SendFile[] files, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
        Task<ApiResponse> SendAsync(string api, SendData[] files, Dictionary<string, object> formData = null);
        Task<ApiResponse> SendAsync(string api, SendData[] files, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token);
    }
}
