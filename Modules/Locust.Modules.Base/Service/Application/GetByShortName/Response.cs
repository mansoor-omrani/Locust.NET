using System;
using Application = Locust.Modules.Base.Model.Application;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetByShortNameResponse : BaseServiceResponse<Application.AdminGrid, ApplicationGetByShortNameStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApplicationGetByShortNameStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApplicationGetByShortNameStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApplicationGetByShortNameStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApplicationGetByShortNameStatus.Faulted;
        }

        public ApplicationGetByShortNameResponse()
            : base(ApplicationGetByShortNameStatus.None, default(Application.AdminGrid))
        { }
        public ApplicationGetByShortNameResponse(ApplicationGetByShortNameStatus status,Application.AdminGrid data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApplicationGetByShortNameStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApplicationGetByShortNameStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApplicationGetByShortNameStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApplicationGetByShortNameStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = ApplicationGetByShortNameStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApplicationGetByShortNameStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApplicationGetByShortNameStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            this.Status = ApplicationGetByShortNameStatus.NotFound;
        }
    }
}