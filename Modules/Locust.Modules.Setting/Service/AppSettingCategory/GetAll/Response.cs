using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
using AppSettingCategory = Locust.Modules.Setting.Model.AppSettingCategory.Full;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryGetAllResponse : BaseServiceListResponse<AppSettingCategory, AppSettingCategoryGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingCategoryGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingCategoryGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingCategoryGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingCategoryGetAllStatus.Faulted;
        }

        public AppSettingCategoryGetAllResponse()
            : this(AppSettingCategoryGetAllStatus.None, new List<AppSettingCategory>())
        { }
        public AppSettingCategoryGetAllResponse(AppSettingCategoryGetAllStatus status, IList<AppSettingCategory> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingCategoryGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingCategoryGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingCategoryGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingCategoryGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingCategoryGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingCategoryGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingCategoryGetAllStatus.InvalidStatus;
        }
    }
}