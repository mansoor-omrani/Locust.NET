using System;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationUpdateResponse : BaseServiceResponse<object, ApplicationUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApplicationUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApplicationUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApplicationUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApplicationUpdateStatus.Faulted;
        }

        public ApplicationUpdateResponse()
            : this(ApplicationUpdateStatus.None, default(object))
        { }
        public ApplicationUpdateResponse(ApplicationUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApplicationUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApplicationUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApplicationUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApplicationUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApplicationUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApplicationUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApplicationUpdateStatus.InvalidStatus;
        }
    }
}