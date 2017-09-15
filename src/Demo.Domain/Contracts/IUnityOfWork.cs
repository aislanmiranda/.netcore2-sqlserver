using System;
using System.Threading.Tasks;

namespace Demo.Domain.Contracts
{
    public interface IUnityOfWork : IDisposable
    {
        Task Commit();

        void Rollback();
    }
}