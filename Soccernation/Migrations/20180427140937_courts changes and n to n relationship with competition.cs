using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Soccernation.Migrations
{
    public partial class courtschangesandntonrelationshipwithcompetition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Court_Competitions_CompetitionId",
                table: "Court");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Court_CourtId",
                table: "Fixtures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Court",
                table: "Court");

            migrationBuilder.DropIndex(
                name: "IX_Court_CompetitionId",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Court");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Court");

            migrationBuilder.RenameTable(
                name: "Court",
                newName: "Courts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courts",
                table: "Courts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompetitionsCourts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompetitionId = table.Column<Guid>(nullable: false),
                    CourtId = table.Column<Guid>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsCourts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionsCourts_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionsCourts_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsCourts_CompetitionId",
                table: "CompetitionsCourts",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsCourts_CourtId",
                table: "CompetitionsCourts",
                column: "CourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Courts_CourtId",
                table: "Fixtures",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Courts_CourtId",
                table: "Fixtures");

            migrationBuilder.DropTable(
                name: "CompetitionsCourts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courts",
                table: "Courts");

            migrationBuilder.RenameTable(
                name: "Courts",
                newName: "Court");

            migrationBuilder.AddColumn<Guid>(
                name: "CompetitionId",
                table: "Court",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Court",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Court",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Court",
                table: "Court",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Court_CompetitionId",
                table: "Court",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Court_Competitions_CompetitionId",
                table: "Court",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Court_CourtId",
                table: "Fixtures",
                column: "CourtId",
                principalTable: "Court",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
