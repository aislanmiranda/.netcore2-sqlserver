
using Demo.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public interface IEFUnityOfWorker : IUnityOfWork
    {
        DbSet<T> CreateSet<T>() where T : class;

        void Attach<T>(T entity) where T : class;

        void SetModifiedState<T>(T entity) where T : class;

        void ApplyCurrentValues<T>(T original, T current) where T : class;
    }
}