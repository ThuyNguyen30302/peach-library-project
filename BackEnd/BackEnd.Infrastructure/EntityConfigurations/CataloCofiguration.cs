using BackEnd.Domain.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.EntityConfigurations;

public static class CataloCofiguration
{
    public static void ConfigureCatalioEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MetaCatalo>(entity =>
        {
            entity.ToTable("MetaCatalo");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.Code).HasMaxLength(255);

            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");

            entity.Property(e => e.Description).HasMaxLength(255);

            entity.Property(e => e.Name).HasMaxLength(255);
        });
        
        modelBuilder.Entity<Catalo>(entity =>
        {
            entity.ToTable("Catalo");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.Code).HasMaxLength(255);

            entity.Property(e => e.DisplayIndex).HasMaxLength(255);

            entity.Property(e => e.MetaCataloCode).HasMaxLength(255);

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.MetaCatalo)
                .WithMany(p => p.Catalos)
                .HasForeignKey(d => d.MetaCataloId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
    }
}