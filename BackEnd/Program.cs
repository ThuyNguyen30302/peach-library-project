using BackEnd.Extension;
using BackEnd.Repositories;
using BackEnd.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MigrationDbContext>((optionsBuilder) =>
{
    var mysqlConnectionString = builder.Configuration.GetConnectionString("MigrationDbContext");
    optionsBuilder.UseMySql(mysqlConnectionString, ServerVersion.AutoDetect(mysqlConnectionString));
});

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// builder.Services.AddRepositories();
// builder.Services.AddServices();
var container = new WindsorContainer();

container.Register(
    Component.For<IBookRepository>().ImplementedBy<BookRepository>().LifestyleTransient(),
    Component.For<IBookService>().ImplementedBy<BookService>().LifestyleTransient()
);

// builder.Services.AddScoped<IBookRepository, BookRepository>();
// builder.Services.AddScoped<IBookService, BookService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization(); 

app.MapControllers();

app.Run();