using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Db
{
    public static class DataExtensions
    {
        public static string Merge(this DataTable table, string cellSeparator = ",", string rowSeparator = "\r\n")
        {
            var sb = new StringBuilder();

            foreach (DataRow row in table.Rows)
            {
                var temp = "";

                for (var i = 0; i < row.Table.Columns.Count; i++)
                {
                    if (temp == "")
                        temp = row[i].ToString();
                    else
                        temp = temp + cellSeparator + row[i].ToString();
                }

                if (sb.Length > 0)
                    sb.Append(rowSeparator + temp);
                else
                    sb.Append(temp);
            }

            var result = sb.ToString();

            return result;
        }
        public static string Merge(this DataTable table, string[] cols, string cellSeparator = ",", string rowSeparator = "\r\n")
        {
            var sb = new StringBuilder();
            var indexes = new List<int>();

            foreach (var col in cols)
            {
                for (var i = 0; i < table.Columns.Count; i++)
                {
                    if (String.Compare(table.Columns[i].ColumnName, col, true) == 0)
                    {
                        indexes.Add(i);
                    }
                }
            }

            if (indexes.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var temp = "";

                    foreach (var index in indexes)
                    {
                        if (temp == "")
                            temp = row[index].ToString();
                        else
                            temp = temp + cellSeparator + row[index].ToString();
                    }

                    if (sb.Length > 0)
                        sb.Append(rowSeparator + temp);
                    else
                        sb.Append(temp);
                }
            }

            var result = sb.ToString();

            return result;
        }
    }
}
