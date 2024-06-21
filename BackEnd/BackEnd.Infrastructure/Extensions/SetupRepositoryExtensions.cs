using BackEnd.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Extensions;

public static class SetupRepositoryExtensions
{
    public static IServiceCollection SetRepositories(this IServiceCollection serviceCollection)
    {
        #region Repositories

        serviceCollection.AddRepositories();
        
        #endregion

        return serviceCollection;
    }  
}