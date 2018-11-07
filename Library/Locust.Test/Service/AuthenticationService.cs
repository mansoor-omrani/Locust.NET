using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Locust.Test.Service
{
    public interface IAuthenticationService
    {
        string LocustUserName { get; }
        string LocustPassword { get; }
        bool Login(string username, string password, out string message);
        void Logout();
        bool IsAuthenticated();
    }
    public class AuthenticationService : IAuthenticationService
    {
        private static string locust_username;
        private static string locust_password;
        private const string COOKIE_NAME = "lctest";
        static AuthenticationService()
        {
            locust_username = ConfigurationManager.AppSettings["LocustTestUserName"]?.ToString() ?? "locust_test";
            locust_password = ConfigurationManager.AppSettings["LocustTestPassword"]?.ToString() ?? "lcpass123";
        }
        public string LocustUserName
        {
            get { return locust_username; }
        }
        public string LocustPassword
        {
            get { return locust_password; }
        }
        private HttpContextBase context;
        public AuthenticationService(IHttpContextProvider context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            this.context = context.Get();
        }
        public bool Login(string username, string password, out string message)
        {
            if (string.IsNullOrEmpty(username))
            {
                message = "Please enter your username";
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                message = "Please enter your password";
                return false;
            }

            if (string.Compare(LocustUserName, username, true) == 0 && string.Compare(LocustPassword, password, false) == 0)
            {
                message = "Welcome";
                var cookie = new HttpCookie(COOKIE_NAME, "true");
                context.Response.SetCookie(cookie);

                return true;
            }

            message = "Invalid username or password";

            return false;
        }
        public void Logout()
        {
            var cookie = context.Response.Cookies[COOKIE_NAME];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                context.Response.SetCookie(cookie);
            }
        }
        public bool IsAuthenticated()
        {
            return context.Request.Cookies[COOKIE_NAME]?.Value == "true";
        }
    }
}