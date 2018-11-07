using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locust.MvcAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ControllerNameAttribute: Attribute
    {
        private readonly string _name;

        public ControllerNameAttribute(string name)
        {
            _name = name;
        }
        public string Name { get { return _name; } }
    }
}