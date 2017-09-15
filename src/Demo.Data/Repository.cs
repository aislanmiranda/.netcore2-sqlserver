using Demo.Domain;
using System.Linq;
using System.Collections.Generic;
using Demo.Domain.Contracts;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IEFUnityOfWorker _unityOfWork;

        public IUnityOfWork UnityOfWork { get { return _unityOfWork; } }

        public Repository(IEFUnityOfWorker unityOfWork)
        {
            if (unityOfWork == null)
                throw new ArgumentNullException();

            _unityOfWork = unityOfWork;
        }

        public void Add(T entity)
        {
            if (entity != null)
                GetSet().Add(entity);
        }

        public T AddGetEntity(T entity)
        {
            return GetSet().Add(entity) as T;
        }

        public void Remove(T entity)
        {
            if (entity == null) return;
            _unityOfWork.Attach(entity);
            GetSet().Remove(entity);
        }

        public void Modify(T entity)
        {
            if (entity == null) return;
            _unityOfWork.SetModifiedState(entity);
        }

        public T ModifyGetEntity(T entity)
        {
            if (entity == null) return null;
            _unityOfWork.SetModifiedState(entity);

            return entity;
        }

        public void Track(T entity)
        {
            if (entity == null) return;
            _unityOfWork.Attach(entity);
        }

        public void Merge(T persisted, T current)
        {
            _unityOfWork.ApplyCurrentValues(persisted, current);
        }

        public T Get(int id)
        {
            return GetSet().Find(id);
        }

        public IEnumerable<T> GetAll(bool @readonly = false)
        {
            return @readonly ?
                   GetSet().AsNoTracking().ToList()
                 : GetSet().ToList();
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter, bool @readonly = false)
        {
            return @readonly ?
                GetSet().AsNoTracking().Where(filter)
               : GetSet().Where(filter);
        }

        DbSet<T> GetSet()
        {
            return _unityOfWork.CreateSet<T>();
        }

        public int AddGetId(T entity)
        {
            GetSet().Add(entity);
            _unityOfWork.Commit();

            string nameTable = entity.GetType().Name.ToString();

            return (int)entity.GetType().GetProperty("Id" + nameTable).GetValue(entity, null);
        }


    }
}