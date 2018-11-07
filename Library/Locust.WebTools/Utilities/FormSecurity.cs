using Locust.Cryptography;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Locust.WebTools
{
    public class FormSecurityConfig
    {
        private string _key;
        private string _encryptionKey;
        private const string _tokenName = "aft";   // Anti Forgery Token
        private const string _encryptedTokenName = "afte";   // Anti Forgery Encrypted Token

        public string TokenName { get { return _tokenName; } }
        public string EncryptedTokenName { get { return _encryptedTokenName; } }
        
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;

                if (Encryption != null && !string.IsNullOrEmpty(_key))
                {
                    _encryptionKey = Encryption.GetKey(_key, Encoding.ASCII);
                }
            }
        }
        public IEncryption Encryption { get; set; }

        public FormSecurityConfig()
        {
            Encryption = new TripleDES();
            Key = ConfigurationManager.AppSettings["FormSecurityKey"];
        }
        private bool IsOk()
        {
            return !string.IsNullOrEmpty(_encryptionKey) && Encryption != null;
        }
        public string Encrypt(string data)
        {
            if (IsOk())
            {
                return Encryption.Encrypt(data, _encryptionKey);
            }
            else
            {
                return data; 
            }
        }
        public string Decrypt(string data)
        {
            if (IsOk())
            {
                return Encryption.Decrypt(data, _encryptionKey);
            }
            else
            {
                return data; 
            }
        }
    }

    public class FormSecurityItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class FormSecurityToken
    {
        public FormSecurityItem Value { get; private set; }
        public FormSecurityItem Checksum { get; private set; }

        public FormSecurityToken()
        {
            this.Value = new FormSecurityItem();
            this.Checksum = new FormSecurityItem();
        }
    }
    public interface IFormSecurity
    {
        FormSecurityToken GetToken();
        bool IsSecure(string token = "", string checksum = "");
        FormSecurityConfig Config { get; }
    }
    public class FormSecurity : IFormSecurity
    {
        private FormSecurityConfig _config;
        public FormSecurity(FormSecurityConfig config)
        {
            _config = config;
        }

        public FormSecurityConfig Config
        {
            get { return _config; }
        }
        public FormSecurityToken GetToken()
        {
            var r = new Random(Guid.NewGuid().GetHashCode());
            var code = r.Next(999999, 99999999).ToString();
            //var token = "<input type=\"hidden\" name=\"{0}\" value=\"{1}\"/><input type=\"hidden\" name=\"{2}\" value=\"{3}\"/>";
            var result = new FormSecurityToken();

            result.Value.Name = Config.TokenName;
            result.Value.Value = code;
            result.Checksum.Name = Config.EncryptedTokenName;
            result.Checksum.Value = _config.Encrypt(code);

            return result;
        }
        public bool IsSecure(string token = "", string encryptedToken = "")
        {
            var result = false;
            var context = HttpContext.Current;
            var code = "";
            var encryptedCode = "";

            if (context != null)
            {
                if (string.IsNullOrEmpty(token))
                {
                    if (context.Request.Form[Config.TokenName] != null)
                        code = context.Request.Form[Config.TokenName].ToString();
                }
                else
                {
                    code = token;
                }

                if (string.IsNullOrEmpty(encryptedToken))
                {
                    if (context.Request.Form[Config.EncryptedTokenName] != null)
                        encryptedCode = context.Request.Form[Config.EncryptedTokenName].ToString();
                }
                else
                {
                    encryptedCode = encryptedToken;
                }
            }
            else
            {
                code = token;
                encryptedCode = encryptedToken;
            }
            
            if (!String.IsNullOrEmpty(code) && !String.IsNullOrEmpty(encryptedCode))
            {
                result = (string.Compare(code, _config.Decrypt(encryptedCode), StringComparison.OrdinalIgnoreCase) == 0);
            }

            return result;
        }
    }
}
