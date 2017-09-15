using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Demo.Data;
using Demo.Domain;
using Demo.Domain.Entities;
using Demo.Domain.Contracts;
using Demo.Domain.Interfaces;
using Demo.Data.Repository;
using Demo.Application;

namespace Demo.IoC
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<UniytOfWork>(options => options.UseSqlServer(connection));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IUnityOfWork), typeof(UniytOfWork));
            services.AddTransient(typeof(IEFUnityOfWorker), typeof(UniytOfWork));

            services.AddTransient(typeof(ICategoryApp), typeof(CategoryApp));
            services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
            
        }
    }
}
