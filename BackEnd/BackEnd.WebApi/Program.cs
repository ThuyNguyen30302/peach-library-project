using BackEnd.Application;
using BackEnd.Infrastructure;
using BackEnd.Migrator;
using BackEnd.WebApi;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var infrastructureModule = new InfrastructureModule(builder.Configuration);
var applicationModule = new ApplicationModule();
var webApiModule = new WebApiModule(infrastructureModule, applicationModule, builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MigrationDbContext>((optionsBuilder) =>
{
    var mysqlConnectionString = builder.Configuration.GetConnectionString("MigrationDbContext");
    optionsBuilder.UseMySql(mysqlConnectionString, ServerVersion.AutoDetect(mysqlConnectionString));
});
webApiModule.ConfigureServices(builder.Services);
builder.Services.AddSwaggerGen();
builder.Services.AddMvc()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Converters = new List<JsonConverter>
        {
            new StringEnumConverter()
        };
    });
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization(); 

app.MapControllers();

app.Run();