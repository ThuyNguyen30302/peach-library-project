using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrator.Migrations
{
    public partial class updateidtypeuuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "WaitingList",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Publisher",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MetaCatalo",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Member",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Hold",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CheckOut",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Catalo",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BookCopy",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BookAuthorMapping",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Book",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Author",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "'UUID()'")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "WaitingList",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Publisher",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "MetaCatalo",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Member",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Hold",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CheckOut",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Catalo",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BookCopy",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BookAuthorMapping",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Book",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Author",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "'UUID()'",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
