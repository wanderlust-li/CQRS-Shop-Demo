using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopDemo.Application.Repository.ProductRepository;
using ShopDemo.Infrastructure.DatabaseContext;
using ShopDemo.Infrastructure.Repositories;

namespace ShopDemo.Infrastructure;

public class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ShopDatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("ShopDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}