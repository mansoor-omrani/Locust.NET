using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetByPKResponse : BaseServiceResponse<AppSetting, AppSettingGetByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingGetByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingGetByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingGetByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingGetByPKStatus.Faulted;
        }

        public AppSettingGetByPKResponse()
            : this(AppSettingGetByPKStatus.None, default(AppSetting))
        { }
        public AppSettingGetByPKResponse(AppSettingGetByPKStatus status,AppSetting data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingGetByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingGetByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingGetByPKStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingGetByPKStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingGetByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingGetByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingGetByPKStatus.InvalidStatus;
        }
    }
}