using Locust.Logging;
using Locust.Repository;
using Locust.Repository.EF;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service.Mercury
{
    public interface IStrategyBasedService<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        TRepository Repository { get; set; }
        BaseServiceEFCreateStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Create { get; }
        BaseServiceEFEditStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Edit { get; }
        BaseServiceEFRemoveStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Remove { get; }
        BaseServiceEFRemoveByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> RemoveByPK { get; }
        BaseServiceEFDeleteStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Delete { get; }
        BaseServiceEFDeleteByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> DeleteByPK { get; }
        BaseServiceEFRecoverStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Recover { get; }
        BaseServiceEFRecoverByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> RecoverByPK { get; }
    }
    public class BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> :
        BaseUserService<TUser, TUserPK>, IStrategyBasedService<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public TRepository Repository { get; set; }
        private IRepository<TEntity, TEntityPK> defaultRepository;
        public IRepository<TEntity, TEntityPK> DefaultRepository
        {
            get
            {
                return Repository ?? defaultRepository;
            }
        }
        public BaseServiceEFCreateStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Create { get; protected set; }
        public BaseServiceEFEditStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Edit { get; protected set; }
        public BaseServiceEFRemoveStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Remove { get; protected set; }
        public BaseServiceEFRemoveByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> RemoveByPK { get; protected set; }
        public BaseServiceEFDeleteStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Delete { get; protected set; }
        public BaseServiceEFDeleteByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> DeleteByPK { get; protected set; }
        public BaseServiceEFRecoverStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> Recover { get; protected set; }
        public BaseServiceEFRecoverByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> RecoverByPK { get; protected set; }
        public BaseStrategyBasedUserServiceEF(   IExceptionLogger logger,
                                DbContext context,
                                IUserRepository<TUser, TUserPK> userRepo,
                                TRepository repo) : base(logger, context, userRepo)
        {
            Repository = repo;
            if (repo == null)
            {
                defaultRepository = new BaseRepositoryEF<TEntity, TEntityPK>(context);
            }
            else
            {
                var efRepo = Repository as BaseRepositoryEF;
                if (efRepo != null)
                {
                    efRepo.Context = context;
                }
            }

            InitStrategies(logger);
        }
        protected virtual void InitStrategies(IExceptionLogger logger)
        {
            Create = new BaseServiceEFCreateStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>(logger, this);
            Edit = new BaseServiceEFEditStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>(logger, this);
            Remove = new BaseServiceEFRemoveStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>(logger, this);
            RemoveByPK = new BaseServiceEFRemoveByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>(logger, this);
            Delete = new BaseServiceEFDeleteStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>(logger, this);
            DeleteByPK = new BaseServiceEFDeleteByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>(logger, this);
            Recover = new BaseServiceEFRecoverStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>(logger, this);
            RecoverByPK = new BaseServiceEFRecoverByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>(logger, this);
        }
        protected override void SetContext(DbContext value)
        {
            base.SetContext(value);
            var efRepo = Repository as BaseRepositoryEF;
            if (efRepo != null)
            {
                efRepo.Context = value;
            }
        }
    }
    
    public interface IBaseServiceStrategyEF<TReq, TRes>
    {
        Func<TReq, TRes, bool> OnInvoking { get; set; }
    }
    
    #region Create
    public class BaseServiceEFCreateRequest<TEntity> : BaseStrategyRequest<TEntity> { }
    public class BaseServiceEFCreateResponse : BaseStrategyResponse { }
    public class BaseServiceEFCreateStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        : BaseCreateStrategyEF<BaseServiceEFCreateRequest<TEntity>, BaseServiceEFCreateResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFCreateRequest<TEntity>, BaseServiceEFCreateResponse>
        where TRepository : class,  IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFCreateRequest<TEntity>, BaseServiceEFCreateResponse, bool> OnInvoking { get; set; }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>);
            }
        }
        public BaseServiceEFCreateStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> service) : base(logger, service)
        {
        }
        protected override bool DoCreate(BaseServiceEFCreateRequest<TEntity> request, BaseServiceEFCreateResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoCreate(request, response);
        }
        protected override void DoCreate(TEntity data)
        {
            StrongService.DefaultRepository.Add(data);
        }
    }
    #endregion
    #region Edit
    public class BaseServiceEFEditRequest<TEntity> : BaseStrategyRequest<TEntity> { }
    public class BaseServiceEFEditResponse : BaseStrategyResponse { }
    public class BaseServiceEFEditStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        : BaseEditStrategyEF<BaseServiceEFEditRequest<TEntity>, BaseServiceEFEditResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFEditRequest<TEntity>, BaseServiceEFEditResponse>
        where TRepository : class,  IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFEditRequest<TEntity>, BaseServiceEFEditResponse, bool> OnInvoking { get; set; }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>);
            }
        }
        public BaseServiceEFEditStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> service) : base(logger, service)
        {
        }
        protected override bool DoEdit(BaseServiceEFEditRequest<TEntity> request, BaseServiceEFEditResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoEdit(request, response);
        }
        protected override void DoEdit(TEntity data)
        {
            StrongService.DefaultRepository.Update(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }
    }
    #endregion
    #region Remove
    public class BaseServiceEFRemoveRequest<TEntity> : BaseStrategyRequest<TEntity> { }
    public class BaseServiceEFRemoveResponse : BaseStrategyResponse { }
    public class BaseServiceEFRemoveStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        : BaseRemoveStrategyEF<BaseServiceEFRemoveRequest<TEntity>, BaseServiceEFRemoveResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFRemoveRequest<TEntity>, BaseServiceEFRemoveResponse>
        where TRepository : class,  IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFRemoveRequest<TEntity>, BaseServiceEFRemoveResponse, bool> OnInvoking { get; set; }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>);
            }
        }
        public BaseServiceEFRemoveStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> service) : base(logger, service)
        {
        }
        protected override bool DoRemove(BaseServiceEFRemoveRequest<TEntity> request, BaseServiceEFRemoveResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoRemove(request, response);
        }
        protected override void DoRemove(TEntity data)
        {
            StrongService.DefaultRepository.Remove(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }
    }
    #endregion
    #region RemoveByPk
    public class BaseServiceEFRemoveByPKRequest<TEntityPK> : BaseStrategyRequest<TEntityPK> { }
    public class BaseServiceEFRemoveByPKResponse : BaseStrategyResponse { }
    public class BaseServiceEFRemoveByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        : BaseRemoveByPKStrategyEF<BaseServiceEFRemoveByPKRequest<TEntityPK>, BaseServiceEFRemoveByPKResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFRemoveByPKRequest<TEntityPK>, BaseServiceEFRemoveByPKResponse>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFRemoveByPKRequest<TEntityPK>, BaseServiceEFRemoveByPKResponse, bool> OnInvoking { get; set; }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>);
            }
        }
        public BaseServiceEFRemoveByPKStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> service) : base(logger, service)
        {
        }
        protected override bool DoRemoveByPK(BaseServiceEFRemoveByPKRequest<TEntityPK> request, BaseServiceEFRemoveByPKResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoRemoveByPK(request, response);
        }
        protected override void DoRemoveByPK(TEntityPK data)
        {
            StrongService.DefaultRepository.RemoveByPK(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }

        protected override TEntity GetEntityByPK(TEntityPK pk)
        {
            return StrongService.DefaultRepository.GetByPK(pk);
        }
    }
    #endregion
    #region Delete
    public class BaseServiceEFDeleteRequest<TEntity> : BaseStrategyRequest<TEntity> { }
    public class BaseServiceEFDeleteResponse : BaseStrategyResponse { }
    public class BaseServiceEFDeleteStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        : BaseDeleteStrategyEF<BaseServiceEFDeleteRequest<TEntity>, BaseServiceEFDeleteResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFDeleteRequest<TEntity>, BaseServiceEFDeleteResponse>
        where TRepository : class,  IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFDeleteRequest<TEntity>, BaseServiceEFDeleteResponse, bool> OnInvoking { get; set; }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>);
            }
        }
        public BaseServiceEFDeleteStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> service) : base(logger, service)
        {
        }
        protected override bool DoDelete(BaseServiceEFDeleteRequest<TEntity> request, BaseServiceEFDeleteResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoDelete(request, response);
        }
        protected override void DoDelete(TEntity data)
        {
            StrongService.DefaultRepository.Delete(data);
        }
    }
    #endregion
    #region DeleteByPk
    public class BaseServiceEFDeleteByPKRequest<TEntityPK> : BaseStrategyRequest<TEntityPK> { }
    public class BaseServiceEFDeleteByPKResponse : BaseStrategyResponse { }
    public class BaseServiceEFDeleteByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        : BaseDeleteByPKStrategyEF<BaseServiceEFDeleteByPKRequest<TEntityPK>, BaseServiceEFDeleteByPKResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFDeleteByPKRequest<TEntityPK>, BaseServiceEFDeleteByPKResponse>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFDeleteByPKRequest<TEntityPK>, BaseServiceEFDeleteByPKResponse, bool> OnInvoking { get; set; }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>);
            }
        }
        public BaseServiceEFDeleteByPKStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> service) : base(logger, service)
        {
        }
        protected override bool DoDeleteByPK(BaseServiceEFDeleteByPKRequest<TEntityPK> request, BaseServiceEFDeleteByPKResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoDeleteByPK(request, response);
        }
        protected override void DoDeleteByPK(TEntityPK data)
        {
            StrongService.DefaultRepository.DeleteByPK(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
    }
    #endregion
    #region Recover
    public class BaseServiceEFRecoverRequest<TEntity> : BaseStrategyRequest<TEntity> { }
    public class BaseServiceEFRecoverResponse : BaseStrategyResponse { }
    public class BaseServiceEFRecoverStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        : BaseRecoverStrategyEF<BaseServiceEFRecoverRequest<TEntity>, BaseServiceEFRecoverResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFRecoverRequest<TEntity>, BaseServiceEFRecoverResponse>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFRecoverRequest<TEntity>, BaseServiceEFRecoverResponse, bool> OnInvoking { get; set; }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>);
            }
        }
        public BaseServiceEFRecoverStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> service) : base(logger, service)
        {
        }
        protected override bool DoRecover(BaseServiceEFRecoverRequest<TEntity> request, BaseServiceEFRecoverResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoRecover(request, response);
        }
        protected override void DoRecover(TEntity data)
        {
            StrongService.DefaultRepository.Recover(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }
    }
    #endregion
    #region RecoverByPk
    public class BaseServiceEFRecoverByPKRequest<TEntityPK> : BaseStrategyRequest<TEntityPK> { }
    public class BaseServiceEFRecoverByPKResponse : BaseStrategyResponse { }
    public class BaseServiceEFRecoverByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        : BaseRecoverByPKStrategyEF<BaseServiceEFRecoverByPKRequest<TEntityPK>, BaseServiceEFRecoverByPKResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFRecoverByPKRequest<TEntityPK>, BaseServiceEFRecoverByPKResponse>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFRecoverByPKRequest<TEntityPK>, BaseServiceEFRecoverByPKResponse, bool> OnInvoking { get; set; }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK>);
            }
        }
        public BaseServiceEFRecoverByPKStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK> service) : base(logger, service)
        {
        }
        protected override bool DoRecoverByPK(BaseServiceEFRecoverByPKRequest<TEntityPK> request, BaseServiceEFRecoverByPKResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoRecoverByPK(request, response);
        }
        protected override void DoRecoverByPK(TEntityPK data)
        {
            StrongService.DefaultRepository.RecoverByPK(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }

        protected override TEntity GetEntityByPK(TEntityPK pk)
        {
            return StrongService.DefaultRepository.GetByPK(pk);
        }
    }
    #endregion

    public interface IStrategyBasedService<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        TRepository Repository { get; set; }
        BaseServiceEFCreateStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Create { get; }
        BaseServiceEFEditStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Edit { get; }
        BaseServiceEFRemoveStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Remove { get; }
        BaseServiceEFRemoveByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> RemoveByPK { get; }
        BaseServiceEFDeleteStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Delete { get; }
        BaseServiceEFDeleteByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> DeleteByPK { get; }
        BaseServiceEFRecoverStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Recover { get; }
        BaseServiceEFRecoverByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> RecoverByPK { get; }
    }

    public class BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> :
        BaseUserService<TUser, TUserPK>, IStrategyBasedService<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public TRepository Repository { get; set; }
        private IRepository<TEntity, TEntityPK> defaultRepository;
        public IRepository<TEntity, TEntityPK> DefaultRepository
        {
            get
            {
                return Repository ?? defaultRepository;
            }
        }
        public BaseServiceEFCreateStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Create { get; protected set; }
        public BaseServiceEFEditStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Edit { get; protected set; }
        public BaseServiceEFRemoveStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Remove { get; protected set; }
        public BaseServiceEFRemoveByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> RemoveByPK { get; protected set; }
        public BaseServiceEFDeleteStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Delete { get; protected set; }
        public BaseServiceEFDeleteByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> DeleteByPK { get; protected set; }
        public BaseServiceEFRecoverStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> Recover { get; protected set; }
        public BaseServiceEFRecoverByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> RecoverByPK { get; protected set; }
        public BaseStrategyBasedUserServiceEF(IExceptionLogger logger,
                            DbContext context,
                            IUserRepository<TUser, TUserPK> userRepo,
                            TRepository repo) : base(logger, context, userRepo)
        {
            Repository = repo;
            if (repo == null)
            {
                defaultRepository = new BaseRepositoryEF<TEntity, TEntityPK>(context);
            }
            else
            {
                var efRepo = Repository as BaseRepositoryEF;
                if (efRepo != null)
                {
                    efRepo.Context = context;
                }
            }

            InitStrategies(logger);
        }
        protected virtual void InitStrategies(IExceptionLogger logger)
        {
            Create = new BaseServiceEFCreateStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>(logger, this);
            Edit = new BaseServiceEFEditStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>(logger, this);
            Remove = new BaseServiceEFRemoveStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>(logger, this);
            RemoveByPK = new BaseServiceEFRemoveByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>(logger, this);
            Delete = new BaseServiceEFDeleteStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>(logger, this);
            DeleteByPK = new BaseServiceEFDeleteByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>(logger, this);
            Recover = new BaseServiceEFRecoverStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>(logger, this);
            RecoverByPK = new BaseServiceEFRecoverByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>(logger, this);
        }
        protected override void SetContext(DbContext value)
        {
            base.SetContext(value);
            var efRepo = Repository as BaseRepositoryEF;
            if (efRepo != null)
            {
                efRepo.Context = value;
            }
        }
    }

    public interface IBaseServiceStrategyEF<TReq, TRes, TViewModel> : IBaseServiceStrategyEF<TReq, TRes>
        where TReq : BaseStrategyRequest
        where TRes : BaseStrategyResponse, new()
    {
        Func<BaseStrategy<TReq, TRes>, TViewModel, TRes> TryInvoke { get; set; }
    }

    #region Create
    public class BaseServiceEFCreateStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        : BaseCreateStrategyEF<BaseServiceEFCreateRequest<TEntity>, BaseServiceEFCreateResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFCreateRequest<TEntity>, BaseServiceEFCreateResponse, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFCreateRequest<TEntity>, BaseServiceEFCreateResponse, bool> OnInvoking { get; set; }
        public Func<BaseStrategy<BaseServiceEFCreateRequest<TEntity>, BaseServiceEFCreateResponse>, TViewModel, BaseServiceEFCreateResponse> TryInvoke
        {
            get; set;
        }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>);
            }
        }
        public BaseServiceEFCreateStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> service) : base(logger, service)
        {
        }
        protected override bool DoCreate(BaseServiceEFCreateRequest<TEntity> request, BaseServiceEFCreateResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoCreate(request, response);
        }
        protected override void DoCreate(TEntity data)
        {
            StrongService.DefaultRepository.Add(data);
        }
        public BaseServiceEFCreateResponse Invoke(TViewModel viewmodel)
        {
            var request = new BaseServiceEFCreateRequest<TEntity>();

            if (TryInvoke != null)
            {
                var result = TryInvoke(this, viewmodel);

                if (result != null)
                    return result;
            }

            request.Data = AutoMapper.Mapper.Map<TEntity>(viewmodel);

            return Invoke(request);
        }
    }
    #endregion
    #region Edit
    public class BaseServiceEFEditStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        : BaseEditStrategyEF<BaseServiceEFEditRequest<TEntity>, BaseServiceEFEditResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFEditRequest<TEntity>, BaseServiceEFEditResponse, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFEditRequest<TEntity>, BaseServiceEFEditResponse, bool> OnInvoking { get; set; }
        public Func<BaseStrategy<BaseServiceEFEditRequest<TEntity>, BaseServiceEFEditResponse>, TViewModel, BaseServiceEFEditResponse> TryInvoke
        {
            get; set;
        }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>);
            }
        }
        public BaseServiceEFEditStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> service) : base(logger, service)
        {
        }
        protected override bool DoEdit(BaseServiceEFEditRequest<TEntity> request, BaseServiceEFEditResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoEdit(request, response);
        }
        protected override void DoEdit(TEntity data)
        {
            StrongService.DefaultRepository.Update(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }
        public BaseServiceEFEditResponse Invoke(TViewModel viewmodel)
        {
            var request = new BaseServiceEFEditRequest<TEntity>();

            if (TryInvoke != null)
            {
                var result = TryInvoke(this, viewmodel);

                if (result != null)
                    return result;
            }

            request.Data = AutoMapper.Mapper.Map<TEntity>(viewmodel);

            return Invoke(request);
        }
    }
    #endregion
    #region Remove
    public class BaseServiceEFRemoveStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        : BaseRemoveStrategyEF<BaseServiceEFRemoveRequest<TEntity>, BaseServiceEFRemoveResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFRemoveRequest<TEntity>, BaseServiceEFRemoveResponse, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFRemoveRequest<TEntity>, BaseServiceEFRemoveResponse, bool> OnInvoking { get; set; }
        public Func<BaseStrategy<BaseServiceEFRemoveRequest<TEntity>, BaseServiceEFRemoveResponse>, TViewModel, BaseServiceEFRemoveResponse> TryInvoke
        {
            get; set;
        }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>);
            }
        }
        public BaseServiceEFRemoveStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> service) : base(logger, service)
        {
        }
        protected override bool DoRemove(BaseServiceEFRemoveRequest<TEntity> request, BaseServiceEFRemoveResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoRemove(request, response);
        }
        protected override void DoRemove(TEntity data)
        {
            StrongService.DefaultRepository.Remove(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }
        public BaseServiceEFRemoveResponse Invoke(TViewModel viewmodel)
        {
            var request = new BaseServiceEFRemoveRequest<TEntity>();

            if (TryInvoke != null)
            {
                var result = TryInvoke(this, viewmodel);

                if (result != null)
                    return result;
            }

            request.Data = AutoMapper.Mapper.Map<TEntity>(viewmodel);

            return Invoke(request);
        }
    }
    #endregion
    #region RemoveByPk
    public class BaseServiceEFRemoveByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        : BaseRemoveByPKStrategyEF<BaseServiceEFRemoveByPKRequest<TEntityPK>, BaseServiceEFRemoveByPKResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFRemoveByPKRequest<TEntityPK>, BaseServiceEFRemoveByPKResponse, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFRemoveByPKRequest<TEntityPK>, BaseServiceEFRemoveByPKResponse, bool> OnInvoking { get; set; }
        public Func<BaseStrategy<BaseServiceEFRemoveByPKRequest<TEntityPK>, BaseServiceEFRemoveByPKResponse>, TViewModel, BaseServiceEFRemoveByPKResponse> TryInvoke
        {
            get; set;
        }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>);
            }
        }
        public BaseServiceEFRemoveByPKStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> service) : base(logger, service)
        {
        }
        protected override bool DoRemoveByPK(BaseServiceEFRemoveByPKRequest<TEntityPK> request, BaseServiceEFRemoveByPKResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoRemoveByPK(request, response);
        }
        protected override void DoRemoveByPK(TEntityPK data)
        {
            StrongService.DefaultRepository.RemoveByPK(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }

        protected override TEntity GetEntityByPK(TEntityPK pk)
        {
            return StrongService.DefaultRepository.GetByPK(pk);
        }
    }
    #endregion
    #region Delete
    public class BaseServiceEFDeleteStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        : BaseDeleteStrategyEF<BaseServiceEFDeleteRequest<TEntity>, BaseServiceEFDeleteResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFDeleteRequest<TEntity>, BaseServiceEFDeleteResponse, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFDeleteRequest<TEntity>, BaseServiceEFDeleteResponse, bool> OnInvoking { get; set; }
        public Func<BaseStrategy<BaseServiceEFDeleteRequest<TEntity>, BaseServiceEFDeleteResponse>, TViewModel, BaseServiceEFDeleteResponse> TryInvoke
        {
            get; set;
        }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>);
            }
        }
        public BaseServiceEFDeleteStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> service) : base(logger, service)
        {
        }
        protected override bool DoDelete(BaseServiceEFDeleteRequest<TEntity> request, BaseServiceEFDeleteResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoDelete(request, response);
        }
        protected override void DoDelete(TEntity data)
        {
            StrongService.DefaultRepository.Delete(data);
        }
        public BaseServiceEFDeleteResponse Invoke(TViewModel viewmodel)
        {
            var request = new BaseServiceEFDeleteRequest<TEntity>();

            if (TryInvoke != null)
            {
                var result = TryInvoke(this, viewmodel);

                if (result != null)
                    return result;
            }

            request.Data = AutoMapper.Mapper.Map<TEntity>(viewmodel);

            return Invoke(request);
        }
    }
    #endregion
    #region DeleteByPk
    public class BaseServiceEFDeleteByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        : BaseDeleteByPKStrategyEF<BaseServiceEFDeleteByPKRequest<TEntityPK>, BaseServiceEFDeleteByPKResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFDeleteByPKRequest<TEntityPK>, BaseServiceEFDeleteByPKResponse, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFDeleteByPKRequest<TEntityPK>, BaseServiceEFDeleteByPKResponse, bool> OnInvoking { get; set; }
        public Func<BaseStrategy<BaseServiceEFDeleteByPKRequest<TEntityPK>, BaseServiceEFDeleteByPKResponse>, TViewModel, BaseServiceEFDeleteByPKResponse> TryInvoke
        {
            get; set;
        }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>);
            }
        }
        public BaseServiceEFDeleteByPKStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> service) : base(logger, service)
        {
        }
        protected override bool DoDeleteByPK(BaseServiceEFDeleteByPKRequest<TEntityPK> request, BaseServiceEFDeleteByPKResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoDeleteByPK(request, response);
        }
        protected override void DoDeleteByPK(TEntityPK data)
        {
            StrongService.DefaultRepository.DeleteByPK(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
    }
    #endregion
    #region Recover
    public class BaseServiceEFRecoverStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        : BaseRecoverStrategyEF<BaseServiceEFRecoverRequest<TEntity>, BaseServiceEFRecoverResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFRecoverRequest<TEntity>, BaseServiceEFRecoverResponse, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFRecoverRequest<TEntity>, BaseServiceEFRecoverResponse, bool> OnInvoking { get; set; }
        public Func<BaseStrategy<BaseServiceEFRecoverRequest<TEntity>, BaseServiceEFRecoverResponse>, TViewModel, BaseServiceEFRecoverResponse> TryInvoke
        {
            get; set;
        }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>);
            }
        }
        public BaseServiceEFRecoverStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> service) : base(logger, service)
        {
        }
        protected override bool DoRecover(BaseServiceEFRecoverRequest<TEntity> request, BaseServiceEFRecoverResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoRecover(request, response);
        }
        protected override void DoRecover(TEntity data)
        {
            StrongService.DefaultRepository.Recover(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }
        public BaseServiceEFRecoverResponse Invoke(TViewModel viewmodel)
        {
            var request = new BaseServiceEFRecoverRequest<TEntity>();

            if (TryInvoke != null)
            {
                var result = TryInvoke(this, viewmodel);

                if (result != null)
                    return result;
            }

            request.Data = AutoMapper.Mapper.Map<TEntity>(viewmodel);

            return Invoke(request);
        }
    }
    #endregion
    #region RecoverByPk
    public class BaseServiceEFRecoverByPKStrategy<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>
        : BaseRecoverByPKStrategyEF<BaseServiceEFRecoverByPKRequest<TEntityPK>, BaseServiceEFRecoverByPKResponse, TUser, TUserPK, TEntity, TEntityPK, TUserFK>
        , IBaseServiceStrategyEF<BaseServiceEFRecoverByPKRequest<TEntityPK>, BaseServiceEFRecoverByPKResponse, TViewModel>
        where TRepository : class, IRepository<TEntity, TEntityPK>
        where TEntity : EntityBase<TEntityPK, TUser, TUserFK>
        where TUser : IUser<TUserPK>
    {
        public Func<BaseServiceEFRecoverByPKRequest<TEntityPK>, BaseServiceEFRecoverByPKResponse, bool> OnInvoking { get; set; }
        public Func<BaseStrategy<BaseServiceEFRecoverByPKRequest<TEntityPK>, BaseServiceEFRecoverByPKResponse>, TViewModel, BaseServiceEFRecoverByPKResponse> TryInvoke
        {
            get; set;
        }
        public BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> StrongService
        {
            get
            {
                return (Service as BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel>);
            }
        }
        public BaseServiceEFRecoverByPKStrategy(IExceptionLogger logger, BaseStrategyBasedUserServiceEF<TRepository, TUser, TUserPK, TEntity, TEntityPK, TUserFK, TViewModel> service) : base(logger, service)
        {
        }
        protected override bool DoRecoverByPK(BaseServiceEFRecoverByPKRequest<TEntityPK> request, BaseServiceEFRecoverByPKResponse response)
        {
            if (OnInvoking != null)
                return OnInvoking(request, response);
            else
                return base.DoRecoverByPK(request, response);
        }
        protected override void DoRecoverByPK(TEntityPK data)
        {
            StrongService.DefaultRepository.RecoverByPK(data);
        }
        public Func<TUserFK, TUserPK> UserFkToPk
        {
            get; set;
        }
        protected override TUserPK GetUserPK(TUserFK fk)
        {
            if (UserFkToPk != null)
                return UserFkToPk(fk);

            return default(TUserPK);
        }

        protected override TEntity GetEntityByPK(TEntityPK pk)
        {
            return StrongService.DefaultRepository.GetByPK(pk);
        }
    }
    #endregion
}
