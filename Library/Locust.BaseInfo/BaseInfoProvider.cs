using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Caching;
using Locust.Db;
using Locust.Extensions;
using Locust.Base;

namespace Locust.BaseInfo
{
    public class SqlBaseInfoProvider : IBaseInfoProvider
    {
        protected string CACHE_KEY = "ALL";
        public IDbHelper Db { get; set; }
        public ICacheManager Cache { get; set; }
        public SqlBaseInfoProvider(IDbHelper db, ICacheManager cache)
        {
            Db = db;
            Cache = cache;

            Load();
        }
        public virtual bool Load()
        {
            var result = true;

            try
            {
                var cmd = new SqlCommand("usp0_BaseInfo_read_all");
                cmd.CommandType = CommandType.StoredProcedure;
                var dbr = Db.ExecuteTable(cmd);

                Cache.Add(CACHE_KEY, dbr.Data);
            }
            catch
            {
                result = false;
            }

            return result;
        }
        public Dictionary<string, string> GetAllAsDictionary(string category)
        {
            var result = new Dictionary<string, string>();
            var data = GetAll(category);

            foreach (var d in data)
            {
                var title = d["Title"];

                if (title != null && title != DBNull.Value)
                {
                    result.Add(d["ID"].ToString(), title.ToString());
                }
                else
                {
                    result.Add(d["ID"].ToString(), "");
                }
            }

            return result;
        }
        public IEnumerable<BasicData> GetAll()
        {
            var result = new BasicData[] {};
            
            var dt = Cache.Get<DataTable>(CACHE_KEY);

            if (dt == null)
            {
                Load();
            }

            dt = Cache.Get<DataTable>(CACHE_KEY);

            if (dt != null && dt.Rows.Count > 0)
            {
                result = new BasicData[dt.Rows.Count];
                var i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    result[i++] = new BasicData
                        {
                            Category = SafeClrConvert.ToString(row["Category"]),
                            Id = SafeClrConvert.ToInt32(row["Id"]),
                            Name = SafeClrConvert.ToString(row["Name"]),
                            Title = SafeClrConvert.ToString(row["Title"]),
                            Description = SafeClrConvert.ToString(row["Description"]),
                            Code = SafeClrConvert.ToString(row["Code"]),
                            Parent = SafeClrConvert.ToInt32(row["Parent"])
                    };
                }
            }

            return result;
        }
        public DataRow[] GetAll(string category)
        {
            var result = new DataRow[] { };

            var dt = Cache.Get<DataTable>(CACHE_KEY);

            if (dt == null)
            {
                Load();
            }

            dt = Cache.Get<DataTable>(CACHE_KEY);

            if (dt != null)
            {
                result = dt.Select("Category='" + category + "'");
            }

            return result;
        }

        protected BasicData read(string category, DataRow row)
        {
            var result = new BasicData
            {
                Id = SafeClrConvert.ToInt32(row["ID"]),
                Category = category,
                Name = SafeClrConvert.ToString(row["Name"]),
                Title = SafeClrConvert.ToString(row["Title"]),
                Code = SafeClrConvert.ToString(row["Code"]),
                Description = SafeClrConvert.ToString(row["Description"])
            };

            return result;
        }
        public BasicData GetByCode(string category, string code)
        {
            var result = new BasicData();
            var rows = GetAll(category);

            foreach (var row in rows)
            {
                var _code = SafeClrConvert.ToString(row["Code"]);

                if (string.Compare(_code, code, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    result = read(category, row);

                    break;
                }
            }

            return result;
        }
        public BasicData GetByCode(string category, int code)
        {
            return GetByCode(category, code.ToString());
        }
        public BasicData GetById(string category, int id)
        {
            var result = new BasicData();
            var rows = GetAll(category);
            
            foreach (var row in rows)
            {
                var _id = SafeClrConvert.ToInt32(row["ID"]);

                if (id == _id)
                {
                    result = read(category, row);
                }
            }

            return result;
        }
        public BasicData GetByName(string category, string name)
        {
            var result = new BasicData();
            var rows = GetAll(category);

            foreach (var row in rows)
            {
                var _name = SafeClrConvert.ToString(row["Name"]);

                if (string.Compare(_name, name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    result = read(category, row);
                }
            }

            return result;
        }
        public string GetCode(Enum e)
        {
            var result = ((int)((object)e)).ToString();

            return result;
        }
        public int GetId(Enum e)
        {
            var r = GetByCode(e.GetType().Name, ((int) ((object) e)));

            return r.Id;
        }
    }
}
