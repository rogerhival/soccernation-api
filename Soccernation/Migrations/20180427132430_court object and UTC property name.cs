using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Soccernation.Migrations
{
    public partial class courtobjectandUTCpropertyname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Users",
                newName: "ModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Users",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Teams",
                newName: "ModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Teams",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "ResultRows",
                newName: "ModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "ResultRows",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Players",
                newName: "ModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Players",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Fixtures",
                newName: "ModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Fixtures",
                newName: "DateUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Fixtures",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "CompetitionsTeams",
                newName: "ModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "CompetitionsTeams",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Competitions",
                newName: "StartDateUtc");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Competitions",
                newName: "ModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Competitions",
                newName: "EndDateUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Competitions",
                newName: "CreatedOnUtc");

            migrationBuilder.AddColumn<Guid>(
                name: "CourtId",
                table: "Fixtures",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Competitions",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Competitions",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<decimal>(
                name: "SubscriptionPrice",
                table: "Competitions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfCompetition",
                table: "Competitions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Court",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompetitionId = table.Column<Guid>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Court", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Court_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_CourtId",
                table: "Fixtures",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Court_CompetitionId",
                table: "Court",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Court_CourtId",
                table: "Fixtures",
                column: "CourtId",
                principalTable: "Court",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Court_CourtId",
                table: "Fixtures");

            migrationBuilder.DropTable(
                name: "Court");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_CourtId",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "SubscriptionPrice",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "TypeOfCompetition",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "ModifiedOnUtc",
                table: "Users",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "Users",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOnUtc",
                table: "Teams",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "Teams",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOnUtc",
                table: "ResultRows",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "ResultRows",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOnUtc",
                table: "Players",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "Players",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOnUtc",
                table: "Fixtures",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "DateUtc",
                table: "Fixtures",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "Fixtures",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOnUtc",
                table: "CompetitionsTeams",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "CompetitionsTeams",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "StartDateUtc",
                table: "Competitions",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedOnUtc",
                table: "Competitions",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "EndDateUtc",
                table: "Competitions",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                table: "Competitions",
                newName: "CreatedOn");
        }
    }
}
