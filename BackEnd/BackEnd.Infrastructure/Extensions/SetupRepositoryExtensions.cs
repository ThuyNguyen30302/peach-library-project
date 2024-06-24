using BackEnd.Domain.Base.Uow;
using BackEnd.Infrastructure.Base.Uow;
using BackEnd.Infrastructure.Repositories;
using BackEnd.Infrastructure.Repositories.Entity;
using BackEnd.Infrastructure.Repositories.Ums;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Extensions;

public static class SetupRepositoryExtensions
{
    public static IServiceCollection SetRepositories(this IServiceCollection serviceCollection)
    {
        #region Repositories

        serviceCollection.AddRepositories();
        serviceCollection.AddUmsRepositories();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        
        #endregion

        return serviceCollection;
    }  
}