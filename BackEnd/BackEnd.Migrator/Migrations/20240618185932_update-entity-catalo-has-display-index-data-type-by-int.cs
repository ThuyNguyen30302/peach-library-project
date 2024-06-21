using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrator.Migrations
{
    public partial class updateentitycatalohasdisplayindexdatatypebyint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DisplayIndex",
                table: "Catalo",
                type: "int",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisplayIndex",
                table: "Catalo",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
