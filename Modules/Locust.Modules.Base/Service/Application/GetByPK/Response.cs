using System;
using Locust.ServiceModel;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetByPKResponse : BaseServiceResponse<Application.Full, ApplicationGetByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApplicationGetByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApplicationGetByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApplicationGetByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApplicationGetByPKStatus.Faulted;
        }

        public ApplicationGetByPKResponse()
            : this(ApplicationGetByPKStatus.None, default(Application.Full))
        { }
        public ApplicationGetByPKResponse(ApplicationGetByPKStatus status,Application.Full data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApplicationGetByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApplicationGetByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApplicationGetByPKStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApplicationGetByPKStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApplicationGetByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApplicationGetByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApplicationGetByPKStatus.InvalidStatus;
        }
    }
}