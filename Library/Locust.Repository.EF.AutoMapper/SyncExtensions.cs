using AutoMapper.QueryableExtensions;
using Locust.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Repository.EF.AutoMapper
{
    public static class SyncExtensions
    {
        private static PageListResult<U> GetPageInternal<T, U>(DbContext Context, int page, int pageSize, Func<IQueryable<T>, IQueryable<T>> predicator, string order) where T : class
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

                return new PageListResult<U>
                {
                    Items = query.Skip((page - 1) * pageSize).Take(pageSize).ProjectTo<U>().ToList(),
                    CurrentPage = page,
                    PageSize = pageSize,
                    PageCount = pageCount,
                    RecordCount = recordCount
                };
            }
            else
            {
                return new PageListResult<U>
                {
                    Items = new List<U>(),
                    CurrentPage = 1,
                    PageSize = pageSize,
                    PageCount = 1,
                    RecordCount = 0
                };
            }
        }
        public static PageListResult<U> GetPage<T, PK, U>(this BaseRepositoryEF<T, PK> repository, int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return GetPageInternal<T,U>(repository.Context, page, pageSize, (query) => query.Where(predicate), order);
        }
        public static PageListResult<U> GetPage<T, PK, U>(this BaseRepositoryEF<T, PK> repository, int page, int pageSize, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return GetPageInternal<T,U>(repository.Context, page, pageSize, (query) => query.Where(predicate), order);
        }
        public static PageListResult<U> GetPage<T, PK, U>(this BaseRepositoryEF<T, PK> repository, int page, int pageSize, string predicate, string order) where T : class
        {
            return GetPageInternal<T,U>(repository.Context, page, pageSize, (query) => string.IsNullOrEmpty(predicate) ? query : query.Where(predicate), order);
        }
        private static List<U> GetRangeInternal<T, U>(DbContext Context, Func<IQueryable<T>, IQueryable<T>> predicator, string order) where T : class
        {
            var query = Context.Set<T>().AsQueryable<T>();

            query = predicator(query);

            if (!string.IsNullOrEmpty(order))
            {
                query = query.OrderBy(order);
            }

            return query.ProjectTo<U>().ToList();
        }
        public static List<U> GetRange<T, PK, U>(this BaseRepositoryEF<T, PK> repository, Expression<Func<T, int, bool>> predicate, string order) where T : class
        {
            return GetRangeInternal<T, U>(repository.Context, (query) => query.Where(predicate), order);
        }
        public static List<U> GetRange<T, PK, U>(this BaseRepositoryEF<T, PK> repository, Expression<Func<T, bool>> predicate, string order) where T : class
        {
            return GetRangeInternal<T, U>(repository.Context, (query) => query.Where(predicate), order);
        }
        public static List<U> GetRange<T, PK, U>(this BaseRepositoryEF<T, PK> repository, string predicate, string order) where T : class
        {
            return GetRangeInternal<T, U>(repository.Context, (query) => string.IsNullOrEmpty(predicate) ? query : query.Where(predicate), order);
        }
    }
}
