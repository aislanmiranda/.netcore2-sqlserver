using Demo.Domain.Entities;

namespace Demo.Application
{
    public interface ICategoryApp
    {
        ResponseResult CreateOrUpdade(Category entity);
        ResponseResult Get(int? id);
        ResponseResult GetAll(bool @readonly = false);
        void Dispose();
    }
}