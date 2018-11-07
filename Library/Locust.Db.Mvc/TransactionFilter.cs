using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Db.Mvc
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        public bool Distributed { get; set; }
        public bool SpanResult { get; set; }
        public IDbHelper Db { get; set; }

        public TransactionAttribute():this(false,false)
        {
        }
        public TransactionAttribute(bool distributed, bool spanResult)
        {
            Distributed = distributed;
            SpanResult = spanResult;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Db != null)
            {
                Db.BeginTran(false);
            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Db != null && !SpanResult)
            {
                if (filterContext.Exception == null)
                {
                    Db.Commit();
                }
                else
                {
                    Db.Rollback();
                }
            }
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (Db != null && SpanResult)
            {
                if (filterContext.Exception == null)
                {
                    Db.Commit();
                }
                else
                {
                    Db.Rollback();
                }
            }
            base.OnResultExecuted(filterContext);
        }
    }
}
