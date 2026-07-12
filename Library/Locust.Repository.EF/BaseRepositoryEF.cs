using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Locust.Repository.EF
{
    public interface IRepositoryEF: IRepository
    {
        DbContext Context { get; set; }
    }
    public interface IRepositoryEF<T, PK> : IRepositoryEF, IRepository<T, PK> where T : class
    {
    }
    public class BaseRepositoryEF: IRepositoryEF
    {
        public DbContext Context { get; set; }
        public virtual bool AutoSaveChanges
        {
            get; set;
        }
        public BaseRepositoryEF(DbContext context)
        {
            Context = context;
        }
    }
    public class BaseRepositoryEF<T, PK> : BaseRepositoryEF, IRepositoryEF<T, PK> where T : class
    {
        public BaseRepositoryEF(DbContext context):base(context)
        { }
        
        #region CRUD (sync)
        public virtual void Add(T entity)
        {
            //Context.Set<T>().Attach(entity);
            Context.Set<T>().Add(entity);
            //Context.Entry<T>(entity).State = EntityState.Added;

            AutoSave();
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);

            AutoSave();
        }

        public virtual void DeleteByPK(PK id)
        {
            var entity = Context.Set<T>().Find(id);

            Delete(entity);
        }
        private Expression<Func<T, T>> UpdateIsDeleted(bool value)
        {
            var createdType = typeof(T);
            var arg = Expression.Parameter(typeof(T), "x");
            var isDeleted = Expression.Constant(value);
            var ctor = Expression.New(createdType);
            var isDeletedProperty = createdType.GetProperty("IsDeleted");
            var assign = Expression.Bind(isDeletedProperty, isDeleted);
            var memberInit = Expression.MemberInit(ctor, assign);

            return Expression.Lambda<Func<T, T>>(memberInit, arg);
        }
        public virtual void DeleteRange(string predicate)
        {
            Context.Set<T>().Where(predicate).Delete();
        }
        public virtual void DeleteRange(Expression<Func<T, bool>> predicate)
        {
            Context.Set<T>().Where(predicate).Delete();
        }
        public virtual void DeleteRange(Expression<Func<T, int, bool>> predicate)
        {
            Context.Set<T>().Where(predicate).Delete();
        }
        public virtual void RemoveRange(string predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                Context.Set<T>().Where(predicate).Update(UpdateIsDeleted(true));

                AutoSave();
            }
        }
        public virtual void RemoveRange(Expression<Func<T, bool>> predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                Context.Set<T>().Where(predicate).Update(UpdateIsDeleted(true));

                AutoSave();
            }
        }
        public virtual void RemoveRange(Expression<Func<T, int, bool>> predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                Context.Set<T>().Where(predicate).Update(UpdateIsDeleted(true));

                AutoSave();
            }
        }
        public virtual void RecoverRange(string predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                Context.Set<T>().Where(predicate).Update(UpdateIsDeleted(false));

                AutoSave();
            }
        }
        public virtual void RecoverRange(Expression<Func<T, bool>> predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                Context.Set<T>().Where(predicate).Update(UpdateIsDeleted(false));

                AutoSave();
            }
        }
        public virtual void RecoverRange(Expression<Func<T, int, bool>> predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                Context.Set<T>().Where(predicate).Update(UpdateIsDeleted(false));

                AutoSave();
            }
        }
        public virtual bool Remove(T entity)
        {
            var recoverableEntity = entity as IRecoverableEntity;

            if (recoverableEntity != null)
            {
                recoverableEntity.IsDeleted = true;
                Update(entity);

                AutoSave();

                return true;
            }

            return false;
        }

        public virtual bool RemoveByPK(PK id)
        {
            var entity = Context.Set<T>().Find(id);

            return Remove(entity);
        }

        public virtual bool Recover(T entity)
        {
            var recoverableEntity = entity as IRecoverableEntity;

            if (recoverableEntity != null)
            {
                recoverableEntity.IsDeleted = false;
                Update(entity);

                AutoSave();

                return true;
            }

            return false;
        }

        public virtual bool RecoverByPK(PK id)
        {
            var entity = Context.Set<T>().Find(id);

            return Recover(entity);
        }
        public virtual void Update(T entity)
        {
            if (Context.Entry<T>(entity).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }

            Context.Entry<T>(entity).State = EntityState.Modified;

            AutoSave();
        }
        public int UpdateRange(string predicate, Expression<Func<T, T>> updateFactory)
        {
            return Context.Set<T>().Where(predicate).Update(updateFactory);
        }
        public int UpdateRange(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateFactory)
        {
            return Context.Set<T>().Where(predicate).Update(updateFactory);
        }
        public int UpdateRange(Expression<Func<T, int, bool>> predicate, Expression<Func<T, T>> updateFactory)
        {
            return Context.Set<T>().Where(predicate).Update(updateFactory);
        }
        public virtual void AutoSave()
        {
            if (AutoSaveChanges)
            {
                Save();
            }
        }
        public virtual void Save()
        {
            Context.SaveChanges();
        }
        #endregion
        #region CRUD (async)
        public async virtual Task AddAsync(T entity)
        {
            //Context.Set<T>().Attach(entity);
            Context.Set<T>().Add(entity);
            //Context.Entry<T>(entity).State = EntityState.Added;

            await AutoSaveAsync();
        }

        public async virtual Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);

            await AutoSaveAsync();
        }

        public async virtual Task DeleteByPKAsync(PK id)
        {
            var entity = await Context.Set<T>().FindAsync(id);

            await DeleteAsync(entity);
        }
        public async virtual Task<bool> RemoveAsync(T entity)
        {
            var recoverableEntity = entity as IRecoverableEntity;

            if (recoverableEntity != null)
            {
                recoverableEntity.IsDeleted = true;
                await UpdateAsync(entity);
                await AutoSaveAsync();

                return true;
            }

            return false;
        }

        public async virtual Task<bool> RemoveByPKAsync(PK id)
        {
            var entity = await Context.Set<T>().FindAsync(id);

            return await RemoveAsync(entity);
        }
        public virtual async Task<bool> RecoverAsync(T entity)
        {
            var recoverableEntity = entity as IRecoverableEntity;

            if (recoverableEntity != null)
            {
                recoverableEntity.IsDeleted = false;
                await UpdateAsync(entity);
                await AutoSaveAsync();

                return true;
            }

            return false;
        }

        public virtual Task<bool> RecoverByPKAsync(PK id)
        {
            var entity = Context.Set<T>().Find(id);

            return RecoverAsync(entity);
        }
        public virtual Task DeleteRangeAsync(string predicate)
        {
            return Context.Set<T>().Where(predicate).DeleteAsync();
        }
        public virtual Task DeleteRangeAsync(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).DeleteAsync();
        }
        public virtual Task DeleteRangeAsync(Expression<Func<T, int, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).DeleteAsync();
        }
        public virtual async Task RemoveRangeAsync(string predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                await Context.Set<T>().Where(predicate).UpdateAsync(UpdateIsDeleted(true));

                await AutoSaveAsync();
            }
        }
        public virtual async Task RemoveRangeAsync(Expression<Func<T, bool>> predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                await Context.Set<T>().Where(predicate).UpdateAsync(UpdateIsDeleted(true));

                await AutoSaveAsync();
            }
        }
        public virtual async Task RemoveRangeAsync(Expression<Func<T, int, bool>> predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                await Context.Set<T>().Where(predicate).UpdateAsync(UpdateIsDeleted(true));

                await AutoSaveAsync();
            }
        }
        public virtual async Task RecoverRangeAsync(string predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                await Context.Set<T>().Where(predicate).UpdateAsync(UpdateIsDeleted(false));

                await AutoSaveAsync();
            }
        }
        public virtual async Task RecoverRangeAsync(Expression<Func<T, bool>> predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                await Context.Set<T>().Where(predicate).UpdateAsync(UpdateIsDeleted(false));

                await AutoSaveAsync();
            }
        }
        public virtual async Task RecoverRangeAsync(Expression<Func<T, int, bool>> predicate)
        {
            if (typeof(T).GetInterface(typeof(IRecoverableEntity).Name) != null)
            {
                await Context.Set<T>().Where(predicate).UpdateAsync(UpdateIsDeleted(false));

                await AutoSaveAsync();
            }
        }
        public async virtual Task UpdateAsync(T entity)
        {
            if (Context.Entry<T>(entity).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }

            Context.Entry<T>(entity).State = EntityState.Modified;

            await AutoSaveAsync();
        }
        public Task<int> UpdateRangeAsync(string predicate, Expression<Func<T, T>> updateFactory)
        {
            return UpdateRangeAsync(predicate, updateFactory, CancellationToken.None);
        }
        public Task<int> UpdateRangeAsync(string predicate, Expression<Func<T, T>> updateFactory, CancellationToken token)
        {
            return Context.Set<T>().Where(predicate).UpdateAsync(updateFactory);
        }
        public Task<int> UpdateRangeAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateFactory)
        {
            return UpdateRangeAsync(predicate, updateFactory, CancellationToken.None);
        }
        public Task<int> UpdateRangeAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateFactory, CancellationToken token)
        {
            return Context.Set<T>().Where(predicate).UpdateAsync(updateFactory);
        }
        public Task<int> UpdateRangeAsync(Expression<Func<T, int, bool>> predicate, Expression<Func<T, T>> updateFactory)
        {
            return UpdateRangeAsync(predicate, updateFactory, CancellationToken.None);
        }
        public Task<int> UpdateRangeAsync(Expression<Func<T, int, bool>> predicate, Expression<Func<T, T>> updateFactory, CancellationToken token)
        {
            return Context.Set<T>().Where(predicate).UpdateAsync(updateFactory);
        }
        public async virtual Task AutoSaveAsync()
        {
            if (AutoSaveChanges)
            {
                await AutoSaveAsync();
            }
        }
        public async virtual Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
        #endregion
        #region Data Retrieval (sync)
        public virtual List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public virtual T GetByPK(PK id)
        {
            return Find(id);
        }
        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }
        public virtual T Find(PK id)
        {
            return Context.Set<T>().Find(id);
        }
        private PageListResult<T> GetPageInternal(int page, int pageSize, Func<IQueryable<T>, IQueryable<T>> predicator, string order)
        {
            var query = Context.Set<T>().AsQueryable<T>();

            query = predicator(query);

            if (!string.IsNullOrEmpty(order))
            {
                query = query.OrderBy(order);
            }

            var recordCount = query.Count();

            if (recordCount > 0)
            {
                if (pageSize < 0)
                    pageSize = Math.Abs(pageSize);
                if (pageSize == 0)
                    pageSize = 10;

                var pageCount = (int)Math.Ceiling(recordCount / (pageSize * 1.0));

                if (page <= 0)
                    page = 1;

                if (page > pageCount)
                    page = pageCount;

                query = query.Skip((page - 1) * pageSize).Take(pageSize);

                return new PageListResult<T>
                {
                    Items = query.ToList(),
                    Page = page,
                    PageSize = pageSize,
                    PageCount = pageCount,
                    RecordCount = recordCount
                };
            }
            else
            {
                return new PageListResult<T>
                {
                    Items = new List<T>(),
                    Page = 1,
                    PageSize = pageSize,
                    PageCount = 1,
                    RecordCount = 0
                };
            }
        }
        public virtual PageListResult<T> GetPage(int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order)
        {
            return GetPageInternal(page, pageSize, (query) => query.Where(predicate), order);
        }
        public virtual PageListResult<T> GetPage(int page, int pageSize, Expression<Func<T, bool>> predicate, string order)
        {
            return GetPageInternal(page, pageSize, (query) => query.Where(predicate), order);
        }
        public virtual PageListResult<T> GetPage(int page, int pageSize, string predicate, string order)
        {
            return GetPageInternal(page, pageSize, (query) => string.IsNullOrEmpty(predicate)? query: query.Where(predicate), order);
        }
        private List<T> GetRangeInternal(Func<IQueryable<T>, IQueryable<T>> predicator, string order)
        {
            var query = Context.Set<T>().AsQueryable<T>();

            query = predicator(query);

            if (!string.IsNullOrEmpty(order))
            {
                query = query.OrderBy(order);
            }

            return query.ToList();
        }
        public virtual List<T> GetRange(Expression<Func<T, int, bool>> predicate, string order)
        {
            return GetRangeInternal((query) => query.Where(predicate), order);
        }
        public virtual List<T> GetRange(Expression<Func<T, bool>> predicate, string order)
        {
            return GetRangeInternal((query) => query.Where(predicate), order);
        }
        public virtual List<T> GetRange(string predicate, string order)
        {
            return GetRangeInternal((query) => string.IsNullOrEmpty(predicate)? query: query.Where(predicate), order);
        }
        public virtual void Attach(T entity)
        {
            Context.Set<T>().Attach(entity);
        }
        public virtual void Detach(T entity)
        {
            var e = Context.Entry<T>(entity);

            if (e != null)
            {
                e.State = EntityState.Detached;
            }
        }
        #endregion
        #region Data Retrieval (async)
        public virtual Task<List<T>> GetAllAsync()
        {
            return Context.Set<T>().ToListAsync();
        }

        public virtual Task<T> GetByPKAsync(PK id)
        {
            return FindAsync(id);
        }
        public virtual Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public virtual Task<T> FindAsync(PK id)
        {
            return Context.Set<T>().FindAsync(id);
        }
        private async Task<PageListResult<T>> GetPageInternalAsync(int page, int pageSize, Func<IQueryable<T>, IQueryable<T>> predicator, string order)
        {
            var query = Context.Set<T>().AsQueryable<T>();

            query = predicator(query);

            if (!string.IsNullOrEmpty(order))
            {
                query = query.OrderBy(order);
            }

            var recordCount = query.Count();

            if (pageSize < 0)
                pageSize = Math.Abs(pageSize);
            if (pageSize == 0)
                pageSize = 10;

            var pageCount = (int)Math.Ceiling(recordCount / (pageSize * 1.0));

            if (page <= 0)
                page = 1;

            if (page > pageCount)
                page = pageCount;

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var result = new PageListResult<T>
            {
                Page = page,
                PageSize = pageSize,
                PageCount = pageCount,
                RecordCount = recordCount
            };

            result.Items = await query.ToListAsync();

            return result;
        }
        public virtual Task<PageListResult<T>> GetPageAsync(int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order)
        {
            return GetPageInternalAsync(page, pageSize, (query) => query.Where(predicate), order);
        }
        public virtual Task<PageListResult<T>> GetPageAsync(int page, int pageSize, Expression<Func<T, bool>> predicate, string order)
        {
            return GetPageInternalAsync(page, pageSize, (query) => query.Where(predicate), order);
        }
        public virtual Task<PageListResult<T>> GetPageAsync(int page, int pageSize, string predicate, string order)
        {
            return GetPageInternalAsync(page, pageSize, (query) => string.IsNullOrEmpty(predicate)? query : query.Where(predicate), order);
        }

        private Task<List<T>> GetRangeInternalAsync(Func<IQueryable<T>, IQueryable<T>> predicator, string order)
        {
            var query = Context.Set<T>().AsQueryable<T>();

            query = predicator(query);

            if (!string.IsNullOrEmpty(order))
            {
                query = query.OrderBy(order);
            }

            return query.ToListAsync();
        }
        public virtual Task<List<T>> GetRangeAsync(Expression<Func<T, int, bool>> predicate, string order)
        {
            return GetRangeInternalAsync((query) => query.Where(predicate), order);
        }
        public virtual Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> predicate, string order)
        {
            return GetRangeInternalAsync((query) => query.Where(predicate), order);
        }
        public virtual Task<List<T>> GetRangeAsync(string predicate, string order)
        {
            return GetRangeInternalAsync((query) => string.IsNullOrEmpty(predicate)? query: query.Where(predicate), order);
        }
        #endregion
    }
}
