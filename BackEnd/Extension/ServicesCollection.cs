using BackEnd.Base.Service;
using BackEnd.Services;

namespace BackEnd.Extension;

public static class ServicesCollection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        
        return services;
    }
}