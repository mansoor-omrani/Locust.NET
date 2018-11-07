using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locust.Repository
{
    public class PageResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public long RecordCount { get; set; }
        public T Items { get; set; }
    }
    public class PageListResult<T>: PageResult<List<T>>
    {
        public PageListResult()
        {
            Items = new List<T>();
        }
    }
}