using System;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginUpdateResponse : BaseServiceResponse<object, AppCrossOriginUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppCrossOriginUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppCrossOriginUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppCrossOriginUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppCrossOriginUpdateStatus.Faulted;
        }

        public AppCrossOriginUpdateResponse()
            : this(AppCrossOriginUpdateStatus.None, default(object))
        { }
        public AppCrossOriginUpdateResponse(AppCrossOriginUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppCrossOriginUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppCrossOriginUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppCrossOriginUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppCrossOriginUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppCrossOriginUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppCrossOriginUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppCrossOriginUpdateStatus.InvalidStatus;
        }
    }
}