using BackEnd.Domain.Entity.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Repositories.Entity;

public static class RepositoriesCollection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookCopyRepository, BookCopyRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IMetaCataloRepository, MetaCataloRepository>();
        services.AddScoped<ICataloRepository, CataloRepository>();
        services.AddScoped<ICheckOutRepository, CheckOutRepository>();
        services.AddScoped<IHoldRepository, HoldRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IWaitingListRepository, WaitingListRepository>();
        // services.AddScoped<IBookAuthorMappingRepository, BookAuthorMappingRepository>();
    }
}