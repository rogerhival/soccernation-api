using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Soccernation.Migrations
{
    public partial class relationshipntonbetweencompetitionsandteams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Competitions_CompetitionId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CompetitionId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "CompetitionsTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompetitionId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    HasPaid = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    TeamId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionsTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionsTeams_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetitionsTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsTeams_CompetitionId",
                table: "CompetitionsTeams",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionsTeams_TeamId",
                table: "CompetitionsTeams",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionsTeams");

            migrationBuilder.AddColumn<Guid>(
                name: "CompetitionId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CompetitionId",
                table: "Teams",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Competitions_CompetitionId",
                table: "Teams",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
