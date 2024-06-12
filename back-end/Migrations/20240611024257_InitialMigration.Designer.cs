﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PLP.Models;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    [Migration("20240611024257_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PLP.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("PLP.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("PLP.Models.BookAuthorMapping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthorMapping", (string)null);
                });

            modelBuilder.Entity("PLP.Models.BookCopy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("YearPublisher")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PublisherId");

                    b.ToTable("BookCopy", (string)null);
                });

            modelBuilder.Entity("PLP.Models.Catalo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DisplayIndex")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MetaCataloCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("MetaCataloId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MetaCataloId");

                    b.ToTable("Catalo", (string)null);
                });

            modelBuilder.Entity("PLP.Models.CheckOut", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("BookCopyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("MemberId");

                    b.ToTable("CheckOut", (string)null);
                });

            modelBuilder.Entity("PLP.Models.Hold", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("BookCopyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("BookCopyId");

                    b.HasIndex("MemberId");

                    b.ToTable("Hold", (string)null);
                });

            modelBuilder.Entity("PLP.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("PLP.Models.MetaCatalo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("MetaCatalo", (string)null);
                });

            modelBuilder.Entity("PLP.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SendAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("PLP.Models.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Publisher", (string)null);
                });

            modelBuilder.Entity("PLP.Models.WaitingList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("WaitingList", (string)null);
                });

            modelBuilder.Entity("PLP.Models.BookAuthorMapping", b =>
                {
                    b.HasOne("PLP.Models.Author", "Author")
                        .WithMany("BookAuthorMappings")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PLP.Models.Book", "Book")
                        .WithMany("BookAuthorMappings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("PLP.Models.BookCopy", b =>
                {
                    b.HasOne("PLP.Models.Book", "Book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PLP.Models.Publisher", "Publisher")
                        .WithMany("BookCopies")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("PLP.Models.Catalo", b =>
                {
                    b.HasOne("PLP.Models.MetaCatalo", "MetaCatalo")
                        .WithMany("Catalos")
                        .HasForeignKey("MetaCataloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MetaCatalo");
                });

            modelBuilder.Entity("PLP.Models.CheckOut", b =>
                {
                    b.HasOne("PLP.Models.BookCopy", "BookCopy")
                        .WithMany("CheckOuts")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PLP.Models.Member", "Member")
                        .WithMany("CheckOuts")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCopy");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PLP.Models.Hold", b =>
                {
                    b.HasOne("PLP.Models.BookCopy", "BookCopy")
                        .WithMany("Holds")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PLP.Models.Member", "Member")
                        .WithMany("Holds")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCopy");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PLP.Models.Notification", b =>
                {
                    b.HasOne("PLP.Models.Member", "Member")
                        .WithMany("Notifications")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PLP.Models.WaitingList", b =>
                {
                    b.HasOne("PLP.Models.Book", "Book")
                        .WithMany("WaitingLists")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PLP.Models.Member", "Member")
                        .WithMany("WaitingLists")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("PLP.Models.Author", b =>
                {
                    b.Navigation("BookAuthorMappings");
                });

            modelBuilder.Entity("PLP.Models.Book", b =>
                {
                    b.Navigation("BookAuthorMappings");

                    b.Navigation("BookCopies");

                    b.Navigation("WaitingLists");
                });

            modelBuilder.Entity("PLP.Models.BookCopy", b =>
                {
                    b.Navigation("CheckOuts");

                    b.Navigation("Holds");
                });

            modelBuilder.Entity("PLP.Models.Member", b =>
                {
                    b.Navigation("CheckOuts");

                    b.Navigation("Holds");

                    b.Navigation("Notifications");

                    b.Navigation("WaitingLists");
                });

            modelBuilder.Entity("PLP.Models.MetaCatalo", b =>
                {
                    b.Navigation("Catalos");
                });

            modelBuilder.Entity("PLP.Models.Publisher", b =>
                {
                    b.Navigation("BookCopies");
                });
#pragma warning restore 612, 618
        }
    }
}
