using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Repository.EF.AutoMapper
{
    public static class Level2Extensions
    {
        #region GetPage
        #region PK = int
        public static PageListResult<U> GetPage<T, U>(this BaseRepositoryEF<T, int> repository, int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return repository.GetPage<T, int, U>(page, pageSize, predicate, order);
        }
        public static PageListResult<U> GetPage<T, U>(this BaseRepositoryEF<T, int> repository, int page, int pageSize, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return repository.GetPage<T, int, U>(page, pageSize, predicate, order);
        }
        public static PageListResult<U> GetPage<T, U>(this BaseRepositoryEF<T, int> repository, int page, int pageSize, string predicate, string order) where T : class
        {
            return repository.GetPage<T, int, U>(page, pageSize, predicate, order);
        }
        public static Task<PageListResult<U>> GetPageAsync<T, U>(this BaseRepositoryEF<T, int> repository, int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return repository.GetPageAsync<T, int, U>(page, pageSize, predicate, order);
        }
        public static Task<PageListResult<U>> GetPageAsync<T, U>(this BaseRepositoryEF<T, int> repository, int page, int pageSize, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return repository.GetPageAsync<T, int, U>(page, pageSize, predicate, order);
        }
        public static Task<PageListResult<U>> GetPageAsync<T, U>(this BaseRepositoryEF<T, int> repository, int page, int pageSize, string predicate, string order) where T : class
        {
            return repository.GetPageAsync<T, int, U>(page, pageSize, predicate, order);
        }
        #endregion
        #region PK = string
        public static PageListResult<U> GetPage<T, U>(this BaseRepositoryEF<T, string> repository, int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return repository.GetPage<T, string, U>(page, pageSize, predicate, order);
        }
        public static PageListResult<U> GetPage<T, U>(this BaseRepositoryEF<T, string> repository, int page, int pageSize, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return repository.GetPage<T, string, U>(page, pageSize, predicate, order);
        }
        public static PageListResult<U> GetPage<T, U>(this BaseRepositoryEF<T, string> repository, int page, int pageSize, string predicate, string order) where T : class
        {
            return repository.GetPage<T, string, U>(page, pageSize, predicate, order);
        }
        public static Task<PageListResult<U>> GetPageAsync<T, U>(this BaseRepositoryEF<T, string> repository, int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return repository.GetPageAsync<T, string, U>(page, pageSize, predicate, order);
        }
        public static Task<PageListResult<U>> GetPageAsync<T, U>(this BaseRepositoryEF<T, string> repository, int page, int pageSize, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return repository.GetPageAsync<T, string, U>(page, pageSize, predicate, order);
        }
        public static Task<PageListResult<U>> GetPageAsync<T, U>(this BaseRepositoryEF<T, string> repository, int page, int pageSize, string predicate, string order) where T : class
        {
            return repository.GetPageAsync<T, string, U>(page, pageSize, predicate, order);
        }
        #endregion
        #endregion
        #region GetRange
        #region PK = int
        public static List<U> GetRange<T, U>(this BaseRepositoryEF<T, int> repository, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return repository.GetRange<T, int, U>(predicate, order);
        }
        public static List<U> GetRange<T, U>(this BaseRepositoryEF<T, int> repository, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return repository.GetRange<T, int, U>(predicate, order);
        }
        public static List<U> GetRange<T, U>(this BaseRepositoryEF<T, int> repository, string predicate, string order) where T : class
        {
            return repository.GetRange<T, int, U>(predicate, order);
        }
        public static Task<List<U>> GetRangeAsync<T, U>(this BaseRepositoryEF<T, int> repository, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return repository.GetRangeAsync<T, int, U>(predicate, order);
        }
        public static Task<List<U>> GetRangeAsync<T, U>(this BaseRepositoryEF<T, int> repository, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return repository.GetRangeAsync<T, int, U>(predicate, order);
        }
        public static Task<List<U>> GetRangeAsync<T, U>(this BaseRepositoryEF<T, int> repository, string predicate, string order) where T : class
        {
            return repository.GetRangeAsync<T, int, U>(predicate, order);
        }
        #endregion
        #region PK = string
        public static List<U> GetRange<T, U>(this BaseRepositoryEF<T, string> repository, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return repository.GetRange<T, string, U>(predicate, order);
        }
        public static List<U> GetRange<T, U>(this BaseRepositoryEF<T, string> repository, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return repository.GetRange<T, string, U>(predicate, order);
        }
        public static List<U> GetRange<T, U>(this BaseRepositoryEF<T, string> repository, string predicate, string order) where T : class
        {
            return repository.GetRange<T, string, U>(predicate, order);
        }
        public static Task<List<U>> GetRangeAsync<T, U>(this BaseRepositoryEF<T, string> repository, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return repository.GetRangeAsync<T, string, U>(predicate, order);
        }
        public static Task<List<U>> GetRangeAsync<T, U>(this BaseRepositoryEF<T, string> repository, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return repository.GetRangeAsync<T, string, U>(predicate, order);
        }
        public static Task<List<U>> GetRangeAsync<T, U>(this BaseRepositoryEF<T, string> repository, string predicate, string order) where T : class
        {
            return repository.GetRangeAsync<T, string, U>(predicate, order);
        }
        #endregion
        #endregion
    }
}
