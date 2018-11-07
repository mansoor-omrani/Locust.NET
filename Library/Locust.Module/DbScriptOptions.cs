using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Module
{
    public class DbScriptOptions
    {
        public string Schema { get; set; }
        public string DatabaseName { get; set; }
    }
    public class SprocScriptOptions
    {
        public string DatabaseName { get; set; }
        public string SprocName { get; set; }
        public string SprocSchema { get; set; }
        public string TableName { get; set; }
        public string TableSchema { get; set; }
        public bool DropIfExists { get; set; }
        public bool UseDb { get; set; }
        public bool UseDbExtensions { get; set; }
        public string ExtensionSchema { get; set; }
    }
    public class TableScriptOptions
    {
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
        public string TableSchema { get; set; }
        public bool UseDb { get; set; }
        public string PKConstraintName { get; set; }
        public string DataFileGroup { get; set; }
        public string BlobFileGroup { get; set; }
    }
}
