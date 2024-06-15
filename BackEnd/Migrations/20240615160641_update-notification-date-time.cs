using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class updatenotificationdatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Notification");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Notification",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Notification",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Notification",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Notification",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Notification",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Notification",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Notification",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Notification");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Notification",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Notification",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Notification",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Notification",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Notification",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
