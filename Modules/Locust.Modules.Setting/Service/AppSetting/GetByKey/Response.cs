using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetByKeyResponse : BaseServiceResponse<AppSetting, AppSettingGetByKeyStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingGetByKeyStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingGetByKeyStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingGetByKeyStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingGetByKeyStatus.Faulted;
        }

        public AppSettingGetByKeyResponse()
            : this(AppSettingGetByKeyStatus.None, default(AppSetting))
        { }
        public AppSettingGetByKeyResponse(AppSettingGetByKeyStatus status,AppSetting data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingGetByKeyStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingGetByKeyStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingGetByKeyStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingGetByKeyStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingGetByKeyStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingGetByKeyStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingGetByKeyStatus.InvalidStatus;
        }
    }
}