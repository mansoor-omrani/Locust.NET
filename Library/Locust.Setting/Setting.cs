using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using Locust.Db;
using Locust.Setting;

namespace Locust.Setting
{
    public static class Setting
    {
        private static SettingHive _hive;
        private static int _appId;
        private static IDbHelper _db;
        public static int AppId
        {
            get { return _appId; }
            set
            {
                _hive = null;
                _appId = value;
            }
        }

        private static SettingHive hive
        {
            get
            {
                LazyInitializer.EnsureInitialized<SettingHive>(ref _hive, () => new SettingHive(_appId, _db));

                return _hive;
            }
        }
        static Setting()
        {
            _db = DA.DefaultDb;
        }
        public static dynamic Config
        {
            get { return hive.Config; }
        }

        public static dynamic Db
        {
            get { return hive.Db; }
        }

        public static dynamic Text
        {
            get { throw new NotImplementedException(); }
        }
    }
}