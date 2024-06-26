﻿using Microsoft.EntityFrameworkCore;

namespace BackEnd.Migrator;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MigrationDbContext>((optionsBuilder) =>
        {
            var mysqlConnectionString = Configuration.GetConnectionString("MigrationDbContext");
            optionsBuilder.UseMySql(mysqlConnectionString, ServerVersion.AutoDetect(mysqlConnectionString));
        });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}