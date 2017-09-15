using System;
using Demo.Domain;
using Demo.Domain.Entities;
using Demo.Domain.Interfaces;

namespace Demo.Application
{
    public class CategoryApp : ICategoryApp
    {   
        private readonly ICategoryRepository _service;

        public CategoryApp(ICategoryRepository service)
        {
            _service = service;
        } 

        public ResponseResult GetAll(bool @readonly = false)
        {
            var list = _service.GetAll(@readonly);

            return new ResponseResult
            {
                result = true,
                message = "sucesso no retorno",
                response = list
            };
        }

        public ResponseResult Get(int? id)
        {

            var viewModel = new Category();

            if (id > 0)
            {
                viewModel = _service.Get(id.Value);
            }            

            return new ResponseResult
            {
                result = true,
                message = "sucesso no retorno",
                response = viewModel
            };
        }

        public ResponseResult CreateOrUpdade(Category entity)
        {
            if (entity == null)
                throw new ArgumentException("Animal");

            dynamic retorno;

            if (entity.Id > 0)
            {
                retorno = _service.ModifyGetEntity(entity);
            }
            else
            {
                retorno = _service.AddGetEntity(entity);
            }

            _service.UnityOfWork.Commit();

            return new ResponseResult
            {
                result = true,
                message = entity.Id > 0 ? "Alterado" : "Cadastrado",
                response = (Category)retorno
            };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
    }
}