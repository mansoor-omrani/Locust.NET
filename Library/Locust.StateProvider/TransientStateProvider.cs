using Locust.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.StateProvider
{
    public class TransientStateProvider<T> : BaseStateProvider<T> where T : class, new()
    {
        #region ctor
        public TransientStateProvider(string name) : base(name)
        { }
        public TransientStateProvider(string name, HttpContextBase httpContext) : base(name, httpContext)
        {
        }

        public override bool Exists()
        {
            return false;
        }
        #endregion
        public override void Restore()
        { }

        protected override void StoreInternal()
        { }
    }
}
