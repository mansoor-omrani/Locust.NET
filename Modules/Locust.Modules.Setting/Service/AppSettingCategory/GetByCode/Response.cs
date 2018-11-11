using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetByCodeResponse : BaseServiceResponse<AppSettingCategory, AppSettingCategoryGetByCodeStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingCategoryGetByCodeStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingCategoryGetByCodeStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingCategoryGetByCodeStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingCategoryGetByCodeStatus.Faulted;
        }

        public AppSettingCategoryGetByCodeResponse()
            : this(AppSettingCategoryGetByCodeStatus.None, default(AppSettingCategory))
        { }
        public AppSettingCategoryGetByCodeResponse(AppSettingCategoryGetByCodeStatus status,AppSettingCategory data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingCategoryGetByCodeStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingCategoryGetByCodeStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingCategoryGetByCodeStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingCategoryGetByCodeStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingCategoryGetByCodeStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingCategoryGetByCodeStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingCategoryGetByCodeStatus.InvalidStatus;
        }
    }
}