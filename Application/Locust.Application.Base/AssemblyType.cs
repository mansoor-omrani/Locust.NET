using System;

namespace Locust.Application.Base
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class AssemblyTypeAttribute: Attribute
    {
        public string Type { get; set; }
        public AssemblyTypeAttribute(string type)
        {
            Type = type;
        }
    }
}
