using System;
using Locust.ServiceModel;

using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.Full;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginGetByPKResponse : BaseServiceResponse<AppCrossOrigin, AppCrossOriginGetByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppCrossOriginGetByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppCrossOriginGetByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppCrossOriginGetByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppCrossOriginGetByPKStatus.Faulted;
        }

        public AppCrossOriginGetByPKResponse()
            : this(AppCrossOriginGetByPKStatus.None, default(AppCrossOrigin))
        { }
        public AppCrossOriginGetByPKResponse(AppCrossOriginGetByPKStatus status,AppCrossOrigin data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppCrossOriginGetByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppCrossOriginGetByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppCrossOriginGetByPKStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppCrossOriginGetByPKStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppCrossOriginGetByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppCrossOriginGetByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppCrossOriginGetByPKStatus.InvalidStatus;
        }
    }
}