using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ShopDemo.Application;

public class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}