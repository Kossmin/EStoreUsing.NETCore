using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObject.Migrations
{
    public partial class newupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmationCode",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "confirmationCode",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
