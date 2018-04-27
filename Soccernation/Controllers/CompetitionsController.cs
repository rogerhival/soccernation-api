using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccernation.Models;
using Soccernation.Models.Enums;

namespace Soccernation.Controllers
{
    [Produces("application/json")]
    public class CompetitionsController : BaseController<Competition>
    {
        IApplicationRepository<Competition> _repo;

        public CompetitionsController(IApplicationRepository<Competition> repository, SoccernationContext context) : base(repository, context)
        {
            _repo = repository;
        }

        #region Helpers

        Competition GetById(Guid competitionId)
        {
            return Context.Competitions
                .Include(c => c.Fixtures)
                .Include(c => c.Courts)
                .FirstOrDefault(c => c.Id == competitionId);
        }

        #endregion Helpers

        [HttpGet]
        [Route("{competitionId}/teams")]
        public IActionResult GetTeams(Guid competitionId)
        {
            var competition = GetById(competitionId);
            if (competition == null)
                return BadRequest();

            var competitionTeams = Context.CompetitionsTeams.Where(o => o.Competition == competition).Select(c => c.Team);

            return Ok(competitionTeams);
        }

        [HttpPost]
        [Route("{competitionId}/teams")]
        public IActionResult AddTeam([FromBody] List<Team> teams, Guid competitionId)
        {
            if (teams == null)
                return BadRequest();

            var competition = GetById(competitionId);

            if (competition == null)
                return BadRequest();

            teams.ForEach((team) => { Context.CompetitionsTeams.Add(new CompetitionsTeams { Team = team, Competition = competition }); });
            Context.SaveChanges();

            return Ok(competition);
        }

        [HttpGet]
        [Route("{competitionId}/fixtures")]
        public IActionResult GetFixtures(Guid competitionId, [FromQuery] Guid teamId, [FromQuery] string status)
        {
            var competition = GetById(competitionId);

            if (competition == null)
                return BadRequest();

            var fixtureTeam = Context.Teams.FirstOrDefault(t => t.Id == teamId);
            var fixtureStatus = status;
            var fixtures = competition.Fixtures;

            //apply filters
            if (fixtureTeam != null)
                fixtures = fixtures.Where(f => f.TeamHome == fixtureTeam || f.TeamVisitor == fixtureTeam).OrderBy(o => o.DateUtc).ThenBy(o => o.Round).ToList();

            if (!string.IsNullOrEmpty(fixtureStatus))
                fixtures = fixtures.Where(f => f.Status == fixtureStatus).ToList();

            return Ok(fixtures);
        }

        [HttpPost]
        [Route("{competitionId}/fixtures")]
        public async Task<IActionResult> AddFixture(Guid competitionId, [FromBody] Fixture fixture)
        {
            var competition = GetById(competitionId);

            if (competition == null)
                return BadRequest();

            competition.Fixtures.Add(fixture);
            if (await Context.SaveChangesAsync() == 0)
                return BadRequest();

            return Ok(competition.Fixtures);
        }


        [HttpGet]
        [Route("{competitionId}/ladder")]
        public IActionResult GetLadder(Guid competitionId)
        {
            //*******************************
            // Temp method just for test
            //*******************************
            var competition = GetById(competitionId);
            if (competition == null)
                return BadRequest();

            var resultRows = new List<ResultRow>();
            var teams = Context.CompetitionsTeams.Where(o => o.Competition == competition).Select(c => c.Team);

            foreach (var item in teams)
            {
                var resultRow = new ResultRow();
                resultRow.Team = item;
                FixtureCalculator(competition, item, resultRow);
                resultRows.Add(resultRow);
            }

            return Ok(resultRows.OrderByDescending(o => o.Points).ThenByDescending(o => o.Wins).ThenByDescending(o => o.Draws).ThenByDescending(o => o.Loses).ThenBy(o => o.Team.Name));
        }

        void FixtureCalculator(Competition competition, Team team, ResultRow resultRow)
        {
            var fixtures = competition.Fixtures.Where(f => f.Status == FixtureStatus.Finished && (f.TeamHome == team || f.TeamVisitor == team)).ToList();
            var totalGoalsFor = 0;
            var totalGoalsAgainst = 0;
            var totalWins = 0;
            var totalLoses = 0;
            var totalDraws = 0;
            foreach (var fix in fixtures)
            {
                if (fix.TeamHome == team)
                {
                    totalGoalsFor += fix.TeamHomeScore;
                    totalGoalsAgainst += fix.TeamVisitorScore;
                    if (fix.TeamHomeScore > fix.TeamVisitorScore)
                    {
                        totalWins++;
                    }
                    else if (fix.TeamHomeScore < fix.TeamVisitorScore)
                    {
                        totalLoses++;
                    }
                    else
                    {
                        totalDraws++;
                    }
                }
                else
                {
                    totalGoalsFor += fix.TeamVisitorScore;
                    totalGoalsAgainst += fix.TeamHomeScore;
                    if (fix.TeamHomeScore > fix.TeamVisitorScore)
                    {
                        totalLoses++;
                    }
                    else if (fix.TeamHomeScore < fix.TeamVisitorScore)
                    {
                        totalWins++;
                    }
                    else
                    {
                        totalDraws++;
                    }
                }
            }
            resultRow.GoalsAgainst = totalGoalsAgainst;
            resultRow.GoalsFor = totalGoalsFor;
            resultRow.Wins = totalWins;
            resultRow.Loses = totalLoses;
            resultRow.Draws = totalDraws;
            resultRow.Matches = fixtures.Count();
        }

    }
}