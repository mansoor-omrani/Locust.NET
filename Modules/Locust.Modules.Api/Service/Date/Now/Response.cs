using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class DateNowResponse : BaseServiceResponse<object, DateNowStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == DateNowStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == DateNowStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == DateNowStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == DateNowStatus.Faulted;
        }

        public DateNowResponse()
            : this(DateNowStatus.None, default(object))
        { }
        public DateNowResponse(DateNowStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = DateNowStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = DateNowStatus.Success;
        }

		public override void Failed()
        {
            this.Status = DateNowStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = DateNowStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = DateNowStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = DateNowStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != DateNowStatus.InvalidStatus;
        }
    }
}