using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ConnectionString
{
    public class ConnectionStringChangedEventArgs: EventArgs
    {
        public string Name { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
    public interface IConnectionStringProvider : IDictionary<string, string>
    {
        string GetConnectionString(string name = "");
        void SetConnectionString(string cnnStr, string name = "");
        string ActiveConnection { get; set; }
        string Current { get; }
        event EventHandler<ConnectionStringChangedEventArgs> ConnectionStringChanged;
        void Load();
        void Load(IDictionary<string, string> connectionstrings);
        void Save();
        string this[int index] { get; set; }
        bool Contains(string name);
    }
}
