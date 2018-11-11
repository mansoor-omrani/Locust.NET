using System;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginDeleteResponse : BaseServiceResponse<object, AppCrossOriginDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppCrossOriginDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppCrossOriginDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppCrossOriginDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppCrossOriginDeleteStatus.Faulted;
        }

        public AppCrossOriginDeleteResponse()
            : this(AppCrossOriginDeleteStatus.None, default(object))
        { }
        public AppCrossOriginDeleteResponse(AppCrossOriginDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppCrossOriginDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppCrossOriginDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppCrossOriginDeleteStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppCrossOriginDeleteStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppCrossOriginDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppCrossOriginDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppCrossOriginDeleteStatus.InvalidStatus;
        }
    }
}