﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace KeyPathAPI.Migrations
{
    public partial class UpdatePersonModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Person",
                newName: "Name");
        }
    }
}
