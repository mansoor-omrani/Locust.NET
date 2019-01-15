using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Repository
{
    public interface IAsyncRepository<T, PK>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetRangeAsync(Expression<Func<T, int, bool>> predicate, string order);
        Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> predicate, string order);
        Task<List<T>> GetRangeAsync(string predicate, string order);
        Task<PageListResult<T>> GetPageAsync(int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order);
        Task<PageListResult<T>> GetPageAsync(int page, int pageSize, Expression<Func<T, bool>> predicate, string order);
        Task<PageListResult<T>> GetPageAsync(int page, int pageSize, string predicate, string order);
        Task<T> FindAsync(PK id);
        Task<T> GetByPKAsync(PK id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteByPKAsync(PK id);
        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveByPKAsync(PK id);
        Task<bool> RecoverAsync(T entity);
        Task<bool> RecoverByPKAsync(PK id);
        Task RemoveRangeAsync(string predicate);
        Task RemoveRangeAsync(Expression<Func<T, bool>> predicate);
        Task RemoveRangeAsync(Expression<Func<T, int, bool>> predicate);
        Task DeleteRangeAsync(string predicate);
        Task DeleteRangeAsync(Expression<Func<T, bool>> predicate);
        Task DeleteRangeAsync(Expression<Func<T, int, bool>> predicate);
        Task RecoverRangeAsync(string predicate);
        Task RecoverRangeAsync(Expression<Func<T, bool>> predicate);
        Task RecoverRangeAsync(Expression<Func<T, int, bool>> predicate);
        Task UpdateAsync(T entity);
        Task<int> UpdateRangeAsync(string predicate, Expression<Func<T, T>> updateFactory);
        Task<int> UpdateRangeAsync(string predicate, Expression<Func<T, T>> updateFactory, CancellationToken cancellationToken);
        Task<int> UpdateRangeAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateFactory);
        Task<int> UpdateRangeAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateFactory, CancellationToken cancellationToken);
        Task<int> UpdateRangeAsync(Expression<Func<T, int, bool>> predicate, Expression<Func<T, T>> updateFactory);
        Task<int> UpdateRangeAsync(Expression<Func<T, int, bool>> predicate, Expression<Func<T, T>> updateFactory, CancellationToken cancellationToken);
        Task SaveAsync();
        Task AutoSaveAsync();
    }
}
