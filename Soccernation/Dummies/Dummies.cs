using System;
using System.Collections.Generic;
using System.Linq;
using Soccernation.Models;
using Soccernation.Models.Enums;

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
            if (users == null)
            {
                users = new List<User>()
                    {
                        new User()
                        {
                            Id = new Guid("D188A356-0B28-479C-BB95-3B98BC3A2491"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Email = "test@test.com",
                            Status = EntityStatus.Active,
                            Password = "test",
                            Player = Players[0]
                        },
                        new User()
                        {
                            Id = new Guid("1DB282E0-3F93-4A5E-9536-7B714E24DDCB"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Email = "test2@test2.com",
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
                            CreatedOnUtc = DateTime.UtcNow,
                            Status = EntityStatus.Active,
                            FirstName = "Player",
                            LastName = "1"
                        },
                        new Player()
                        {
                            Id = new Guid("538DA346-70A3-4F6A-9D77-53CE04256A37"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Status = EntityStatus.Active,
                            FirstName = "Player",
                            LastName = "2"
                        },
                        new Player()
                        {
                            Id = new Guid("F30D3038-3128-4BBF-A7D0-1A41B4C76427"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Status = EntityStatus.Active,
                            FirstName = "Player",
                            LastName = "3"
                        },
                        new Player()
                        {
                            Id = new Guid("1A740AD9-20C8-4941-B50A-3345C552612D"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Status = EntityStatus.Active,
                            FirstName = "Player",
                            LastName = "4"
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
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Unreal Madrid",
                            Status = EntityStatus.Active,
                            Players = Players.Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("EF088441-63C5-4A9C-9BD0-9AC75E42174C"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "No I In Team",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("065CBE10-67EF-4FFA-9B4F-42F3A03CB7AD"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Team Tam",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("5CF4812D-322E-4D09-900D-07DFBA1F5EF6"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Tricky Dicky's Big Suite",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("366CBD25-428D-4F88-B04C-976667C2E0C6"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Schenker Utd",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("445BDE94-AD73-4296-A0CE-09D6CDAB448F"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Qantas",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("90DDACF2-2BBD-4060-9459-4F918922F2E3"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Ivory Toast",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("6587CD7F-BBBF-436C-8A9E-7BB4C516235B"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Anchors",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("3D5F88B8-0FED-40AB-AD67-CA6BE154CC6A"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Commander Centre",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("4ED6DEA2-5DA3-4A9D-AA16-62E35225EB1E"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Kn",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("531CDC10-4010-42F6-AB73-3D214DBD71F8"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Schenker",
                            Status = EntityStatus.Active,
                            Players = Players.Skip(2).Take(2).ToList()
                        },
                        new Team()
                        {
                            Id = new Guid("7EB32CEE-3C22-4558-B961-861C1C140C5E"),
                            CreatedOnUtc = DateTime.UtcNow,
                            Name = "Autopia",
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
                            CreatedOnUtc = DateTime.UtcNow,
                            DateUtc = DateTime.Today,
                            Status = FixtureStatus.Pending,
                            Round = 1,
                            TeamHome = Teams[0],
                            TeamVisitor = Teams[1]
                        },
                        new Fixture()
                        {
                            Id = new Guid("02ADB1E8-DF53-4414-B66B-EA217EEBC845"),
                            CreatedOnUtc = DateTime.UtcNow,
                            DateUtc = DateTime.Today.AddDays(7),
                            Status = FixtureStatus.Pending,
                            Round = 1,
                            TeamHome = Teams[2],
                            TeamVisitor = Teams[3]
                        },
                        new Fixture()
                        {
                            Id = new Guid("A278FCE1-EC0C-4682-9CF0-8FC82D8637B6"),
                            CreatedOnUtc = DateTime.UtcNow,
                            DateUtc = DateTime.Today.AddDays(7),
                            Status = FixtureStatus.Pending,
                            Round = 1,
                            TeamHome = Teams[4],
                            TeamVisitor = Teams[5]
                        },
                        new Fixture()
                        {
                            Id = new Guid("08F06CD6-108C-47E6-AEC3-0B25A2ABFE33"),
                            CreatedOnUtc = DateTime.UtcNow,
                            DateUtc = DateTime.Today.AddDays(7),
                            Status = FixtureStatus.Pending,
                            Round = 1,
                            TeamHome = Teams[6],
                            TeamVisitor = Teams[7]
                        },
                        new Fixture()
                        {
                            Id = new Guid("531E6399-2938-4F95-A54F-EE2BB6D4140F"),
                            CreatedOnUtc = DateTime.UtcNow,
                            DateUtc = DateTime.Today.AddDays(7),
                            Status = FixtureStatus.Pending,
                            Round = 1,
                            TeamHome = Teams[8],
                            TeamVisitor = Teams[9]
                        },
                        new Fixture()
                        {
                            Id = new Guid("13B69E9C-C503-421F-98F4-00335AF24AB4"),
                            CreatedOnUtc = DateTime.UtcNow,
                            DateUtc = DateTime.Today.AddDays(7),
                            Status = FixtureStatus.Pending,
                            Round = 1,
                            TeamHome = Teams[10],
                            TeamVisitor = Teams[11]
                        },
                        new Fixture()
                        {
                            Id = new Guid("33049F8F-EC43-47E0-803F-56391C67F1FE"),
                            CreatedOnUtc = DateTime.UtcNow,
                            DateUtc = DateTime.Today.AddDays(-1),
                            Status = FixtureStatus.Finished,
                            Round = 1,
                            TeamHome = Teams[0],
                            TeamVisitor = Teams[1],
                            TeamHomeScore = 6,
                            TeamVisitorScore = 2
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
                            CreatedOnUtc = DateTime.UtcNow,
                            StartDateUtc = DateTime.Today,
                            Status = EntityStatus.Active,
                            Fixtures = Fixtures,
                            Name = "Futsal, Men's Thursday Lunchtime 2"
                        },
                        new Competition()
                        {
                            Id = new Guid("8CE1B530-3EFA-4907-B522-1D1ADB4D7CA4"),
                            CreatedOnUtc = DateTime.UtcNow,
                            StartDateUtc = DateTime.Today,
                            Status = EntityStatus.Active,
		                    //Fixtures = Fixtures,
		                    Name = "Men's Monday DIV1",
		                    //Teams = Teams
	                    }
                    };
            }
            return competitions;
        }
        static List<Competition> competitions;
    }
}
