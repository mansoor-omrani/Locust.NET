using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPSetIsActiveResponse : BaseServiceResponse<object, ApiClientIPSetIsActiveStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiClientIPSetIsActiveStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiClientIPSetIsActiveStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiClientIPSetIsActiveStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiClientIPSetIsActiveStatus.Faulted;
        }

        public ApiClientIPSetIsActiveResponse()
            : this(ApiClientIPSetIsActiveStatus.None, default(object))
        { }
        public ApiClientIPSetIsActiveResponse(ApiClientIPSetIsActiveStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiClientIPSetIsActiveStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiClientIPSetIsActiveStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiClientIPSetIsActiveStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiClientIPSetIsActiveStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiClientIPSetIsActiveStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiClientIPSetIsActiveStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiClientIPSetIsActiveStatus.InvalidStatus;
        }
    }
}