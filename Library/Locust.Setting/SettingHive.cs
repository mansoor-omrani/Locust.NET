using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Locust.Db;

namespace Locust.Setting
{
    public class SettingHive : ISetting
    {
        private AppConfigSettings _cfg;
        private DbSettings _dbcfg;
        private IDbHelper _db;
        private int _appid;
        public SettingHive(int appid, IDbHelper db)
        {
            _appid = appid;
            _db = db;
            LazyInitializer.EnsureInitialized<AppConfigSettings>(ref _cfg);
            LazyInitializer.EnsureInitialized<DbSettings>(ref _dbcfg, () => new DbSettings(appid, _db));
        }
        public dynamic Config
        {
            get { return _cfg; }
        }
        public dynamic Db
        {
            get { return _dbcfg; }
        }
        public dynamic Text
        {
            get { return null; }
        }
    }
}
