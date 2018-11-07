using Locust.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using Locust.Logging;

namespace Locust.SMS.Payamtak
{
    public class PayamtakSmsService : ISMSService
    {
        private ISMSConfiguration _config;
        public ILogger Logger { get; set; }
        public IExceptionLogger ExceptionLogger { get; set; }
        public PayamtakSmsService(ISMSConfiguration config, ILogger logger, IExceptionLogger exceptionLogger)
        {
            _config = config;
            Logger = logger;
            ExceptionLogger = exceptionLogger;
        }
        public ISMSConfiguration Config
        {
            get { return _config; }
            set { _config = value; }
        }
        public string Send(string targetNumber, string message)
        {
            try
            {
                var request = WebRequest.Create("http://ippanel.com/services.jspd");
                var rcpts = new string[] { targetNumber };
                var json = JsonConvert.SerializeObject(rcpts);
                var postData = $"op=send&uname={Config.Username}&pass={Config.Password}&message={HttpUtility.UrlEncode(message)}&to={json}&from=+{Config.Number}";
                var byteArray = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                var dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                var response = request.GetResponse();

                Logger.Log("PayamtakSmsService.Send: Response.StatusDescription = " + ((HttpWebResponse)response).StatusDescription);

                dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                var responseFromServer = reader.ReadToEnd();
                Logger.Log("PayamtakSmsService.Send: Response.Body = " + responseFromServer);

                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception e)
            {
                ExceptionLogger.LogException(e, $"PayamtakSmsService.Send: targetNumber = {targetNumber}, message = {message}");
            }

            return string.Empty;
        }

        public async Task<string> SendAsync(string targetNumber, string message)
        {
            return await SendAsync(targetNumber, message, CancellationToken.None);
        }

        public async Task<string> SendAsync(string targetNumber, string message, CancellationToken cancellation)
        {
            try
            {
                var request = WebRequest.Create("http://ippanel.com/services.jspd");
                var rcpts = new string[] { targetNumber };
                var json = JsonConvert.SerializeObject(rcpts);
                var postData = $"op=send&uname={Config.Username}&pass={Config.Password}&message={HttpUtility.UrlEncode(message)}&to={json}&from=+{Config.Number}";
                var byteArray = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                var dataStream = await request.GetRequestStreamAsync();
                await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
                dataStream.Close();

                var response = await request.GetResponseAsync();

                Logger.Log("PayamtakSmsService.SendAsync: Response.StatusDescription = " + ((HttpWebResponse)response).StatusDescription);

                dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                var responseFromServer = await reader.ReadToEndAsync();
                Logger.Log("PayamtakSmsService.SendAsync: Response.Body = " + responseFromServer);

                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception e)
            {
                ExceptionLogger.LogException(e, $"PayamtakSmsService.SendAsync: targetNumber = {targetNumber}, message = {message}");
            }

            return string.Empty;
        }
    }
}
