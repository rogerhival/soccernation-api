using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Soccernation.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ExpireDateUtc",
                table: "Users",
                newName: "ExpireDateUtc");

            migrationBuilder.AddColumn<byte[]>(
                name: "Key",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "KeySalt",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeLoginUtc",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "KeySalt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastTimeLoginUtc",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ExpireDateUtc",
                table: "Users",
                newName: "ExpireDateUTC");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                defaultValue: "");
        }
    }
}
