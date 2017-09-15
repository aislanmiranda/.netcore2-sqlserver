using System.Collections.Generic;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;

namespace Demo.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IEFUnityOfWorker unityOfWork)
            : base(unityOfWork)
        { }

        // public IEnumerable<Category> GetAll(bool @readonly = false)
        // {
        //     var uow = UnityOfWork as UniytOfWork;

        //     var _repository = uow.CreateSet<Category>();

        //     if (@readonly) {
        //     return _repository
        //                      .Include("Endereco")
        //                      .Where(x => x.IdProprietario > 0)
        //                      .AsNoTracking();
        //     }
        //     else
        //     {
        //         return _repository
        //                      .Include("Endereco")
        //                      .Where(x => x.IdProprietario > 0);
        //     }

        // }
    }
}