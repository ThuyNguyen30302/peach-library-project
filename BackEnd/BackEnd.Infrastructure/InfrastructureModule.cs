using BackEnd.Domain;
using BackEnd.Infrastructure.Data;
using BackEnd.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure;

public class InfrastructureModule
{
    private readonly IConfiguration _configuration;

    public InfrastructureModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("MigrationDbContext");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        services.SetRepositories();
    }
}