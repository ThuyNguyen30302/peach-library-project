using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CardNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaCatalo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaCatalo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthorMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthorMapping_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthorMapping_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SendAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaitingList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingList_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaitingList_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DisplayIndex = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MetaCataloCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MetaCataloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalo_MetaCatalo_MetaCataloId",
                        column: x => x.MetaCataloId,
                        principalTable: "MetaCatalo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    YearPublisher = table.Column<DateTime>(type: "datetime", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCopy_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCopy_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckOut",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookCopyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckOut_BookCopy_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckOut_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hold",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookCopyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hold_BookCopy_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hold_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMapping_AuthorId",
                table: "BookAuthorMapping",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMapping_BookId",
                table: "BookAuthorMapping",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_BookId",
                table: "BookCopy",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_PublisherId",
                table: "BookCopy",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalo_MetaCataloId",
                table: "Catalo",
                column: "MetaCataloId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_BookCopyId",
                table: "CheckOut",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_MemberId",
                table: "CheckOut",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Hold_BookCopyId",
                table: "Hold",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hold_MemberId",
                table: "Hold",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_MemberId",
                table: "Notification",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingList_BookId",
                table: "WaitingList",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingList_MemberId",
                table: "WaitingList",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthorMapping");

            migrationBuilder.DropTable(
                name: "Catalo");

            migrationBuilder.DropTable(
                name: "CheckOut");

            migrationBuilder.DropTable(
                name: "Hold");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "WaitingList");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "MetaCatalo");

            migrationBuilder.DropTable(
                name: "BookCopy");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
