using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Dynamic;
using SendSimpleSMS2CompletedEventHandler = Locust.SMS.Farapayamak.com.payamak_panel.api.SendSimpleSMS2CompletedEventHandler;

namespace Locust.SMS.Farapayamak
{
    
    public class FarapayamakSmsService: ISMSService
    {
        private ISMSConfiguration _config;

        public FarapayamakSmsService(ISMSConfiguration config)
        {
            _config = config;
        }
        public ISMSConfiguration Config
        {
            get { return _config; }
            set { _config = value; }
        }
        public string Send(string targetNumber, string message)
        {
            var result = string.Empty;

            try
            {
                var sms = new com.payamak_panel.api.Send();
                
                result = sms.SendSimpleSMS2(
                            _config.Username,
                            _config.Password,
                            targetNumber,
                            _config.Number,
                            message,
                            false);

                sms.Dispose();
                
                return result;
            }
            catch
            {
                return result;
            }
        }
        public Task<string> SendAsync(string targetNumber, string message)
        {
            return SendAsync(targetNumber, message, CancellationToken.None);
        }

        public Task<string> SendAsync(string targetNumber, string message, System.Threading.CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<string>();

            try
            {
                var sms = new com.payamak_panel.api.Send();

                sms.SendSimpleSMS2Completed += new SendSimpleSMS2CompletedEventHandler((sender, args) =>
                {
                    if (args.Error != null)
                    {
                        tcs.TrySetException(args.Error);
                    }
                    else
                    if (!args.Cancelled)
                    {
                        tcs.SetResult(args.Result);
                    }
                    else
                    {
                        tcs.SetCanceled();
                    }

                    sms.Dispose();
                });

                cancellation.Register(() => sms.CancelAsync(_config.Number));
                
                sms.SendSimpleSMS2Async(_config.Username,
                            _config.Password,
                            targetNumber,
                            _config.Number,
                            message,
                            false, _config.Number);
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            return tcs.Task;
        }
    }
}