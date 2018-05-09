using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Soccernation.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsWhenBye",
                table: "Competitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsWhenDraw",
                table: "Competitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsWhenForfeit",
                table: "Competitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsWhenLoss",
                table: "Competitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsWhenWin",
                table: "Competitions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsWhenBye",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "PointsWhenDraw",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "PointsWhenForfeit",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "PointsWhenLoss",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "PointsWhenWin",
                table: "Competitions");
        }
    }
}
