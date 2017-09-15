using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.Domain.Dtos;
using Demo.Domain.Interfaces;
using Demo.Domain.Entities;
using Demo.Application;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryApp _storer;

        public CategoryController(ICategoryApp storer)
        {
            _storer = storer;
        }        
        
        [HttpGet]
        [Route("GetId/{id}")]
        public ResponseResult Get(int? id)
        {
            return _storer.Get(id.Value);
        }

        [HttpGet]
        [Route("GetAll")]
        public ResponseResult GetAll()
        {
            return _storer.GetAll(true);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Category dto)
        {
            return Json(_storer.CreateOrUpdade(dto));
        }

    }
}
