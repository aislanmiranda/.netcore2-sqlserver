using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Demo.Domain.Contracts
{
    public interface IRepository<T> where T : class
    {
        IUnityOfWork UnityOfWork { get; }

        void Add(T entity);

        T AddGetEntity(T entity);

        void Remove(T entity);

        void Modify(T entity);
        T ModifyGetEntity(T entity);

        void Track(T entity);

        void Merge(T persisted, T current);

        T Get(int id);

        IEnumerable<T> GetAll(bool @readonly = false);

        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter, bool @readonly = false);

        int AddGetId(T entity);
        
    }
}