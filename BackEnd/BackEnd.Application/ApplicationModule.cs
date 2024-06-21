using BackEnd.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Application;

public class ApplicationModule
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddServices();
    }
    
    public static IServiceCollection AddApplication(IServiceCollection services)
    {
        services.AddServices();
        return services;
    }
}
