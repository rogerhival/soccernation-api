using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Soccernation.Models;
using Soccernation.Models.Enums;

namespace Soccernation.Helpers
{
    public class FixtureHelper
    {
        #region Ladder

        public static List<ResultRow> BuildLadder(Competition competition, List<Team> teams)
        {
            var resultRows = new List<ResultRow>();

            foreach (var item in teams)
            {
                var resultRow = new ResultRow();
                resultRow.Team = item;
                LadderCalculator(competition, item, resultRow);
                resultRows.Add(resultRow);
            }

            return resultRows.OrderByDescending(o => o.Points).ThenByDescending(o => o.Wins).ThenByDescending(o => o.Draws).ThenByDescending(o => o.GoalDifference).ThenByDescending(o => o.GoalsAgainst).ThenBy(o => o.Team.Name).ToList();
        }

        static void LadderCalculator(Competition competition, Team team, ResultRow resultRow)
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

        #endregion Ladder

        #region Create Fixtures

        public static List<Fixture> CreateRandomFixtures(List<Team> teams, bool isTwoLeggedTie)
        {
            // *************************************************
            // TODO: Create it for DATES, COURT
            // Round: problema com impar
            // *************************************************
            var fixtures = new List<Fixture>();
            var rounds = new RoundGenerator(teams);

            if (teams != null && teams.Count > 1)
            {
                Shuffle(teams);

                for (var i = 0; i < teams.Count; i++)
                {
                    var home = true;
                    var team1 = teams[i];
                    for (var j = i + 1; j < teams.Count; j++)
                    {
                        var team2 = teams[j];

                        var fixture = new Fixture();
                        if (home)
                        {
                            fixture.TeamHome = team1;
                            fixture.TeamVisitor = team2;
                        }
                        else
                        {
                            fixture.TeamHome = team2;
                            fixture.TeamVisitor = team1;
                        }
                        fixture.Status = FixtureStatus.Pending;
                        fixture.Round = rounds.GetRoundByTeam(team1, team2);
                        fixture.Leg = 1;
                        //fixture.Date
                        //fixture.Court

                        fixtures.Add(fixture);
                        home = !home;
                    }
                }

                if (isTwoLeggedTie)
                {
                    var fixtureCount = fixtures.Count;
                    for (int i = 0; i < fixtureCount; i++)
                    {
                        var newFixture = CloneObject(fixtures[i]);
                        newFixture.Leg = 2;
                        var teamHome = newFixture.TeamVisitor;
                        var teamVisitor = newFixture.TeamHome;
                        newFixture.TeamHome = teamHome;
                        newFixture.TeamVisitor = teamVisitor;
                        fixtures.Add(newFixture);
                    }
                }
            }

            return fixtures.GroupBy(g => g.Leg).OrderBy(g => g.Key).SelectMany(g => g.OrderBy(x => x.Round)).ToList();
        }

        static Fixture CloneObject(Fixture fixture)
        {
            return AutoMapper.Map<Fixture, Fixture>(fixture);
        }

        static IMapper AutoMapper
        {
            get
            {
                //Install-Package AutoMapper
                if (autoMapper == null)
                {
                    var config = new MapperConfiguration(cfg => { cfg.CreateMap<Fixture, Fixture>(); });
                    autoMapper = config.CreateMapper();
                }

                return autoMapper;
            }
        }
        static IMapper autoMapper;

        static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        class RoundGenerator
        {
            List<string> teamList;
            List<string> teamListInverted;
            int RoundCounter = 1;
            List<RoundStruct> roundsByTeam;
            public bool DummyTeam = false; // ODD number of teams -> one team will no be able to play.
            public bool NextRoundExists => (RoundCounter < teamListInverted.Count);

            public RoundGenerator(List<Team> teams)
            {
                teamList = teams.Select(t => t.Name).ToList();

                // ODD number of teams
                if (teamList.Count % 2 != 0)
                {
                    teamList.Add("MISSING TEAM");
                    DummyTeam = true;
                }

                teamListInverted = new List<string>();
                for (var i = teamList.Count - 1; i >= 0; i--)
                {
                    teamListInverted.Add(teamList[i]);
                }

                PopulateRounds();
            }

            void PopulateRounds()
            {
                roundsByTeam = new List<RoundStruct>();
                while (NextRoundExists)
                {
                    for (int x = 0; x < teamListInverted.Count / 2; x++)
                    {
                        roundsByTeam.Add(new RoundStruct() { Round = RoundCounter, Team1 = teamList[x], Team2 = teamListInverted[x] });
                    }

                    NextRound();
                }
            }

            void RotateTeamList(int atPos)
            {
                if (atPos == 1)
                {
                    var iO = teamList[teamList.Count - 1];
                    RotateTeamList(atPos + 1);
                    teamList[1] = iO;
                }
                else
                {
                    if (atPos < teamList.Count - 1)
                    {
                        RotateTeamList(atPos + 1);
                    }
                    teamList[atPos] = teamList[atPos - 1];
                }
            }

            void RotateTeamListInverted()
            {
                int i;
                for (i = 0; i < teamListInverted.Count / 2; i++)
                {
                    teamListInverted[i] = teamListInverted[i + 1];
                }
                for (i = teamListInverted.Count / 2; i < teamListInverted.Count; i++)
                {
                    teamListInverted[i] = teamList[teamListInverted.Count / 2 - (i - teamListInverted.Count / 2 + 1)];
                }
            }

            bool NextRound()
            {
                if (NextRoundExists)
                {
                    RoundCounter++; // Next round
                    RotateTeamList(1); // A side rotation
                    RotateTeamListInverted(); // B side rotation
                    return true;
                }

                return false;
            }

            public int GetRoundByTeam(Team team1, Team team2)
            {
                var round = roundsByTeam.FirstOrDefault(r => (r.Team1 == team1.Name && r.Team2 == team2.Name) || (r.Team1 == team2.Name && r.Team2 == team1.Name));
                if (round != null)
                    return round.Round;

                return 0;
            }

            class RoundStruct
            {
                public string Team1 { get; set; }
                public string Team2 { get; set; }
                public int Round { get; set; }
            }
        }

        #endregion Create Fixtures
    }
}
