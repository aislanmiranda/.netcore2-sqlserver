using System.Linq;
using System.Threading.Tasks;
using Demo.Data.Mapping;
using Demo.Domain;
using Demo.Domain.Contracts;
using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class UniytOfWork : DbContext, IEFUnityOfWorker
    {
        public UniytOfWork(DbContextOptions<UniytOfWork> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        void IEFUnityOfWorker.ApplyCurrentValues<T>(T original, T current)
        {
             Entry(original).CurrentValues.SetValues(current);
        }

        void IEFUnityOfWorker.Attach<T>(T entity)
        {
            Entry(entity).State = EntityState.Unchanged;
        }

        Task IUnityOfWork.Commit()
        {
            return base.SaveChangesAsync();
        }

        DbSet<T> IEFUnityOfWorker.CreateSet<T>()
        {
            return Set<T>();
        }

        void IUnityOfWork.Rollback()
        {
            ChangeTracker.Entries()
                .ToList()
                .ForEach(e => e.State = EntityState.Unchanged);
        }

        void IEFUnityOfWorker.SetModifiedState<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}