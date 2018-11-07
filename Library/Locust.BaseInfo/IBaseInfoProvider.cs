using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;

namespace Locust.BaseInfo
{
    public interface IBaseInfoProvider
    {
        IDbHelper Db { get; set; }
        IEnumerable<BasicData> GetAll();
        Dictionary<string, string> GetAllAsDictionary(string category);
        BasicData GetByCode(string category, string code);
        BasicData GetByCode(string category, int code);
        BasicData GetById(string category, int id);
        BasicData GetByName(string category, string name);
        string GetCode(Enum e);
        int GetId(Enum e);
    }
}
