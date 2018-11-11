using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingUpdateResponse : BaseServiceResponse<object, ApiSettingUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiSettingUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiSettingUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiSettingUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiSettingUpdateStatus.Faulted;
        }

        public ApiSettingUpdateResponse()
            : this(ApiSettingUpdateStatus.None, default(object))
        { }
        public ApiSettingUpdateResponse(ApiSettingUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiSettingUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiSettingUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiSettingUpdateStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiSettingUpdateStatus.Errored;
        }
		
		public override void NotFound()
        {
            this.Status = ApiSettingUpdateStatus.NotFound;
        }

		public override bool SetStatus(object status)
        {
            var result = ApiSettingUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiSettingUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiSettingUpdateStatus.InvalidStatus;
        }
    }
}