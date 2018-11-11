using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiUpdateResponse : BaseServiceResponse<object, ApiUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiUpdateStatus.Faulted;
        }

        public ApiUpdateResponse()
            : this(ApiUpdateStatus.None, default(object))
        { }
        public ApiUpdateResponse(ApiUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiUpdateStatus.InvalidStatus;
        }
    }
}