using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.WebTools
{
    public class Tree
    {
        private DataTable _source;
        private StringBuilder sb;
        public Tree()
        {
            KeyName = "ID";
            ParentKeyName = "ParentID";
            DataName = "Data";
            ItemFormat = "<a href='/{0}'>{1}</a>";
            CurrentItemFormat = "<a href='/{0}'><b>{1}</b></a>";
            CurrentKey = 0;

            sb = new StringBuilder();
        }
        public DataTable DataSource
        {
            get { return _source; }
            set { _source = value; }
        }
        public string KeyName { get; set; }
        public string ParentKeyName { get; set; }
        public string DataName { get; set; }
        public string ItemFormat { get; set; }
        public string CurrentItemFormat { get; set; }
        public int CurrentKey { get; set; }

        private void render(int id)
        {
            var data = _source.Select(string.Format("{0}={1}", KeyName, id));

            if (data.Length > 0)
            {
                if ((int)data[0][KeyName] == CurrentKey)
                    sb.Append("<li>" + string.Format(CurrentItemFormat, data[0][KeyName], data[0][DataName]));
                else
                    sb.Append("<li>" + string.Format(ItemFormat, data[0][KeyName], data[0][DataName]));

                var children = _source.Select(string.Format("{0}={1}", ParentKeyName, data[0][KeyName]));
                if (children.Length > 0)
                {
                    sb.Append("<ul>");
                    foreach (DataRow r in children)
                    {
                        render((int)r[KeyName]);
                    }
                    sb.Append("</ul>");
                }
                sb.Append("</li>");
            }
        }
        public string Render()
        {
            sb.Append("<ul>");

            var data = _source.Select(string.Format("{0}=0 or {0} is null", ParentKeyName));

            if (data.Length > 0)
                render((int)data[0][KeyName]);

            sb.Append("</ul>");

            return sb.ToString();
        }
    }
}
