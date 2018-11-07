using Locust.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ConnectionString
{
    public abstract class BaseConnectionStringProvider : IConnectionStringProvider
    {
        private string activeConnection;
        public virtual string ActiveConnection
        {
            get
            {
                return activeConnection;
            }
            set
            {
                currentIsSet = false;
                activeConnection = value;
            }
        }
        public virtual int Count
        {
            get { return connectionStrings.Count; }
        }
        private string current;
        private bool currentIsSet;
        public virtual string Current
        {
            get
            {
                if (!currentIsSet)
                {
                    current = GetConnectionString(ActiveConnection);
                    currentIsSet = true;
                }

                return current;
            }
        }
        protected Dictionary<string, string> connectionStrings;

        public event EventHandler<ConnectionStringChangedEventArgs> ConnectionStringChanged;
        public BaseConnectionStringProvider()
        {
            connectionStrings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            Load();
        }
        public virtual void Load()
        {
            connectionStrings.Clear();
        }
        public virtual void Load(IDictionary<string, string> connectionstrings)
        {
            Clear();

            foreach (var item in connectionstrings)
            {
                Add(item.Key, item.Value);
            }
        }
        public virtual void Save() { }
        public virtual void Add(string name, string connectionString)
        {
            if (connectionStrings.Count == 0 || !connectionStrings.ContainsKey(name))
                connectionStrings.Add(name, connectionString);
            else
            {
                connectionStrings[name] = connectionString;
            }
        }
        public virtual void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }
        public virtual bool Remove(string name)
        {
            if (connectionStrings.Count > 0 && connectionStrings.ContainsKey(name))
            {
                return connectionStrings.Remove(name);
            }

            return false;
        }
        public virtual bool Remove(KeyValuePair<string, string> item)
        {
            foreach (var _item in connectionStrings)
            {
                if (string.Compare(item.Key, _item.Key, StringComparison.OrdinalIgnoreCase) == 0 && item.Value == _item.Value)
                {
                    connectionStrings.Remove(item.Key);
                    return true;
                }
            }

            return false;
        }
        public virtual string GetConnectionString(string name = "")
        {
            if (connectionStrings.Count == 0)
            {
                return "";
            }

            if (string.IsNullOrEmpty(name))
            {
                if (!string.IsNullOrEmpty(ActiveConnection) && connectionStrings.ContainsKey(ActiveConnection))
                {
                    return connectionStrings[ActiveConnection];
                }

                return connectionStrings.ItemAt(0).Value;
            }

            return connectionStrings.ContainsKey(name) ? connectionStrings[name] : "";
        }
        public virtual bool TryGetValue(string name, out string connectionString)
        {
            if (ContainsKey(name))
            {
                connectionString = connectionStrings[name];
                return true;
            }
            else
            {
                connectionString = "";
                return false;
            }
        }
        public virtual void SetConnectionString(string connectionString, string name = "")
        {
            var oldValue = "";
            var raiseEvent = false;

            if (connectionStrings.Count == 0)
            {
                if (string.IsNullOrEmpty(name))
                {
                    if (!string.IsNullOrEmpty(ActiveConnection))
                    {
                        connectionStrings.Add(ActiveConnection, connectionString);
                    }
                    else
                    {
                        current = connectionString;
                        currentIsSet = true;
                    }
                }
                else
                {
                    connectionStrings.Add(name, connectionString);
                }

                return;
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (connectionStrings.ContainsKey(name))
                {
                    oldValue = connectionStrings[name];
                    connectionStrings[name] = connectionString;
                    raiseEvent = true;
                }
                else
                {
                    Add(name, connectionString);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(ActiveConnection))
                {
                    if (connectionStrings.ContainsKey(ActiveConnection))
                    {
                        oldValue = connectionStrings[ActiveConnection];
                        connectionStrings[ActiveConnection] = connectionString;
                        raiseEvent = true;
                    }
                    else
                    {
                        connectionStrings.Add(ActiveConnection, connectionString);
                    }
                }
                else
                {
                    current = connectionString;
                    currentIsSet = true;
                }
            }

            if (raiseEvent)
            {
                ConnectionStringChanged?.Invoke(this,
                        new ConnectionStringChangedEventArgs
                        {
                            Name = name,
                            OldValue = oldValue,
                            NewValue = connectionString
                        });
            }
        }
        public virtual void Clear()
        {
            connectionStrings.Clear();
        }
        public virtual string this[string name]
        {
            get
            {
                return GetConnectionString(name);
            }
            set
            {
                SetConnectionString(name, value);
            }
        }
        public virtual string this[int index]
        {
            get
            {
                if (connectionStrings.Count > 0 && index >= 0)
                {
                    var i = 0;

                    foreach (var item in connectionStrings)
                    {
                        if (i == index)
                        {
                            return item.Value;
                        }

                        i++;
                    }

                    return "";
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (connectionStrings.Count > 0 && index >= 0)
                {
                    var i = 0;

                    foreach (var item in connectionStrings)
                    {
                        if (i == index)
                        {
                            connectionStrings[item.Key] = value;
                            break;
                        }

                        i++;
                    }
                }
            }
        }
        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public virtual bool Contains(string name)
        {
            return ContainsKey(name);
        }
        public virtual bool Contains(KeyValuePair<string, string> item)
        {
            if (Contains(item.Key))
            {
                return (connectionStrings[item.Key] == item.Value);
            }

            return false;
        }
        public virtual bool ContainsKey(string name)
        {
            return connectionStrings.Count > 0 && connectionStrings.ContainsKey(name);
        }
        public virtual ICollection<string> Keys
        {
            get
            {
                return connectionStrings.Keys;
            }
        }

        public virtual ICollection<string> Values
        {
            get
            {
                return connectionStrings.Values;
            }
        }
        public virtual void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            if (array != null && arrayIndex >= 0 && arrayIndex < array.Length)
            {
                var i = 0;

                foreach (var item in connectionStrings)
                {
                    if (arrayIndex + i < array.Length)
                    {
                        array[arrayIndex + i] = item;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public virtual IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return connectionStrings.GetEnumerator();
        }
        public virtual IEnumerable<ConnectionString> GetConnectionStrings()
        {
            foreach (var item in connectionStrings)
            {
                yield return new ConnectionString { Name = item.Key, Value = item.Value };
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return connectionStrings.GetEnumerator();
        }
    }
}
