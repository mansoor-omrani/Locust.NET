using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ServiceSetting = Locust.Modules.Api.Model.ServiceSetting;

namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingGetAllByServiceResponse : BaseServiceListResponse<ServiceSetting.Full, ServiceSettingGetAllByServiceStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ServiceSettingGetAllByServiceStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ServiceSettingGetAllByServiceStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ServiceSettingGetAllByServiceStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ServiceSettingGetAllByServiceStatus.Faulted;
        }

        public ServiceSettingGetAllByServiceResponse()
            : this(ServiceSettingGetAllByServiceStatus.None, new List<ServiceSetting.Full>())
        { }
        public ServiceSettingGetAllByServiceResponse(ServiceSettingGetAllByServiceStatus status, IList<ServiceSetting.Full> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ServiceSettingGetAllByServiceStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ServiceSettingGetAllByServiceStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ServiceSettingGetAllByServiceStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ServiceSettingGetAllByServiceStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ServiceSettingGetAllByServiceStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ServiceSettingGetAllByServiceStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ServiceSettingGetAllByServiceStatus.InvalidStatus;
        }
    }
}