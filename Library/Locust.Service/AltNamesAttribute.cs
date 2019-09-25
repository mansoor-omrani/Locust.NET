using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AltNamesAttribute: Attribute
    {
        public string Names { get; set; }
        public string[] NamesList
        {
            get
            {
                return Names?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
            }
        }
        public AltNamesAttribute(string names)
        {
            Names = names;
        }
    }
}
