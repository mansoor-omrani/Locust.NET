using System;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationDeleteResponse : BaseServiceResponse<object, ApplicationDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApplicationDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApplicationDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApplicationDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApplicationDeleteStatus.Faulted;
        }

        public ApplicationDeleteResponse()
            : this(ApplicationDeleteStatus.None, default(object))
        { }
        public ApplicationDeleteResponse(ApplicationDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApplicationDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApplicationDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApplicationDeleteStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApplicationDeleteStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApplicationDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApplicationDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApplicationDeleteStatus.InvalidStatus;
        }
    }
}