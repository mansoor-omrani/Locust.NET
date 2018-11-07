using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.WebTools.Providers
{
    public class FakeHttpContext:HttpContextBase
    {

        #region AllErrors
        private Exception[] allErrors;
        public override Exception[] AllErrors
        {
            get
            {
                return allErrors;
            }
        }
        public void SetAllErrors(Exception[] value)
        {
            allErrors = value;
        }
        #endregion

        #region AllowAsyncDuringSyncStages
        private bool allowAsyncDuringSyncStages;
        public override bool AllowAsyncDuringSyncStages
        {
            get
            {
                return allowAsyncDuringSyncStages;
            }
        }
        public void SetAllowAsyncDuringSyncStages(bool value)
        {
            allowAsyncDuringSyncStages = value;
        }
        #endregion

        #region Application
        private HttpApplicationStateBase application;
        public override HttpApplicationStateBase Application
        {
            get
            {
                return application;
            }
        }
        public void SetApplication(HttpApplicationStateBase value)
        {
            application = value;
        }
        #endregion

        #region ApplicationInstance
        private HttpApplication applicationInstance;
        public override HttpApplication ApplicationInstance
        {
            get
            {
                return applicationInstance;
            }
        }
        public void SetApplicationInstance(HttpApplication value)
        {
            applicationInstance = value;
        }
        #endregion




        public FakeHttpContext()
        {
            SetAllErrors(new Exception[0]);
            SetApplication(new FakeHttpApplicationState());
            SetApplicationInstance(new FakeHttpApplication());
        }
    }
}
