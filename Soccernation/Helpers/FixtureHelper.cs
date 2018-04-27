using Soccernation.Models;
using Soccernation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                FixtureCalculator(competition, item, resultRow);
                resultRows.Add(resultRow);
            }

            return resultRows.OrderByDescending(o => o.Points).ThenByDescending(o => o.Wins).ThenByDescending(o => o.Draws).ThenByDescending(o => o.Loses).ThenBy(o => o.Team.Name).ToList();
        }

        static void FixtureCalculator(Competition competition, Team team, ResultRow resultRow)
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

        #region Ladder

        public static List<Fixture> CreateRandomFixtures(List<Team> teams)
        {
            // *************************************************
            // TODO: Create it for DATES, COURT
            // Round: problema com impar
            // *************************************************
            var fixtures = new List<Fixture>();

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
                        
                        //fixture.Date

                        fixtures.Add(fixture);
                        home = !home;
                    }
                }

                //var round = 1;
                //for (var i = 0; i < teams.Count; i++)
                //{
                //    for (var j = i+1; j < teams.Count; j++)
                //    {
                //        var fixture = fixtures.First(f => f.TeamHome == teams[i] && f.TeamVisitor == teams[j]);
                //        fixture.Round = round;

                //    }
                //    round++;
                //}

            }

            return fixtures.OrderByDescending(f => f.Round).ToList();
        }

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

        #endregion Ladder
    }
}
