using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrator.Migrations
{
    public partial class updatebookauthormappingremoveid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthorMapping");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
