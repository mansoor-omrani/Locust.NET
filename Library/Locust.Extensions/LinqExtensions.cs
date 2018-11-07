using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class LinqExtensions
    {
        public static TResult Prop<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, Expression<Func<TSource, TResult>> selector)
        {
            return source.Where(predicate).Select(selector).FirstOrDefault();
        }
        public static TResult Prop<TSource, TResult>(this IEnumerable<TSource> source, Expression<Func<TSource, bool>> predicate, Expression<Func<TSource, TResult>> selector)
        {
            return source.AsQueryable().Where(predicate).Select(selector).FirstOrDefault();
        }
    }
}
