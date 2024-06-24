using BackEnd.Domain.Ums.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.EntityConfigurations;

public static class IdentifyConfiguration
{
    public static void ConfigureIdentifyEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(x => x.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");
            entity.HasMany<UserRole>()
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });
        
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");
            entity.HasIndex(r => r.NormalizedName).IsUnique();
            entity.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
            entity.Property(u => u.Name).HasMaxLength(256);
            entity.Property(u => u.NormalizedName).HasMaxLength(256);

            entity.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            entity.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
        });
        
        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable("RoleClaim");
            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.HasOne(x => x.Role)
                .WithMany(x => x.RoleClaims)
                .HasForeignKey(x => x.RoleId);
        });

        modelBuilder.Entity<UserClaim>(entity =>
        {
            entity.ToTable("UserClaim");
            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.ToTable("UserToken");
            entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.ToTable("UserLogin");
            entity.HasKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey });
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");
            entity.HasKey(e => new { e.RoleId, e.UserId });

            entity.HasOne(d => d.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
    }
}