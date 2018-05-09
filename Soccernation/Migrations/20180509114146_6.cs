using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Soccernation.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "CustomizedUrl",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookToken",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoogleToken",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterToken",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraEmail",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FantasyName",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomizedUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FacebookToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GoogleToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwitterToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ExtraEmail",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FantasyName",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Companies",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Players",
                nullable: false,
                defaultValue: "");
        }
    }
}
