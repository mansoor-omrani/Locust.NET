using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingAddResponse : BaseServiceResponse<object, ApiSettingAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiSettingAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiSettingAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiSettingAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiSettingAddStatus.Faulted;
        }

        public ApiSettingAddResponse()
            : this(ApiSettingAddStatus.None, default(object))
        { }
        public ApiSettingAddResponse(ApiSettingAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiSettingAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiSettingAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiSettingAddStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiSettingAddStatus.Errored;
        }
		
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiSettingAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiSettingAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiSettingAddStatus.InvalidStatus;
        }
    }
}