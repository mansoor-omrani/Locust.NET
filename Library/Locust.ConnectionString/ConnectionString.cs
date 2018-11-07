using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Locust.ConnectionString
{
    public class ConnectionString
    {
        private string _dataSource;
        private bool _dataSource_extracted;
        public string Name { get; set; }

        public string DataSource
        {
            get
            {
                if (string.IsNullOrEmpty(_dataSource) && !_dataSource_extracted)
                {
                    if (!string.IsNullOrEmpty(_value))
                    {
                        var match = Regex.Match(_value, @"data\s+source\s*=", RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            var j = _value.IndexOf(";", match.Index + match.Value.Length);
                            if (j >= 0)
                            {
                                _dataSource = _value.Substring(match.Index + match.Value.Length, j - match.Index - match.Value.Length);
                            }
                        }
                    }

                    _dataSource_extracted = true;
                }

                return _dataSource;
            }
            set
            {
                _dataSource = value;
            }
        }
        private string _initialCatalog;
        private bool _initialCatalog_extracted;
        public string InitialCatalog
        {
            get
            {
                if (string.IsNullOrEmpty(_initialCatalog) && !_initialCatalog_extracted)
                {
                    if (!string.IsNullOrEmpty(_value))
                    {
                        var match = Regex.Match(_value, @"initial\s+catalog\s*=", RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            var j = _value.IndexOf(";", match.Index + match.Value.Length);
                            if (j >= 0)
                            {
                                _initialCatalog = _value.Substring(match.Index + match.Value.Length, j - match.Index - match.Value.Length);
                            }
                        }
                    }

                    _initialCatalog_extracted = true;
                }

                return _initialCatalog;
            }
            set { _initialCatalog = value; }
        }
        private string _userId;
        private bool _userId_extracted;
        public string UserId
        {
            get
            {
                if (string.IsNullOrEmpty(_userId) && !_userId_extracted)
                {
                    if (!string.IsNullOrEmpty(_value))
                    {
                        var match = Regex.Match(_value, @"user\s+id\s*=", RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            var j = _value.IndexOf(";", match.Index + match.Value.Length);
                            if (j >= 0)
                            {
                                _userId = _value.Substring(match.Index + match.Value.Length, j - match.Index - match.Value.Length);
                            }
                        }
                    }

                    _userId_extracted = true;
                }

                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        private string _password;
        private bool _password_extracted;
        public string Password
        {
            get
            {
                if (string.IsNullOrEmpty(_password) && !_password_extracted)
                {
                    if (!string.IsNullOrEmpty(_value))
                    {
                        var match = Regex.Match(_value, @"password\s*=", RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            var j = _value.IndexOf(";", match.Index + match.Value.Length);
                            if (j >= 0)
                            {
                                _password = _value.Substring(match.Index + match.Value.Length, j - match.Index - match.Value.Length);
                            }
                        }
                    }

                    _password_extracted = true;
                }

                return _password;
            }
            set { _password = value; }
        }
        private string _integratedSecurity;
        private bool _integratedSecurity_extracted;
        public string IntegratedSecurity
        {
            get
            {
                if (string.IsNullOrEmpty(_integratedSecurity) && !_integratedSecurity_extracted)
                {
                    if (!string.IsNullOrEmpty(_value))
                    {
                        var match = Regex.Match(_value, @"integrated\s+security\s*=", RegexOptions.IgnoreCase);

                        if (match.Success)
                        {
                            var j = _value.IndexOf(";", match.Index + match.Value.Length);
                            if (j >= 0)
                            {
                                _integratedSecurity = _value.Substring(match.Index + match.Value.Length, j - match.Index - match.Value.Length);
                            }
                        }
                    }

                    _integratedSecurity_extracted = true;
                }

                return _integratedSecurity;
            }
            set { _integratedSecurity = value; }
        }
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;

                _dataSource = "";
                _initialCatalog = "";
                _userId = "";
                _password = "";
                _integratedSecurity = "";

                _dataSource_extracted = false;
                _initialCatalog_extracted = false;
                _userId_extracted = false;
                _password_extracted = false;
                _integratedSecurity_extracted = false;
            }
        }
        private string toStringResult;
        public ConnectionString():this("")
        {
        }
        public ConnectionString(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(toStringResult))
            {
                var ds = string.IsNullOrEmpty(DataSource) ? "." : DataSource;

                toStringResult = $"Data Source={ds}";

                if (!string.IsNullOrEmpty(UserId))
                {
                    toStringResult += $";User Id={UserId}";
                }

                if (!string.IsNullOrEmpty(Password))
                {
                    toStringResult += $";Password={Password}";
                }

                if (!string.IsNullOrEmpty(InitialCatalog))
                {
                    toStringResult += $";Initial Catalog={InitialCatalog}";
                }

                if (!string.IsNullOrEmpty(IntegratedSecurity))
                {
                    toStringResult += $";Integrated Security={IntegratedSecurity}";
                }
            }

            return toStringResult;
        }
    }
}
