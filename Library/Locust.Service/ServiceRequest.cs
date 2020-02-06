using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service
{
    public class ServiceRequest
    {
    }
    public class ServiceRequest<T>: ServiceRequest
    {
        public T Model { get; set; }
    }
    public class ServiceRequestByPK<PK>: ServiceRequest
    {
        public PK Key { get; set; }
    }
    public class ServiceRequestByPK<PK1, PK2> : ServiceRequest
    {
        public PK1 Key1 { get; set; }
        public PK2 Key2 { get; set; }
    }
    public class ServiceRequestByPK<PK1, PK2, PK3> : ServiceRequest
    {
        public PK1 Key1 { get; set; }
        public PK2 Key2 { get; set; }
        public PK3 Key3 { get; set; }
    }
    public class ServiceFilteringRequest: ServiceRequest
    {
        public string Filter { get; set; }
        public string[] OrderBy { get; set; }
        public string[] OrderDir { get; set; }
    }
    public class ServicePagingRequest : ServiceFilteringRequest
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
