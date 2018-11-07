using Locust.Conversion;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;

namespace Locust.Setting
{
    public class AppSettingCategoryModel
    {
        public int AppSettingCategoryID { get; set; }
        public int AppID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
    public class AppSettingModel
    {
        public int AppSettingCategoryID { get; set; }
        public int AppSettingID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Encrypted { get; set; }
        public string DecryptedValue { get; set; }
        public AppSettingCategoryModel Category { get; set; }
    }
    public class DbSettings : DynamicObject
    {
        private object _sync;
        private bool _reloading;
        private int _appid;
        private ConcurrentDictionary<int, AppSettingCategoryModel> _categories;
        private ConcurrentDictionary<string, AppSettingModel> _settings;
        private IDbHelper _db;
        public DbSettings(int appid, IDbHelper db)
        {
            _sync = new object();
            _reloading = false;
            _db = db;
            _appid = appid;
            _categories = new ConcurrentDictionary<int, AppSettingCategoryModel>();
            _settings = new ConcurrentDictionary<string, AppSettingModel>();

            LoadCategories();
            LoadSettings();
        }

        public void Reload()
        {
            _reloading = true;

            lock (_sync)
            {
                _settings.Clear();
                _categories.Clear();

                LoadCategories();
                LoadSettings();

                _reloading = false;
            }
        }
        private void LoadCategories()
        {
            var cmd = new SqlCommand("usp1_AppSettingCategory_get_all");
            var dbr = _db.ExecuteReader(cmd, (reader) =>
            {
                var cat = new AppSettingCategoryModel
                {
                    AppID = SafeClrConvert.ToInt32(reader["AppID"]),
                    AppSettingCategoryID = SafeClrConvert.ToInt32(reader["AppSettingCategoryID"]),
                    Title = SafeClrConvert.ToString(reader["AppID"]),
                    Description = SafeClrConvert.ToString(reader["AppID"]),
                    Code = SafeClrConvert.ToString(reader["AppID"])
                };

                _categories.TryAdd(cat.AppSettingCategoryID, cat);

                return cat;
            });
        }
        private void LoadSettings()
        {
            var cmd = _db.GetCommand("usp1_AppSetting_get_all");
            
            (cmd as SqlCommand).Parameters.AddWithValue("@AppId", _appid);

            var dbr = _db.ExecuteReader(cmd, (reader) =>
            {
                var x = new AppSettingModel
                {
                    AppSettingCategoryID = SafeClrConvert.ToInt32(reader["AppSettingCategoryID"]),
                    AppSettingID = SafeClrConvert.ToInt32(reader["AppSettingID"]),
                    Title = SafeClrConvert.ToString(reader["Title"]),
                    Description = SafeClrConvert.ToString(reader["Description"]),
                    Key = SafeClrConvert.ToString(reader["Key"]),
                    Value = SafeClrConvert.ToString(reader["Value"]),
                    Encrypted = SafeClrConvert.ToBoolean(reader["Encrypted"]),
                    DecryptedValue = SafeClrConvert.ToString(reader["DecryptedValue"])
                };

                x.Category = _categories[x.AppSettingCategoryID];

                _settings.TryAdd(x.Key, x);

                return x;
            });
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;

            if (_settings == null)
            {
                Reload();
            }

            if (_settings != null && _settings.Count > 0)
            {
                try
                {
                    var setting = _settings[binder.Name];

                    if (setting != null)
                    {
                        if (!_reloading)
                            result = (setting.Encrypted) ? setting.DecryptedValue : setting.Value;
                        else
                        {
                            lock (_sync)
                            {
                                result = (setting.Encrypted) ? setting.DecryptedValue : setting.Value;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            return true;
        }

        public ICollection<AppSettingModel> GetAll()
        {
            return _settings.Values;
        }
    }
}
