using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetAllResponse : BaseServiceListResponse<Application.AdminGrid, ApplicationGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApplicationGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApplicationGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApplicationGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApplicationGetAllStatus.Faulted;
        }

        public ApplicationGetAllResponse()
            : this(ApplicationGetAllStatus.None, new List<Application.AdminGrid>())
        { }
        public ApplicationGetAllResponse(ApplicationGetAllStatus status, IList<Application.AdminGrid> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApplicationGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApplicationGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApplicationGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApplicationGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApplicationGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApplicationGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApplicationGetAllStatus.InvalidStatus;
        }
    }
}