using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;
using Locust.Logging;
using Locust.WebExtensions;
using System.Threading;
using Locust.Mime;

namespace Locust.ApiClient
{
    public class ApiClientBase:IApiClientBase
    {
        protected ApiClientConfig _config;
        public ApiClientConfig Config
        {
            get
            {
                if (_config == null)
                    _config = new ApiClientConfig();

                return _config;
            }
            set { _config = value; }
        }
        private void Init(ApiClientConfig config)
        {
            if (config == null)
                throw new ArgumentException("config");

            _config = config;

            if (_config.Logger == null)
                _config.Logger = new NullLogger();
        }
        public ApiClientBase()
        {
            Init(new ApiClientConfig());
        }
        public ApiClientBase(ApiClientConfig config)
        {
            Init(config);
        }

        private void Log(Func<object> log)
        {
            if (Config.Logger != null && !(Config.Logger is NullLogger))
            {
                Config.Logger.Log(log());
            }
        }
        private void LogCategory(Func<object> log)
        {
            if (Config.Logger != null && !(Config.Logger is NullLogger))
            {
                Config.Logger.LogCategory(log());
            }
        }
        private WebRequest CreateWebRequest(ApiRequest request, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            if (string.IsNullOrEmpty(_config.Host))
            {
                throw new ArgumentException("config.Host");
            }

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var target = _config.Host + ((_config.Port == 0 || _config.Port == 80) ? "" : ":" + _config.Port) + _config.BaseAddress + request.Api;

            LogCategory(() => "sending web request to " + target);
            Log(() => "creating web request ...");
            Log(() => "validating config.Host, config.BaseAddress, request ...");

            var result = WebRequest.Create(target);

            Log(() => "HttpMethod: " + request.Method);

            result.Method = request.Method.Method;

            if (!string.IsNullOrEmpty(request.ContentType))
            {
                Log(() => "Content-Type: " + request.ContentType);
                result.ContentType = request.ContentType;
            }
            
            if (requestInitializer != null)
            {
                Log(() => "initializing request ...");

                var r = requestInitializer(request, result);

                if (r != null)
                {
                    Log(() => "web request object replaced by initialization result");

                    result = r;
                }
            }

            var req = result as HttpWebRequest;

            if (req != null)
            {
                //Log(() => "response.Cookies:\n\t" + req.CookieContainer.GetCookies().Join());
                Log(() => "response.Headers:\n\t" + req.Headers.Join());
            }

            return result;
        }

