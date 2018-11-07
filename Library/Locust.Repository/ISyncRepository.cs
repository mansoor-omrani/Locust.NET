using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Repository
{
    public interface ISyncRepository<T, PK>
    {
        List<T> GetAll();
        List<T> GetRange(Expression<Func<T, int, bool>> predicate, string order);
        List<T> GetRange(Expression<Func<T, bool>> predicate, string order);
        List<T> GetRange(string predicate, string order);
        PageListResult<T> GetPage(int page, int pageSize, Expression<Func<T, int, bool>> predicate, string order);
        PageListResult<T> GetPage(int page, int pageSize, Expression<Func<T, bool>> predicate, string order);
        PageListResult<T> GetPage(int page, int pageSize, string predicate, string order);
        T Find(PK id);
        T GetByPK(PK id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void DeleteByPK(PK id);
        bool Remove(T entity);
        bool RemoveByPK(PK id);
        void RemoveRange(string predicate);
        void RemoveRange(Expression<Func<T, bool>> predicate);
        void RemoveRange(Expression<Func<T, int, bool>> predicate);
        void DeleteRange(string predicate);
        void DeleteRange(Expression<Func<T, bool>> predicate);
        void DeleteRange(Expression<Func<T, int, bool>> predicate);
        void RecoverRange(string predicate);
        void RecoverRange(Expression<Func<T, bool>> predicate);
        void RecoverRange(Expression<Func<T, int, bool>> predicate);
        bool Recover(T entity);
        bool RecoverByPK(PK id);
        void Update(T entity);
        int UpdateRange(string predicate, Expression<Func<T, T>> updateFactory);
        int UpdateRange(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateFactory);
        int UpdateRange(Expression<Func<T, int, bool>> predicate, Expression<Func<T, T>> updateFactory);
        void Save();
        void Attach(T entity);
        void Detach(T entity);
    }
}
