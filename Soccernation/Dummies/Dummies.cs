using Soccernation.Models;
using Soccernation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccernation
{
    public static class Dummies
    {
        public static List<User> Users => GetUsers();
        public static List<Player> Players => GetPlayers();
        public static List<Team> Teams => GetTeams();
        public static List<Fixture> Fixtures => GetFixtures();
        public static List<Competition> Competitions => GetCompetitions();

        static List<User> GetUsers()
        {
            var players = Players;

            return new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Email = "test@test.com",
                    Name = "User 1",
                    Status = EntityStatus.Active,
                    Password = "test",
                    Player = players[0]
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Email = "test2@test2.com",
                    Name = "User 2",
                    Status = EntityStatus.Active,
                    Password = "test2",
                    Player = players[1]
                }
            };
        }

        static List<Player> GetPlayers()
        {
            return new List<Player>()
            {
                new Player()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Status = EntityStatus.Active,
                    Name = "Player 1"
                },
                new Player()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Status = EntityStatus.Active,
                    Name = "Player 2"
                },
                new Player()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Status = EntityStatus.Active,
                    Name = "Player 3"
                },
                new Player()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Status = EntityStatus.Active,
                    Name = "Player 4"
                }
            };
        }

        static List<Team> GetTeams()
        {
            return new List<Team>()
            {
                new Team()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Name = "Team 1",
                    Status = EntityStatus.Active,
                    Players = Players.Take(2).ToList()
                },
                new Team()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Name = "Team 2",
                    Status = EntityStatus.Active,
                    Players = Players.Skip(2).Take(2).ToList()
                }
            };
        }

        static List<Fixture> GetFixtures()
        {
            return new List<Fixture>()
            {
                new Fixture()
                {
                    Id=Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Date = DateTime.Today,
                    Status = EntityStatus.Active,
                    Round = 1,
                    TeamHome = Teams[0],
                    TeamVisitor = Teams[1]
                },
                new Fixture()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Date = DateTime.Today.AddDays(7),
                    Status = EntityStatus.Active,
                    Round = 1,
                    TeamHome = Teams[1],
                    TeamVisitor = Teams[0]
                }
            };
        }

        static List<Competition> GetCompetitions()
        {
            return new List<Competition>()
            {
                new Competition()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    Date = DateTime.Today,
                    Status = EntityStatus.Active,
                    Fixtures = Fixtures,
                    Name = "Cup 1",
                    Teams = Teams
                }
            };
        }
    }
}
