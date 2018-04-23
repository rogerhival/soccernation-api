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
            if (users != null)
            {
                users = new List<User>()
                    {
                        new User()
                        {
                            Id = new Guid("D188A356-0B28-479C-BB95-3B98BC3A2491"),
                            CreatedOn = DateTime.Now,
                            Email = "test@test.com",
                            Name = "User 1",
                            Status = EntityStatus.Active,
                            Password = "test",
                            Player = Players[0]
                        },
                        new User()
                        {
                            Id = new Guid("1DB282E0-3F93-4A5E-9536-7B714E24DDCB"),
                            CreatedOn = DateTime.Now,
                            Email = "test2@test2.com",
                            Name = "User 2",
                            Status = EntityStatus.Active,
                            Password = "test2",
                            Player = Players[1]
                        }
                    };
            }
            return users;
        }
        static List<User> users;

        static List<Player> GetPlayers()
        {
            if (players == null)
            {
                players = new List<Player>()
                    {
                        new Player()
                        {
                            Id = new Guid("535D2851-3C94-4891-935F-37EE7C4846FF"),
                            CreatedOn = DateTime.Now,
                            Status = EntityStatus.Active,
                            Name = "Player 1"
                        },
                        new Player()
                        {
                            Id = new Guid("538DA346-70A3-4F6A-9D77-53CE04256A37"),
                            CreatedOn = DateTime.Now,
                            Status = EntityStatus.Active,
                            Name = "Player 2"
                        },
                        new Player()
                        {
                            Id = new Guid("F30D3038-3128-4BBF-A7D0-1A41B4C76427"),
                            CreatedOn = DateTime.Now,
                            Status = EntityStatus.Active,
                            Name = "Player 3"
                        },
                        new Player()
                        {
                            Id = new Guid("1A740AD9-20C8-4941-B50A-3345C552612D"),
                            CreatedOn = DateTime.Now,
                            Status = EntityStatus.Active,
                            Name = "Player 4"
                        }
                    };
            }
            return players;
        }
        static List<Player> players;

        static List<Team> GetTeams()
        {
            if (teams == null)
            {
                teams = new List<Team>()
                    {
                        new Team()
                        {
                            Id = new Guid("6648573B-B0FE-45AE-92D5-E70E4F322DA8"),
                            CreatedOn = DateTime.Now,
                            Name = "Team 1",
                            Status = EntityStatus.Active,
                            Players = Players.Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("EF088441-63C5-4A9C-9BD0-9AC75E42174C"),
                            CreatedOn = DateTime.Now,
                            Name = "Team 2",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        }
                    };
            }
            return teams;
        }
        static List<Team> teams;

        static List<Fixture> GetFixtures()
        {
            if (fixtures == null)
            {
                fixtures = new List<Fixture>()
                    {
                        new Fixture()
                        {
                            Id = new Guid("7D058B0F-57AC-4194-864C-7E2F71BDEDEB"),
                            CreatedOn = DateTime.Now,
                            Date = DateTime.Today,
                            Status = EntityStatus.Active,
                            Round = 1,
                            TeamHome = Teams[0],
                            TeamVisitor = Teams[1]
                        },
                        new Fixture()
                        {
                            Id = new Guid("13B69E9C-C503-421F-98F4-00335AF24AB4"),
                            CreatedOn = DateTime.Now,
                            Date = DateTime.Today.AddDays(7),
                            Status = EntityStatus.Active,
                            Round = 1,
                            TeamHome = Teams[1],
                            TeamVisitor = Teams[0]
                        }
                    };
            }
            return fixtures;
        }
        static List<Fixture> fixtures;

        static List<Competition> GetCompetitions()
        {
            if (competitions == null)
            {
                competitions = new List<Competition>()
                    {
                        new Competition()
                        {
                            Id = new Guid("14A9F72E-6704-4917-8038-C9AA45A3ED20"),
                            CreatedOn = DateTime.Now,
                            Date = DateTime.Today,
                            Status = EntityStatus.Active,
                            Fixtures = Fixtures,
                            Name = "Cup 1",
                            Teams = Teams
                        }
                    };
            }
            return competitions;
        }
        static List<Competition> competitions;
    }
}
