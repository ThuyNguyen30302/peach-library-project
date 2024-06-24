using BackEnd.Domain.Ums.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Repositories.Ums;

public static class RepositoriesUmsCollection
{
    public static void AddUmsRepositories(this IServiceCollection services)
    {
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
    }
}