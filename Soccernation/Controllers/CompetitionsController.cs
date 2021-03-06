﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccernation.Helpers;
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
        public IActionResult AddTeam(Guid competitionId, [FromBody] List<Team> teams)
        {
            if (teams == null)
                return BadRequest();

            var competition = GetById(competitionId);

            if (competition == null)
                return BadRequest();

            teams.ForEach((team) => { Context.CompetitionsTeams.Add(new CompetitionsTeams { Team = team, Competition = competition, HasPaid = team.HasPaid }); });

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
        public async Task<IActionResult> AddFixture(Guid competitionId, [FromBody] List<Fixture> fixtures)
        {
            try
            {
                if (fixtures == null)
                    return BadRequest();

                var competition = GetById(competitionId);

                if (competition == null)
                    return BadRequest();

                // TEMP
                foreach (var item in fixtures)
                {
                    var idTeam1 = item.TeamHome.Id;
                    var idTeam2 = item.TeamVisitor.Id;

                    item.TeamHome = Context.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == idTeam1);
                    item.TeamVisitor = Context.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == idTeam2);
                }

                fixtures.ForEach((fixture) => { competition.Fixtures.Add(fixture); });

                if (await Context.SaveChangesAsync() == 0)
                    return BadRequest();

                return Ok(competition.Fixtures);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{competitionId}/courts")]
        public IActionResult GetCourts(Guid competitionId)
        {
            var competition = GetById(competitionId);

            if (competition == null)
                return BadRequest();

            var courts = Context.CompetitionsCourts.Where(o => o.Competition == competition && (o.StartTime >= competition.StartTime && o.EndTime <= competition.EndTime)).Select(o => o.Court);

            return Ok(courts);
        }

        [HttpPost]
        [Route("{competitionId}/courts")]
        public IActionResult AddCourt([FromBody] List<Court> courts, Guid competitionId)
        {
            if (courts == null)
                return BadRequest();

            var competition = GetById(competitionId);

            if (competition == null)
                return BadRequest();

            courts.ForEach((court) => { Context.CompetitionsCourts.Add(new CompetitionsCourts { Court = court, Competition = competition, StartTime = court.StartTime, EndTime = court.EndTime }); });
            Context.SaveChanges();

            return Ok(competition);
        }

        [HttpGet]
        [Route("{competitionId}/ladder")]
        public IActionResult GetLadder(Guid competitionId)
        {
            var competition = GetById(competitionId);
            if (competition == null)
                return BadRequest();

            var teams = Context.CompetitionsTeams.Where(o => o.Competition == competition).Select(c => c.Team).ToList();
            var resultRows = FixtureHelper.BuildLadder(competition, teams);

            return Ok(resultRows);
        }

        [HttpGet]
        [Route("{competitionId}/generateFixtures")]
        public IActionResult GenerateFixtures(Guid competitionId)
        {
            var competition = GetById(competitionId);

            if (competition == null)
                return BadRequest();

            var teams = Context.CompetitionsTeams.Where(o => o.Competition == competition).Select(c => c.Team).ToList();
            var fixtures = FixtureHelper.CreateRandomFixtures(teams, competition.IsTwoLeggedTie);

            return Ok(fixtures);
        }

        public override IEnumerable<Competition> Get()
        {
            return Context.Competitions
               .Include(c => c.Fixtures)
                    .ThenInclude(f => f.TeamHome)
               .Include(c => c.Fixtures)
                    .ThenInclude(f => f.TeamVisitor)
               .Include(c => c.Results)
               .ToList();
        }

        public override Competition GetById(Guid id)
        {
            return Context.Competitions
                .Include(c => c.Fixtures)
                    .ThenInclude(f => f.TeamHome)
                .Include(c => c.Fixtures)
                    .ThenInclude(f => f.TeamVisitor)
                .Include(c => c.Results)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}