using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Application.Services;

public static class ServiceCollections
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookCopyService, BookCopyService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IMetaCataloService, MetaCataloService>();
        services.AddScoped<ICataloService, CataloService>();
        services.AddScoped<ICheckOutService, CheckOutService>();
        services.AddScoped<IHoldService, HoldService>();
      
        return services;
    }
}