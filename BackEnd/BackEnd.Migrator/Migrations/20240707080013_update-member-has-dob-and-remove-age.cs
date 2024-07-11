using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrator.Migrations
{
    public partial class updatememberhasdobandremoveage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Member");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoB",
                table: "Member",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoB",
                table: "Member");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
