using BackEnd.Domain.Entity.Entities;
using BackEnd.Infrastructure.EntityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BackEnd.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;
    public virtual DbSet<Book> Books { get; set; } = null!;
    public virtual DbSet<BookAuthorMapping> BookAuthorMappings { get; set; } = null!;
    public virtual DbSet<BookCopy> BookCopies { get; set; } = null!;
    public virtual DbSet<Catalo> Catalos { get; set; } = null!;
    public virtual DbSet<CheckOut> CheckOuts { get; set; } = null!;
    public virtual DbSet<Hold> Holds { get; set; } = null!;
    public virtual DbSet<Member> Members { get; set; } = null!;
    public virtual DbSet<MetaCatalo> MetaCatalos { get; set; } = null!;
    public virtual DbSet<Notification> Notifications { get; set; } = null!;
    public virtual DbSet<Publisher> Publishers { get; set; } = null!;
    public virtual DbSet<WaitingList> WaitingLists { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Configuration.GetConnectionString("MigrationDbContext");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureBaseEntities();
        modelBuilder.ConfigureCatalioEntities();
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureIdentifyEntities();
    }
}