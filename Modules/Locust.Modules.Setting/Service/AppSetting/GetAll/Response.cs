using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using AppSetting = Locust.Modules.Setting.Model.AppSetting.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingGetAllResponse : BaseServiceListResponse<AppSetting, AppSettingGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingGetAllStatus.Faulted;
        }

        public AppSettingGetAllResponse()
            : this(AppSettingGetAllStatus.None, new List<AppSetting>())
        { }
        public AppSettingGetAllResponse(AppSettingGetAllStatus status, IList<AppSetting> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingGetAllStatus.InvalidStatus;
        }
    }
}