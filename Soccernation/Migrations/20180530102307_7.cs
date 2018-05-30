using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Soccernation.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ResultRows");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Referees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Continent");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CompetitionsTeams");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CompetitionsCourts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cities");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Courts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courts_CompanyId",
                table: "Courts",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Companies_CompanyId",
                table: "Courts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Companies_CompanyId",
                table: "Courts");

            migrationBuilder.DropIndex(
                name: "IX_Courts_CompanyId",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Courts");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "States",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ResultRows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Referees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Courts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Continent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CompetitionsTeams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CompetitionsCourts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Competitions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Cities",
                nullable: true);
        }
    }
}
