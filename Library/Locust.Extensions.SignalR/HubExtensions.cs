using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Extensions.SignalR
{
    public static class HubExtensions
    {
        // source: https://stackoverflow.com/questions/11044361/signalr-get-caller-ip-address
        // with a little modification
        public static string GetClientIpAddress(this IRequest request)
        {
            try
            {
                var env = request.Environment;
                if (env == null)
                {
                    return null;
                }

                var userHostAddress = env.Get<string>("server.RemoteIpAddress");
                
                // Attempt to parse.  If it fails, we catch below and return "0.0.0.0"
                // Could use TryParse instead, but I wanted to catch all exceptions
                IPAddress.Parse(userHostAddress);

                if (string.IsNullOrEmpty(userHostAddress))
                    return "0.0.0.0";
                else
                if (userHostAddress == "::1")
                    return "127.0.0.1";
                else
                    return userHostAddress;
            }
            catch (Exception)
            {
                // Always return all zeroes for any failure (my calling code expects it)
                return "0.0.0.0";
            }
        }
    }
}
