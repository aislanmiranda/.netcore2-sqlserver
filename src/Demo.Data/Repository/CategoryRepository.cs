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

    }
}