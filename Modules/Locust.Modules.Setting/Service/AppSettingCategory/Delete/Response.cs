using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryDeleteResponse : BaseServiceResponse<object, AppSettingCategoryDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingCategoryDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingCategoryDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingCategoryDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingCategoryDeleteStatus.Faulted;
        }

        public AppSettingCategoryDeleteResponse()
            : this(AppSettingCategoryDeleteStatus.None, default(object))
        { }
        public AppSettingCategoryDeleteResponse(AppSettingCategoryDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingCategoryDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingCategoryDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingCategoryDeleteStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingCategoryDeleteStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingCategoryDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingCategoryDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingCategoryDeleteStatus.InvalidStatus;
        }
    }
}