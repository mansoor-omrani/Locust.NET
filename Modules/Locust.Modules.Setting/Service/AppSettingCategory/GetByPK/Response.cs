using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetByPKResponse : BaseServiceResponse<AppSettingCategory, AppSettingCategoryGetByPKStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingCategoryGetByPKStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingCategoryGetByPKStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingCategoryGetByPKStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingCategoryGetByPKStatus.Faulted;
        }

        public AppSettingCategoryGetByPKResponse()
            : this(AppSettingCategoryGetByPKStatus.None, default(AppSettingCategory))
        { }
        public AppSettingCategoryGetByPKResponse(AppSettingCategoryGetByPKStatus status,AppSettingCategory data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingCategoryGetByPKStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingCategoryGetByPKStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingCategoryGetByPKStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingCategoryGetByPKStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingCategoryGetByPKStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingCategoryGetByPKStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingCategoryGetByPKStatus.InvalidStatus;
        }
    }
}