using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Data;
using Locust.Db;

namespace Locust.ServiceModel
{
    public interface IBaseServiceRequest
    {
    }

    public class BaseServiceRequest: IBaseServiceRequest
    {
        protected List<string> overrideList;

        public virtual List<string> GetOverrideList()
        {
            return overrideList;
        }

        public void AddOverride(string name)
        {
            if (overrideList == null)
            {
                overrideList = new List<string>();
            }

            overrideList.Add(name);
        }
        public virtual bool GetValue(string propertyName, out object value)
        {
            value = null;

            return false;
        }
    }
    public class BaseServicePageRequest: BaseServiceRequest
    {
        public CommandParameter Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Filters { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; }
        public BaseServicePageRequest()
        {
            Count = CommandParameter.Output(SqlDbType.Int);
        }
    }
}
