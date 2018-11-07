using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Repository.EF
{
    public static class Extensions
    {
        public static PK Key<TSource, PK>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate) where TSource : IEntity<PK> where PK : struct
        {
            var arg = Expression.Parameter(typeof(TSource), "x");
            var p = Expression.Property(arg, "Id");
            var expr = Expression.Convert(p, typeof(PK));
            var e = Expression.Lambda<Func<TSource, PK>>(expr, arg);

            return source.Where(predicate).Select(e).FirstOrDefault();
        }
        public static PK Key<TSource, PK>(this IEnumerable<TSource> source, Expression<Func<TSource, bool>> predicate) where TSource : IEntity<PK> where PK : struct
        {
            return source.AsQueryable().Key<TSource, PK>(predicate);
        }
    }
}
