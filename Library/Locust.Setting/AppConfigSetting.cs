﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Setting
{
    public class AppConfigSettings : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (ConfigurationManager.AppSettings[binder.Name] != null)
            {
                result = ConfigurationManager.AppSettings[binder.Name];

                return true;
            }
            else
            {
                result = null;

                return true;
            }
        }

        public bool Exists(string key)
        {
            return ConfigurationManager.AppSettings[key] != null;
        }
        //public override bool TrySetMember(SetMemberBinder binder, object value)
        //{
        //    properties[binder.Name] = value;
        //    return true;
        //}
    }
}
