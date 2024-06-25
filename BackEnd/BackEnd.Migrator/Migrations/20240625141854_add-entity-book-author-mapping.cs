using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrator.Migrations
{
    public partial class addentitybookauthormapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "BookAuthorMapping",
                    columns: table => new
                    {
                        AuthorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                        BookId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_BookAuthorMapping", x => new { x.AuthorId, x.BookId });
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
                    })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthorMapping");
        }
    }
}
