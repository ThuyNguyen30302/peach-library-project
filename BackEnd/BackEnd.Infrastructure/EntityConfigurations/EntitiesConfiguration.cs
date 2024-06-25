using BackEnd.Domain.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.EntityConfigurations;

public static class EntitiesConfiguration
{
    public static void ConfigureBaseEntities(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.Property(e => e.NickName).HasMaxLength(255);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");
            
            entity.Property(e => e.Active).HasDefaultValue(true);
            
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.Title).HasMaxLength(128);

            entity.Property(e => e.Type).HasMaxLength(255);
            
            entity.HasMany(e => e.BookAuthorMappings)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.BookId);
        });

        modelBuilder.Entity<BookAuthorMapping>(entity =>
        {
            entity.ToTable("BookAuthorMapping");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.HasOne(d => d.Author)
                .WithMany(p => p.BookAuthorMappings)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Book)
                .WithMany(p => p.BookAuthorMappings)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<BookCopy>(entity =>
        {
            entity.ToTable("BookCopy");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.YearPublisher).HasColumnType("datetime");
            
            entity.Property(e => e.Active).HasDefaultValue(true);

            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

            entity.HasOne(d => d.Book)
                .WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Publisher)
                .WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CheckOut>(entity =>
        {
            entity.ToTable("CheckOut");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");

            entity.Property(e => e.EndTime).HasColumnType("datetime");

            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.BookCopy)
                .WithMany(p => p.CheckOuts)
                .HasForeignKey(d => d.BookCopyId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Member)
                .WithMany(p => p.CheckOuts)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Hold>(entity =>
        {
            entity.ToTable("Hold");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");

            entity.Property(e => e.EndTime).HasColumnType("datetime");

            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.BookCopy)
                .WithMany(p => p.Holds)
                .HasForeignKey(d => d.BookCopyId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Member)
                .WithMany(p => p.Holds)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.Address).HasMaxLength(255);

            entity.Property(e => e.CardNumber).HasMaxLength(255);

            entity.Property(e => e.PhoneNumber).HasMaxLength(128);
            
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");

            entity.Property(e => e.Email).HasMaxLength(255);

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.Property(e => e.Status).HasMaxLength(255);

            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.SendAt).HasColumnType("datetime");

            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");

            entity.Property(e => e.Type).HasMaxLength(255);

            entity.HasOne(d => d.Member)
                .WithMany(p => p.Notifications)
                .HasForeignKey(d => d.MemberId);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.ToTable("Publisher");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.Code).HasMaxLength(255);

            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<WaitingList>(entity =>
        {
            entity.ToTable("WaitingList");

            entity.Property(e => e.Id).HasDefaultValueSql("(UUID())");

            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("datetime");
            
            entity.Property(e => e.DeletionTime)
                .HasColumnType("datetime");

            entity.HasOne(d => d.Book)
                .WithMany(p => p.WaitingLists)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Member)
                .WithMany(p => p.WaitingLists)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}