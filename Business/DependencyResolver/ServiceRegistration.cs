using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            //IoC-Inversion Of Control-Dependency-leri idare etmek ucundur.Yeni asililiqlari.

            services.AddSingleton<AppDbContext>();
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryDAL, EFCategoryDAL>();
        }
    }
}
