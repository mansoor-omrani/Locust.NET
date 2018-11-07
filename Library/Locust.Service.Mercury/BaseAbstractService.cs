using Locust.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public abstract class BaseAbstractServiceEF : IService
    {
        public IExceptionLogger Logger { get; set; }
        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #region context
        private DbContext context;
        public DbContext Context
        {
            get { return context; }
            set { SetContext(value); }
        }
        protected virtual void SetContext(DbContext value)
        {
            context = value;
        }
        #endregion
        public BaseAbstractServiceEF(IExceptionLogger logger, DbContext context)
        {
            Logger = logger;

            this.context = context;
        }
        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }
        public virtual Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
