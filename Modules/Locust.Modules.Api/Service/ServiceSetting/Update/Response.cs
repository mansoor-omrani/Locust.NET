using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingUpdateResponse : BaseServiceResponse<object, ServiceSettingUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ServiceSettingUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ServiceSettingUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ServiceSettingUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ServiceSettingUpdateStatus.Faulted;
        }

        public ServiceSettingUpdateResponse()
            : this(ServiceSettingUpdateStatus.None, default(object))
        { }
        public ServiceSettingUpdateResponse(ServiceSettingUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ServiceSettingUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ServiceSettingUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ServiceSettingUpdateStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ServiceSettingUpdateStatus.Errored;
        }
		
		public override void NotFound()
        {
            this.Status = ServiceSettingUpdateStatus.NotFound;
        }

		public override bool SetStatus(object status)
        {
            var result = ServiceSettingUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ServiceSettingUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ServiceSettingUpdateStatus.InvalidStatus;
        }
    }
}