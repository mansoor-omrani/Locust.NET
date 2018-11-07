using Locust.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing
{
    public enum FakeMailType
    {
        None, File, Debug, Console, Trace
    }
    public class FakeDynamicMailManager : IMailManager
    {
        private IMailManager mailer;
        public IMailConfig Config
        {
            get { return mailer.Config; }
            set
            {
                if (mailer != null)
                    mailer.Config = value;
            }
        }
        public IMailManager Instance { get { return mailer; } }
        public FakeDynamicMailManager()
        {
            var type = ConfigHelper.AppSetting("FakeMailerType", FakeMailType.File);

            switch (type)
            {
                case FakeMailType.Console: mailer = new FakeConsoleMailManager(); break;
                case FakeMailType.Debug: mailer = new FakeDebugMailManager(); break;
                case FakeMailType.Trace: mailer = new FakeTraceMailManager(); break;
                case FakeMailType.File: mailer = new FakeFileMailManager(); break;
                case FakeMailType.None: mailer = null; break;
                default:
                    throw new Exception("invalid fake mailer type: " + type);
            }
        }
        public void Send(string to, string subject, string body, bool isHtml = false)
        {
            mailer?.Send(to, subject, body, isHtml);
        }

        public void Send(string to, string subject, string body, bool isHtml, IEnumerable<string> cc, IEnumerable<string> bcc)
        {
            mailer?.Send(to, subject, body, isHtml, cc, bcc);
        }

        public Task SendAsync(string to, string subject, string body, bool isHtml = false)
        {
            return mailer?.SendAsync(to, subject, body, isHtml);
        }

        public Task SendAsync(string to, string subject, string body, bool isHtml, IEnumerable<string> cc, IEnumerable<string> bcc)
        {
            return mailer?.SendAsync(to, subject, body, isHtml, cc, bcc);
        }
    }
}
