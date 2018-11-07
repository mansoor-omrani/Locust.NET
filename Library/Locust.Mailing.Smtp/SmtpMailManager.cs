using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace Locust.Mailing.Smtp
{
    public class SmtpMailManager: IMailManager
    {
        private IMailConfig config;
        public SmtpMailManager(IMailConfig config)
        {
            this.config = config;
        }
        public IMailConfig Config
        {
            get { return config; }
            set { config = value; }
        }

        private void send(MailMessage mail)
        {
            SmtpClient client;

            if (config.Port > 0)
            {
                client = new SmtpClient(config.Host, config.Port);
            }
            else
            {
                client = new SmtpClient(config.Host);
            }

            if (config.EnableSSL)
            {
                client.EnableSsl = config.EnableSSL;
            }
            client.UseDefaultCredentials = config.UseDefaultCredentials;

            if (!config.UseDefaultCredentials)
                client.Credentials = new NetworkCredential(config.Username, config.Password);

            client.Send(mail);
        }
        private Task sendAsync(MailMessage mail)
        {
            SmtpClient client;

            if (config.Port > 0)
            {
                client = new SmtpClient(config.Host, config.Port);
            }
            else
            {
                client = new SmtpClient(config.Host);
            }

            client.EnableSsl = config.EnableSSL;
            client.UseDefaultCredentials = config.UseDefaultCredentials;

            if (!config.UseDefaultCredentials)
                client.Credentials = new NetworkCredential(config.Username, config.Password);

            return client.SendMailAsync(mail);
        }
        public void Send(string to, string subject, string body, bool isHtml = false)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(config.DefaultMail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = body;
            mail.IsBodyHtml = isHtml;

            send(mail);
        }
        public Task SendAsync(string to, string subject, string body, bool isHtml = false)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(config.DefaultMail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = body;
            mail.IsBodyHtml = isHtml;

            return sendAsync(mail);
        }
        public void Send(string to, string subject, string body, bool isHtml, IEnumerable<string> cc, IEnumerable<string> bcc)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(config.DefaultMail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = body;
            mail.IsBodyHtml = isHtml;

            if (cc != null && cc.Count() > 0)
            {
                foreach (string address in cc)
                {
                    try
                    {
                        mail.CC.Add(new MailAddress(address));
                    }
                    finally { }
                }
            }

            if (bcc != null && bcc.Count() > 0)
            {
                foreach (string address in bcc)
                {
                    try
                    {
                        mail.Bcc.Add(new MailAddress(address));
                    }
                    finally { }
                }
            }

            send(mail);
        }
        public Task SendAsync(string to, string subject, string body, bool isHtml, IEnumerable<string> cc, IEnumerable<string> bcc)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(config.DefaultMail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = body;
            mail.IsBodyHtml = isHtml;

            if (cc != null && cc.Count() > 0)
            {
                foreach (string address in cc)
                {
                    try
                    {
                        mail.CC.Add(new MailAddress(address));
                    }
                    finally { }
                }
            }

            if (bcc != null && bcc.Count() > 0)
            {
                foreach (string address in bcc)
                {
                    try
                    {
                        mail.Bcc.Add(new MailAddress(address));
                    }
                    finally { }
                }
            }

            return sendAsync(mail);
        }
    }
}