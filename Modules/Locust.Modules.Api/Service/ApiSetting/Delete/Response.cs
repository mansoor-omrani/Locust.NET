using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingDeleteResponse : BaseServiceResponse<object, ApiSettingDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiSettingDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiSettingDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiSettingDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiSettingDeleteStatus.Faulted;
        }

        public ApiSettingDeleteResponse()
            : this(ApiSettingDeleteStatus.None, default(object))
        { }
        public ApiSettingDeleteResponse(ApiSettingDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiSettingDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiSettingDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiSettingDeleteStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ApiSettingDeleteStatus.Errored;
        }
		
		public override void NotFound()
        {
            this.Status = ApiSettingDeleteStatus.NotFound;
        }

		public override bool SetStatus(object status)
        {
            var result = ApiSettingDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiSettingDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiSettingDeleteStatus.InvalidStatus;
        }
    }
}