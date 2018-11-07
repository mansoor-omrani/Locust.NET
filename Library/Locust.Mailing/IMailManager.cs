using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing
{
    public interface IMailManager
    {
        IMailConfig Config { get; set; }
        void Send(string to, string subject, string body, bool isHtml = false);
        Task SendAsync(string to, string subject, string body, bool isHtml = false);
        void Send(string to, string subject, string body, bool isHtml, IEnumerable<string> cc, IEnumerable<string> bcc);
        Task SendAsync(string to, string subject, string body, bool isHtml, IEnumerable<string> cc, IEnumerable<string> bcc);
    }
}
