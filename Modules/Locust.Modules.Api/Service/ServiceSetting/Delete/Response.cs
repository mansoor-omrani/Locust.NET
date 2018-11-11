using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingDeleteResponse : BaseServiceResponse<object, ServiceSettingDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ServiceSettingDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ServiceSettingDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ServiceSettingDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ServiceSettingDeleteStatus.Faulted;
        }

        public ServiceSettingDeleteResponse()
            : this(ServiceSettingDeleteStatus.None, default(object))
        { }
        public ServiceSettingDeleteResponse(ServiceSettingDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ServiceSettingDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ServiceSettingDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ServiceSettingDeleteStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ServiceSettingDeleteStatus.Errored;
        }
		
		public override void NotFound()
        {
            this.Status = ServiceSettingDeleteStatus.NotFound;
        }

		public override bool SetStatus(object status)
        {
            var result = ServiceSettingDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ServiceSettingDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ServiceSettingDeleteStatus.InvalidStatus;
        }
    }
}