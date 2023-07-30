using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutorials.Data.Migrations
{
    public partial class AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "Region");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "users",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Addresses",
                newName: "Street");
        }
    }
}
