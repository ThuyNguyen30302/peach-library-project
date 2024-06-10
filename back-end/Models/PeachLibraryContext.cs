using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PLP.Models
{
    public partial class PeachLibraryContext : DbContext
    {
        public PeachLibraryContext()
        {
        }

        public PeachLibraryContext(DbContextOptions<PeachLibraryContext> options)
            : base(options)
        {
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-200CPHE\\MSSQLSERVER01;Initial Catalog=PeachLibrary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.NickName).HasMaxLength(255);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<BookAuthorMapping>(entity =>
            {
                entity.ToTable("BookAuthorMapping");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthorMappings)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__BookAutho__Autho__2D27B809");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthorMappings)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__BookAutho__BookI__2E1BDC42");
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.ToTable("BookCopy");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.YearPublisher).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookCopies)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__BookCopy__BookId__35BCFE0A");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.BookCopies)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__BookCopy__Publis__36B12243");
            });

            modelBuilder.Entity<Catalo>(entity =>
            {
                entity.ToTable("Catalo");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.DisplayIndex).HasMaxLength(255);

                entity.Property(e => e.MetaCataloCode).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.MetaCatalo)
                    .WithMany(p => p.Catalos)
                    .HasForeignKey(d => d.MetaCataloId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Catalo__MetaCata__4D94879B");
            });

            modelBuilder.Entity<CheckOut>(entity =>
            {
                entity.ToTable("CheckOut");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.BookCopy)
                    .WithMany(p => p.CheckOuts)
                    .HasForeignKey(d => d.BookCopyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__CheckOut__BookCo__403A8C7D");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CheckOuts)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__CheckOut__Member__3F466844");
            });

            modelBuilder.Entity<Hold>(entity =>
            {
                entity.ToTable("Hold");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.BookCopy)
                    .WithMany(p => p.Holds)
                    .HasForeignKey(d => d.BookCopyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Hold__BookCopyId__45F365D3");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Holds)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Hold__MemberId__44FF419A");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.CardNumber).HasMaxLength(255);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            modelBuilder.Entity<MetaCatalo>(entity =>
            {
                entity.ToTable("MetaCatalo");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SendAt).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Notificat__Membe__5165187F");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<WaitingList>(entity =>
            {
                entity.ToTable("WaitingList");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.WaitingLists)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__WaitingLi__BookI__571DF1D5");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.WaitingLists)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__WaitingLi__Membe__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
