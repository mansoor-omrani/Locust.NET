using Locust.Date;
using Locust.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Locust.WebTools
{
    public enum TempTokenValidationResult
    {
        None,
        NoToken,
        InvalidToken,
        MissingValue,
        ValueMismatch,
        ProblematicToken,
        MissingTimestamp,
        TimestampCorrupted,
        MissingExpireTime,
        InvalidExpireTime,
        ExpireTimeCorrupted,
        Expired,
        SyncError,
        Valid
    }
    public interface ITempTokenProvider
    {
        string Generate(string value = "");
        TempTokenValidationResult Check(string token, string value = "");
    }
    public class TempTokenProvider : ITempTokenProvider
    {
        private string key;
        public int ExpireTime { get; set; }
        public INow Now { get; set; }
        public ILogger Logger { get; set; }
        public TempTokenProvider(INow now, ILogger logger)
        {
            Now = now;
            Logger = logger;
            key = WebConfigurationManager.AppSettings["CryptKey"]?.ToString();
            ExpireTime = 15;    // seconds
        }
        public TempTokenValidationResult Check(string token, string value = "")
        {
            Logger.LogCategory($"TempTokenProvider.Check('{token}', '{value}')");

            var result = TempTokenValidationResult.None;
            var _value = value?.Replace("$", "");

            if (string.IsNullOrEmpty(token?.Trim()))
            {
                result = TempTokenValidationResult.NoToken;
            }
            else
            {
                try
                {
                    for (var i = 0; i < 1; i++)
                    {
                        var data = Locust.Cryptography.Cryptography.AES.Decrypt(token, key);

                        Logger.Log($"Given token: {data}");

                        var arr = data.Split('$');

                        if (arr.Length != 3)
                        {
                            result = TempTokenValidationResult.ProblematicToken;
                            break;
                        }

                        if (!string.IsNullOrEmpty(_value) && string.IsNullOrEmpty(arr[0]))
                        {
                            result = TempTokenValidationResult.MissingValue;
                            break;
                        }

                        if (!string.IsNullOrEmpty(_value) && string.Compare(_value, arr[0]) != 0)
                        {
                            result = TempTokenValidationResult.ValueMismatch;
                            break;
                        }

                        DateTime d;

                        if (string.IsNullOrEmpty(arr[1]?.Trim()))
                        {
                            result = TempTokenValidationResult.MissingTimestamp;
                            break;
                        }

                        if (!DateTime.TryParse(arr[1], out d))
                        {
                            result = TempTokenValidationResult.TimestampCorrupted;
                            break;
                        }

                        if (string.IsNullOrEmpty(arr[2]?.Trim()))
                        {
                            result = TempTokenValidationResult.MissingExpireTime;
                            break;
                        }

                        int expireTime;

                        if (!Int32.TryParse(arr[2], out expireTime))
                        {
                            result = TempTokenValidationResult.ExpireTimeCorrupted;
                            break;
                        }

                        if (expireTime < 0)
                        {
                            result = TempTokenValidationResult.InvalidExpireTime;
                            break;
                        }

                        var passedSeconds = (Now.Value - d).TotalSeconds;
                        if (passedSeconds < 0)
                        {
                            result = TempTokenValidationResult.SyncError;
                            break;
                        }

                        if (passedSeconds > expireTime)
                        {
                            result = TempTokenValidationResult.Expired;
                            break;
                        }

                        result = TempTokenValidationResult.Valid;
                    }
                }
                catch
                {
                    result = TempTokenValidationResult.InvalidToken;
                }
            }

            return result;
        }

        public string Generate(string value = "")
        {
            Logger.LogCategory($"TempTokenProvider.Generate('{value}')");

            var result = "";
            
            if (!string.IsNullOrEmpty(key) && key.Length == 16)
            {
                var data = value?.Replace("$", "") + "$" + Now.Value.ToString("yyyy/MM/dd HH:mm:ss.fffff") + "$" + ExpireTime;

                Logger.Log($"Raw token: {data}");

                result = Locust.Cryptography.Cryptography.AES.Encrypt(data, key);
            }
            else
            {
                Logger.Log($"No encryption key found or key size is not 16 bytes. key = {key}");
            }

            return result;
        }
    }
}