        public ApiResponse Invoke(ApiRequest request)
        {
            return Invoke(request, null);
        }
        public ApiResponse Invoke(ApiRequest request, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            var result = new ApiResponse();
            var wr = CreateWebRequest(request, requestInitializer);

            try
            {
                Stream dataStream;

                if (request.Body != null && request.Body.Length > 0)
                {
                    wr.ContentLength = request.Body.Length;
                    
                    Log(() => "getting request stream ...");
                    
                    dataStream = wr.GetRequestStream();

                    Log(() => string.Format("writing in request stream {0} bytes ...", request.Body.Length));

                    dataStream.Write(request.Body, 0, request.Body.Length);
                    dataStream.Close();

                    Log(() => "request stream closed");
                }

                Log(() => "getting web response ...");

                var response = wr.GetResponse();

                Log(() => "getting response stream ...");

                dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);

                Log(() => "reading response stream ...");

                var rawData = reader.ReadToEnd();

                result.Result = rawData;
                result.WebResponse = response as HttpWebResponse;

                reader.Close();
                dataStream.Close();
                Log(() => "response stream closed");
                response.Close();
                Log(() => "web response closed");

                Log(() => "response.Size: " + result.Result.Length);
                Log(() => "response.ContentType: " + result.WebResponse.ContentType);
                Log(() => "response.StatusCode: " + result.WebResponse.StatusCode);
                Log(() => "response.Cookies:\n\t" + result.WebResponse.Cookies.Join());
                Log(() => "response.Headers:\n\t" + result.WebResponse.Headers.Join());
                Log(() => "response:\n\t" + result.Result);

                result.Succeeded();
            }
            catch (WebException ex)
            {
                result.Failed(ex);

                Log(() => "web exception occured ...");
                Log(() => ex);

                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var rawData = reader.ReadToEnd();
                        result.Result = rawData;
                        result.WebResponse = ex.Response as HttpWebResponse;
                    }
                }
            }
            catch (Exception e)
            {
                result.Failed(e);

                Log(() => "web request faced with exception ...");
                Log(() => e);
            }

            return result;
        }

        public Task<ApiResponse> InvokeAsync(ApiRequest request, CancellationToken token)
        {
            return InvokeAsync(request, null, token);
        }
        public async Task<ApiResponse> InvokeAsync(ApiRequest request, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            var result = new ApiResponse();
            
            try
            {
                var wr = CreateWebRequest(request, requestInitializer);

                Stream dataStream;

                if (request.Body != null && request.Body.Length > 0)
                {
                    wr.ContentLength = request.Body.Length;

                    Log(() => "getting request stream ...");

                    dataStream = await wr.GetRequestStreamAsync();

                    Log(() => string.Format("writing in request stream {0} bytes ...", request.Body.Length));
                    
                    await dataStream.WriteAsync(request.Body, 0, request.Body.Length, token);
                    
                    dataStream.Close();

                    Log(() => "request stream closed");
                }
                
                Log(() => "getting web response ...");

                var response = await wr.GetResponseAsync();

                Log(() => "getting response stream ...");

                dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);

                token.Register(() => dataStream.Close());

                Log(() => "reading response stream ...");
                
                var rawData = await reader.ReadToEndAsync();

                result.Result = rawData;
                result.WebResponse = response as HttpWebResponse;

                reader.Close();
                dataStream.Close();
                Log(() => "response stream closed");
                response.Close();
                Log(() => "web response closed");

                Log(() => "response.Size: " + result.Result.Length);
                Log(() => "response.ContentType: " + result.WebResponse.ContentType);
                Log(() => "response.StatusCode: " + result.WebResponse.StatusCode);
                Log(() => "response.Cookies:\n\t" + result.WebResponse.Cookies.Join());
                Log(() => "response.Headers:\n\t" + result.WebResponse.Headers.Join());
                Log(() => "response:\n\t" + result.Result);

                result.Succeeded();
            }
            catch (WebException ex)
            {
                result.Failed(ex);

                Log(() => "web exception occured ...");
                Log(() => ex);

                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var rawData = await reader.ReadToEndAsync();
                        result.Result = rawData;
                        result.WebResponse = ex.Response as HttpWebResponse;
                    }
                }
            }
            catch (Exception e)
            {
                result.Failed(e);

                Log(() => "web request faced with exception ...");
                Log(() => e);
            }

            return result;
        }
    }
    public class ApiClient:ApiClientBase, IApiClient
    {
        public ApiClient()
        {
        }
        public ApiClient(ApiClientConfig config):base(config)
        {
        }
        private Func<ApiRequest, WebRequest, WebRequest> PrepareRequestInitializer(Func<ApiRequest, WebRequest, WebRequest> requestInitializer, bool expect100 = true)
        {
            return (areq, req) =>
            {
                (req as HttpWebRequest).ServicePoint.Expect100Continue = expect100;

                if (requestInitializer != null)
                {
                    req = requestInitializer(areq, req);
                }

                return req;
            };
        }
        #region Sync Methods
        public ApiResponse Get(string api, string contentType = "")
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Method = HttpMethod.Get});
        }
        public ApiResponse Get(string api, string contentType, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Method = HttpMethod.Get}, requestInitializer);
        }
        public ApiResponse Delete(string api, string contentType = "")
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Method = HttpMethod.Delete });
        }
        public ApiResponse Delete(string api, string contentType, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Method = HttpMethod.Delete }, requestInitializer);
        }
        public ApiResponse Post(string api, string contentType, byte[] data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Body = data, Method = HttpMethod.Post }, requestInitializer);
        }
        public ApiResponse Post(string api, string contentType, string data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Body = Encoding.UTF8.GetBytes(data), Method = HttpMethod.Post }, requestInitializer);
        }
        public ApiResponse Post(string api, string contentType, byte[] data)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Body = data, Method = HttpMethod.Post});
        }
        public ApiResponse Post(string api, string contentType, string data)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Body = Encoding.UTF8.GetBytes(data), Method = HttpMethod.Post });
        }
        public ApiResponse Put(string api, string contentType, byte[] data)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Body = data, Method = HttpMethod.Put });
        }
        public ApiResponse Put(string api, string contentType, string data)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Body = Encoding.UTF8.GetBytes(data), Method = HttpMethod.Put });
        }
        public ApiResponse Put(string api, string contentType, byte[] data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Body = data, Method = HttpMethod.Put }, requestInitializer);
        }
        public ApiResponse Put(string api, string contentType, string data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            return Invoke(new ApiRequest { Api = api, ContentType = contentType, Body = Encoding.UTF8.GetBytes(data), Method = HttpMethod.Put }, requestInitializer);
        }
        public ApiResponse Send(string api, string filepath, Dictionary<string, object> formData = null, string contentType = "")
        {
            return Send(api, filepath, formData, null, contentType);
        }
        public ApiResponse Send(string api, string filepath, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, string contentType)
        {
            var result = new ApiResponse();

            try
            {
                // helper:  https://stackoverflow.com/questions/36745769/send-files-using-httpwebrequest
                //          https://technet.rapaport.com/Info/LotUpload/SampleCode/Full_Example.aspx

                var boundary = CreateSendBoundary();
                var body = GetPostData(contentType, filepath, formData, boundary);

                result = Invoke(new ApiRequest { Api = api, ContentType = "multipart/form-data; boundary=" + boundary, Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer));
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        public ApiResponse Post(string api, Dictionary<string, object> formData)
        {
            return Post(api, formData, null);
        }
        public ApiResponse Post(string api, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            var result = new ApiResponse();

            try
            {
                var postData = formData.Join("&");
                var body = Encoding.UTF8.GetBytes(postData);

                result = Invoke(new ApiRequest { Api = api, ContentType = "application/x-www-form-urlencoded", Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer));
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        public ApiResponse Send(string api, string filename, byte[] data, Dictionary<string, object> formData = null, string contentType = "")
        {
            return Send(api, filename, data, formData, null, contentType);
        }
        public ApiResponse Send(string api, string filename, byte[] data, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, string contentType)
        {
            var result = new ApiResponse();

            try
            {
                var boundary = CreateSendBoundary();
                var body = GetPostData(contentType, filename, data, formData, boundary);

                result = Invoke(new ApiRequest { Api = api, ContentType = "multipart/form-data; boundary=" + boundary, Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer));
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        #endregion
        #region Send Helpers
        private static string CreateSendBoundary()
        {
            return "---------------------------" + DateTime.Now.Ticks.ToString("x");
        }
        private static void AddFormData(MemoryStream postDataStream, string boundary, Dictionary<string, object> formData)
        {
            if (formData != null && formData.Count > 0)
            {
                var formDataHeaderTemplate = "--" + boundary + Environment.NewLine +
                "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine;

                foreach (var item in formData)
                {
                    var formItemBytes = Encoding.UTF8.GetBytes(string.Format(formDataHeaderTemplate, item.Key, item.Value));
                    postDataStream.Write(formItemBytes, 0, formItemBytes.Length);
                }
            }
        }
        private static async Task AddFormDataAsync(MemoryStream postDataStream, string boundary, Dictionary<string, object> formData, CancellationToken token)
        {
            if (formData != null && formData.Count > 0)
            {
                var formDataHeaderTemplate = "--" + boundary + Environment.NewLine +
                "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment.NewLine + "{1}" + Environment.NewLine;

                foreach (var item in formData)
                {
                    var formItemBytes = Encoding.UTF8.GetBytes(string.Format(formDataHeaderTemplate, item.Key, item.Value));
                    await postDataStream.WriteAsync(formItemBytes, 0, formItemBytes.Length, token);
                }
            }
        }
        private static void AddFile(MemoryStream postDataStream, string boundary, string filePath, string contentType)
        {
            //adding file data
            var fileInfo = new FileInfo(filePath);
            var _contentType = string.IsNullOrEmpty(contentType) ? MimeHelper.GetMimeType(filePath) : contentType;
            var header =
                $"--{boundary}{Environment.NewLine}Content-Disposition: form-data; name=\"{fileInfo.Name}\"; filename=\"{fileInfo.FullName}\"{Environment.NewLine}Content-Type: {_contentType}{Environment.NewLine}{Environment.NewLine}";

            var headerBytes = Encoding.UTF8.GetBytes(header);

            postDataStream.Write(headerBytes, 0, headerBytes.Length);

            using (var fileStream = fileInfo.OpenRead())
            {
                var buffer = new byte[32768];   // 32KB buffer

                int bytesRead = 0;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    postDataStream.Write(buffer, 0, bytesRead);
                }

                fileStream.Close();
            }
        }
        private static async Task AddFileAsync(MemoryStream postDataStream, string boundary, string filePath, string contentType, CancellationToken token)
        {
            //adding file data
            var fileInfo = new FileInfo(filePath);
            var _contentType = string.IsNullOrEmpty(contentType) ? MimeHelper.GetMimeType(filePath) : contentType;
            var header =
                $"--{boundary}{Environment.NewLine}Content-Disposition: form-data; name=\"{fileInfo.Name}\"; filename=\"{fileInfo.FullName}\"{Environment.NewLine}Content-Type: {_contentType}{Environment.NewLine}{Environment.NewLine}";

            var headerBytes = Encoding.UTF8.GetBytes(header);

            postDataStream.Write(headerBytes, 0, headerBytes.Length);

            using (var fileStream = fileInfo.OpenRead())
            {
                var buffer = new byte[16384];   // 16KB buffer

                int bytesRead = 0;

                while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length, token)) != 0)
                {
                    await postDataStream.WriteAsync(buffer, 0, bytesRead, token);
                }

                fileStream.Close();
            }
        }
        private static void AddData(MemoryStream postDataStream, string boundary, string filename, byte[] data, string contentType)
        {
            //adding file data
            var _contentType = string.IsNullOrEmpty(contentType) ? MimeHelper.GetMimeType(filename) : contentType;
            var header =
                $"--{boundary}{Environment.NewLine}Content-Disposition: form-data; name=\"{Path.GetFileNameWithoutExtension(filename)}\"; filename=\"{filename}\"{Environment.NewLine}Content-Type: {_contentType}{Environment.NewLine}{Environment.NewLine}";

            var headerBytes = Encoding.UTF8.GetBytes(header);

            postDataStream.Write(headerBytes, 0, headerBytes.Length);

            if (data != null && data.Length > 0)
            {
                postDataStream.Write(data, 0, data.Length);
            }
        }
        private static async Task AddDataAsync(MemoryStream postDataStream, string boundary, string filename, byte[] data, string contentType, CancellationToken token)
        {
            //adding file data
            var _contentType = string.IsNullOrEmpty(contentType) ? MimeHelper.GetMimeType(filename) : contentType;
            var header =
                $"--{boundary}{Environment.NewLine}Content-Disposition: form-data; name=\"{Path.GetFileNameWithoutExtension(filename)}\"; filename=\"{filename}\"{Environment.NewLine}Content-Type: {_contentType}{Environment.NewLine}{Environment.NewLine}";

            var headerBytes = Encoding.UTF8.GetBytes(header);

            await postDataStream.WriteAsync(headerBytes, 0, headerBytes.Length, token);

            if (data != null && data.Length > 0)
            {
                await postDataStream.WriteAsync(data, 0, data.Length, token);
            }
        }
        private static void FinalizePostData(MemoryStream postDataStream, string boundary)
        {
            var endBoundaryBytes = Encoding.UTF8.GetBytes(Environment.NewLine + "--" + boundary + "--");
            postDataStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
        }
        private static async Task FinalizePostDataAsync(MemoryStream postDataStream, string boundary, CancellationToken token)
        {
            var endBoundaryBytes = Encoding.UTF8.GetBytes(Environment.NewLine + "--" + boundary + "--");
            await postDataStream.WriteAsync(endBoundaryBytes, 0, endBoundaryBytes.Length, token);
        }
        private static byte[] GetPostData(string contentType, string filePath, Dictionary<string, object> formData, string boundary)
        {
            var postDataStream = new MemoryStream();
            //adding form data
            AddFormData(postDataStream, boundary, formData);

            AddFile(postDataStream, boundary, filePath, contentType);

            FinalizePostData(postDataStream, boundary);

            return postDataStream.ToArray();
        }
        private static byte[] GetPostData(SendFile[] files, Dictionary<string, object> formData, string boundary)
        {
            var postDataStream = new MemoryStream();
            //adding form data
            AddFormData(postDataStream, boundary, formData);

            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    AddFile(postDataStream, boundary, file.FilePath, file.ContentType);
                }
            }
            
            FinalizePostData(postDataStream, boundary);

            return postDataStream.ToArray();
        }
        private static byte[] GetPostData(string contentType, string filename, byte[] data, Dictionary<string, object> formData, string boundary)
        {
            var postDataStream = new MemoryStream();
            //adding form data
            AddFormData(postDataStream, boundary, formData);

            AddData(postDataStream, boundary, filename, data, contentType);

            FinalizePostData(postDataStream, boundary);

            return postDataStream.ToArray();
        }
        private static byte[] GetPostData(SendData[] files, Dictionary<string, object> formData, string boundary)
        {
            var postDataStream = new MemoryStream();
            //adding form data
            AddFormData(postDataStream, boundary, formData);

            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    AddData(postDataStream, boundary, file.FileName, file.Data, file.ContentType);
                }
            }

            FinalizePostData(postDataStream, boundary);

            return postDataStream.ToArray();
        }
        #endregion
        #region Async Methods
        // ----------------------------- Async ---------------------------
        public Task<ApiResponse> GetAsync(string api, string contentType = "")
        {
            return GetAsync(api, contentType, null, CancellationToken.None);
        }
        public Task<ApiResponse> GetAsync(string api, string contentType, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            return InvokeAsync(new ApiRequest { Api = api, ContentType = contentType, Method = HttpMethod.Get }, requestInitializer, token);
        }
        public Task<ApiResponse> DeleteAsync(string api, string contentType = "")
        {
            return DeleteAsync(api, contentType, null, CancellationToken.None);
        }
        public Task<ApiResponse> DeleteAsync(string api, string contentType, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            return InvokeAsync(new ApiRequest { Api = api, ContentType = contentType, Method = HttpMethod.Delete }, requestInitializer, token);
        }
        public Task<ApiResponse> PostAsync(string api, string contentType, byte[] data)
        {
            return PostAsync(api, contentType, data, null, CancellationToken.None);
        }
        public Task<ApiResponse> PostAsync(string api, string contentType, byte[] data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            return InvokeAsync(new ApiRequest { Api = api, ContentType = contentType, Body = data, Method = HttpMethod.Post }, requestInitializer, token);
        }
        public Task<ApiResponse> PostAsync(string api, string contentType, string data)
        {
            return PostAsync(api, contentType, data, null, CancellationToken.None);
        }
        public Task<ApiResponse> PostAsync(string api, string contentType, string data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            return InvokeAsync(new ApiRequest { Api = api, ContentType = contentType, Body = Encoding.UTF8.GetBytes(data), Method = HttpMethod.Post }, requestInitializer, token);
        }
        public Task<ApiResponse> PostAsync(string api, Dictionary<string, object> formData)
        {
            return PostAsync(api, formData, null, CancellationToken.None);
        }
        public async Task<ApiResponse> PostAsync(string api, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            var result = new ApiResponse();

            try
            {
                var postData = formData.Join("&");
                var body = Encoding.UTF8.GetBytes(postData);

                result = await InvokeAsync(new ApiRequest { Api = api, ContentType = "application/x-www-form-urlencoded", Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer, false), token);
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        public Task<ApiResponse> PutAsync(string api, string contentType, byte[] data)
        {
            return PutAsync(api, contentType, data, null, CancellationToken.None);
        }
        public Task<ApiResponse> PutAsync(string api, string contentType, string data)
        {
            return PutAsync(api, contentType, data, null, CancellationToken.None);
        }
        public Task<ApiResponse> PutAsync(string api, string contentType, byte[] data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            return InvokeAsync(new ApiRequest { Api = api, ContentType = contentType, Body = data, Method = HttpMethod.Put }, requestInitializer, token);
        }
        public Task<ApiResponse> PutAsync(string api, string contentType, string data, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            return InvokeAsync(new ApiRequest { Api = api, ContentType = contentType, Body = Encoding.UTF8.GetBytes(data), Method = HttpMethod.Put }, requestInitializer, token);
        }
        public Task<ApiResponse> SendAsync(string api, string filepath, Dictionary<string, object> formData = null, string contentType = "")
        {
            return SendAsync(api, filepath, formData, null, contentType, CancellationToken.None);
        }
        public async Task<ApiResponse> SendAsync(string api, string filepath, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, string contentType, CancellationToken token)
        {
            var result = new ApiResponse();

            try
            {
                // helper:  https://stackoverflow.com/questions/36745769/send-files-using-httpwebrequest
                //          https://technet.rapaport.com/Info/LotUpload/SampleCode/Full_Example.aspx

                var boundary = CreateSendBoundary();
                var body = GetPostData(contentType, filepath, formData, boundary);

                result = await InvokeAsync(new ApiRequest { Api = api, ContentType = "multipart/form-data; boundary=" + boundary, Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer), token);
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        public Task<ApiResponse> SendAsync(string api, string filename, byte[] data, Dictionary<string, object> formData = null, string contentType = "")
        {
            return SendAsync(api, filename, data, formData, null, contentType, CancellationToken.None);
        }
        public async Task<ApiResponse> SendAsync(string api, string filename, byte[] data, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, string contentType, CancellationToken token)
        {
            var result = new ApiResponse();

            try
            {
                var boundary = CreateSendBoundary();
                var body = GetPostData(contentType, filename, data, formData, boundary);

                result = await InvokeAsync(new ApiRequest { Api = api, ContentType = "multipart/form-data; boundary=" + boundary, Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer, false), token);
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        #endregion
        #region Send (multiple files)
        public ApiResponse Send(string api, SendFile[] files, Dictionary<string, object> formData = null)
        {
            return Send(api, files, formData, null);
        }
        public ApiResponse Send(string api, SendFile[] files, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            var result = new ApiResponse();

            try
            {
                var boundary = CreateSendBoundary();
                var body = GetPostData(files, formData, boundary);

                result = Invoke(new ApiRequest { Api = api, ContentType = "multipart/form-data; boundary=" + boundary, Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer));
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        public ApiResponse Send(string api, SendData[] files, Dictionary<string, object> formData = null)
        {
            return Send(api, files, formData, null);
        }
        public ApiResponse Send(string api, SendData[] files, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer)
        {
            var result = new ApiResponse();

            try
            {
                var boundary = CreateSendBoundary();
                var body = GetPostData(files, formData, boundary);

                result = Invoke(new ApiRequest { Api = api, ContentType = "multipart/form-data; boundary=" + boundary, Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer));
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        
        public Task<ApiResponse> SendAsync(string api, SendFile[] files, Dictionary<string, object> formData = null)
        {
            return SendAsync(api, files, formData, null,CancellationToken.None);
        }
        public async Task<ApiResponse> SendAsync(string api, SendFile[] files, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            var result = new ApiResponse();

            try
            {
                var boundary = CreateSendBoundary();
                var body = GetPostData(files, formData, boundary);

                result = await InvokeAsync(new ApiRequest { Api = api, ContentType = "multipart/form-data; boundary=" + boundary, Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer), token);
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        public Task<ApiResponse> SendAsync(string api, SendData[] files, Dictionary<string, object> formData = null)
        {
            return SendAsync(api, files, formData, null, CancellationToken.None);
        }
        public async Task<ApiResponse> SendAsync(string api, SendData[] files, Dictionary<string, object> formData, Func<ApiRequest, WebRequest, WebRequest> requestInitializer, CancellationToken token)
        {
            var result = new ApiResponse();

            try
            {
                var boundary = CreateSendBoundary();
                var body = GetPostData(files, formData, boundary);

                result = await InvokeAsync(new ApiRequest { Api = api, ContentType = "multipart/form-data; boundary=" + boundary, Body = body, Method = HttpMethod.Post }, PrepareRequestInitializer(requestInitializer), token);
            }
            catch (Exception e)
            {
                result.Failed(e);
            }

            return result;
        }
        #endregion
    }
}
