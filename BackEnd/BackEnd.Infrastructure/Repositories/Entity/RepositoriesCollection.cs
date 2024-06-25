using BackEnd.Domain.Entity.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Repositories.Entity;

public static class RepositoriesCollection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAuthorRepository, AuthorRepository>();
        services.AddTransient<IBookCopyRepository, BookCopyRepository>();
        services.AddTransient<IPublisherRepository, PublisherRepository>();
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IMemberRepository, MemberRepository>();
        services.AddTransient<IMetaCataloRepository, MetaCataloRepository>();
        services.AddTransient<ICataloRepository, CataloRepository>();
        services.AddTransient<ICheckOutRepository, CheckOutRepository>();
        services.AddTransient<IHoldRepository, HoldRepository>();
        services.AddTransient<INotificationRepository, NotificationRepository>();
        services.AddTransient<IWaitingListRepository, WaitingListRepository>();
        // services.AddTransient<IBookAuthorMappingRepository, BookAuthorMappingRepository>();
    }
}