namespace Locust.Mailing
{
    public interface IMailConfig
    {
        string Username { get; }
        string Password { get; }
        string DefaultMail { get; }
        int Port { get; }
        string Host { get; }
        bool EnableSSL { get; }
        bool UseDefaultCredentials { get; } 
    }
}