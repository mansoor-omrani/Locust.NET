using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.SMS
{
    public interface ISMSConfiguration
    {
        string Username { get; }
        string Password { get; }
        string Number { get; }
    }
    public class BaseSMSConfiguration: ISMSConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }
    }
    public interface ISMSService
    {
        ISMSConfiguration Config { get; set; }
        string Send(string targetNumber, string message);
        Task<string> SendAsync(string targetNumber, string message);
        Task<string> SendAsync(string targetNumber, string message, CancellationToken cancellation);
    }
}
