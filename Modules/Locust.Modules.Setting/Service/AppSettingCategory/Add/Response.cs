using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingCategoryAddResponse : BaseServiceResponse<object, AppSettingCategoryAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingCategoryAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingCategoryAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingCategoryAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingCategoryAddStatus.Faulted;
        }

        public AppSettingCategoryAddResponse()
            : this(AppSettingCategoryAddStatus.None, default(object))
        { }
        public AppSettingCategoryAddResponse(AppSettingCategoryAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingCategoryAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingCategoryAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingCategoryAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingCategoryAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingCategoryAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingCategoryAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingCategoryAddStatus.InvalidStatus;
        }
    }
}