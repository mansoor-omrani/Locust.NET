using System;
using Locust.ServiceModel;
namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationAddResponse : BaseServiceResponse<object, ApplicationAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApplicationAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApplicationAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApplicationAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApplicationAddStatus.Faulted;
        }

        public ApplicationAddResponse()
            : this(ApplicationAddStatus.None, default(object))
        { }
        public ApplicationAddResponse(ApplicationAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApplicationAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApplicationAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApplicationAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApplicationAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApplicationAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApplicationAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApplicationAddStatus.InvalidStatus;
        }
    }
}