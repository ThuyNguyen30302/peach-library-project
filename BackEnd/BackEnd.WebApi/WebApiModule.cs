using BackEnd.Application;
using BackEnd.Infrastructure;
using BackEnd.Migrator;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.WebApi;

public class WebApiModule
{
    private readonly ApplicationModule _applicationModule;
    private readonly InfrastructureModule _infrastructureModule;
    private readonly IConfiguration _configuration;

    public WebApiModule(InfrastructureModule infrastructureModule, ApplicationModule applicationModule,
        IConfiguration configuration)
    {
        _applicationModule = applicationModule;
        _configuration = configuration;
        _infrastructureModule = infrastructureModule;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        _infrastructureModule.ConfigureServices(services);
        _applicationModule.ConfigureServices(services);
        // var connectionString = _configuration.GetConnectionString("MigrationDbContext");
        // services.AddDbContext<MigrationDbContext>(options =>
        //     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        //
    }
}