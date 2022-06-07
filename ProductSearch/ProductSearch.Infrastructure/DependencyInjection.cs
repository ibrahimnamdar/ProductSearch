using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductSearch.Infrastructure.Repositories;
using ProductSearch.Infrastructure.UnitOfWork;

namespace ProductSearch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<ProductSearchDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ProductSearchDb")));

            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}