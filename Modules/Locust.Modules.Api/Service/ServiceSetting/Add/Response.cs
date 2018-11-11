using System;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingAddResponse : BaseServiceResponse<object, ServiceSettingAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ServiceSettingAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ServiceSettingAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ServiceSettingAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ServiceSettingAddStatus.Faulted;
        }

        public ServiceSettingAddResponse()
            : this(ServiceSettingAddStatus.None, default(object))
        { }
        public ServiceSettingAddResponse(ServiceSettingAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ServiceSettingAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ServiceSettingAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ServiceSettingAddStatus.Failed;
        }

		public override void Errored()
        {
            this.Status = ServiceSettingAddStatus.Errored;
        }
		
		public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ServiceSettingAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ServiceSettingAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ServiceSettingAddStatus.InvalidStatus;
        }
    }
}