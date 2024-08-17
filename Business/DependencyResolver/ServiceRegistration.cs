using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace Business.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            //IoC-Inversion Of Control-Dependency-leri idare etmek ucundur.Yeni asililiqlari.

            services.AddScoped<AppDbContext>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();
            services.AddScoped<IAuthService,AuthManager>();

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
