﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Soccernation.Models;
using System;

namespace Soccernation.Migrations
{
    [DbContext(typeof(SoccernationContext))]
    [Migration("20180508123156_4")]
    partial class _4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Soccernation.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaCode");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name");

                    b.Property<Guid?>("StateId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Soccernation.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CityId");

                    b.Property<string>("ContactNumber");

                    b.Property<Guid?>("ContinentId");

                    b.Property<Guid?>("CountryId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<string>("Email");

                    b.Property<string>("ExtraContactNumber");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.Property<Guid?>("StateId");

                    b.Property<string>("Status");

                    b.Property<string>("StreetName");

                    b.Property<string>("Suburb");

                    b.Property<int>("UnitNumber");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ContinentId");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Soccernation.Models.Competition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompanyId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("EndDateUtc");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<bool>("IsTwoLeggedTie");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDateUtc");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<string>("Status");

                    b.Property<decimal?>("SubscriptionPrice");

                    b.Property<string>("TypeOfCompetition");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Soccernation.Models.CompetitionsCourts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompetitionId");

                    b.Property<Guid>("CourtId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("CourtId");

                    b.ToTable("CompetitionsCourts");
                });

            modelBuilder.Entity("Soccernation.Models.CompetitionsTeams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompetitionId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<bool>("HasPaid");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Status");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("TeamId");

                    b.ToTable("CompetitionsTeams");
                });

            modelBuilder.Entity("Soccernation.Models.Continent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("Soccernation.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ContinentId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Soccernation.Models.Court", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Status");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Courts");
                });

            modelBuilder.Entity("Soccernation.Models.Fixture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompetitionId");

                    b.Property<Guid?>("CourtId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("DateUtc");

                    b.Property<int>("Leg");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<int>("Round");

                    b.Property<string>("Status");

                    b.Property<Guid>("TeamHomeId");

                    b.Property<int>("TeamHomeScore");

                    b.Property<Guid>("TeamVisitorId");

                    b.Property<int>("TeamVisitorScore");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("CourtId");

                    b.HasIndex("TeamHomeId");

                    b.HasIndex("TeamVisitorId");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("Soccernation.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name");

                    b.Property<string>("Role");

                    b.Property<string>("Status");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Soccernation.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("AvatarLarge");

                    b.Property<string>("AvatarThumb");

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<string>("Gender");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Nationality");

                    b.Property<string>("PreferredPosition");

                    b.Property<string>("Status");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Soccernation.Models.Referee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Referees");
                });

            modelBuilder.Entity("Soccernation.Models.ResultRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompetitionId");

                    b.Property<int>("ConcedeForfeits");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<int>("Draws");

                    b.Property<int>("Forfeits");

                    b.Property<int>("GoalsAgainst");

                    b.Property<int>("GoalsFor");

                    b.Property<int>("Loses");

                    b.Property<int>("Matches");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<short>("Position");

                    b.Property<string>("Status");

                    b.Property<Guid?>("TeamId");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("TeamId");

                    b.ToTable("ResultRows");
                });

            modelBuilder.Entity("Soccernation.Models.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CountryId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Soccernation.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<string>("LogoImage");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Soccernation.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompanyId");

                    b.Property<DateTime>("CreatedOnUtc");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime?>("ExpireDateUtc");

                    b.Property<bool>("HasPremium");

                    b.Property<byte[]>("Key")
                        .IsRequired();

                    b.Property<byte[]>("KeySalt")
                        .IsRequired();

                    b.Property<DateTime?>("LastTimeLoginUtc");

                    b.Property<Guid?>("ManagerId");

                    b.Property<DateTime>("ModifiedOnUtc");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("PlayerId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Soccernation.Models.City", b =>
                {
                    b.HasOne("Soccernation.Models.State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("Soccernation.Models.Company", b =>
                {
                    b.HasOne("Soccernation.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Soccernation.Models.Continent", "Continent")
                        .WithMany()
                        .HasForeignKey("ContinentId");

                    b.HasOne("Soccernation.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Soccernation.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("Soccernation.Models.Competition", b =>
                {
                    b.HasOne("Soccernation.Models.Company")
                        .WithMany("Competitions")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Soccernation.Models.CompetitionsCourts", b =>
                {
                    b.HasOne("Soccernation.Models.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Soccernation.Models.Court", "Court")
                        .WithMany()
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Soccernation.Models.CompetitionsTeams", b =>
                {
                    b.HasOne("Soccernation.Models.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId");

                    b.HasOne("Soccernation.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Soccernation.Models.Country", b =>
                {
                    b.HasOne("Soccernation.Models.Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId");
                });

            modelBuilder.Entity("Soccernation.Models.Fixture", b =>
                {
                    b.HasOne("Soccernation.Models.Competition")
                        .WithMany("Fixtures")
                        .HasForeignKey("CompetitionId");

                    b.HasOne("Soccernation.Models.Court", "Court")
                        .WithMany()
                        .HasForeignKey("CourtId");

                    b.HasOne("Soccernation.Models.Team", "TeamHome")
                        .WithMany()
                        .HasForeignKey("TeamHomeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Soccernation.Models.Team", "TeamVisitor")
                        .WithMany()
                        .HasForeignKey("TeamVisitorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Soccernation.Models.Manager", b =>
                {
                    b.HasOne("Soccernation.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Soccernation.Models.Player", b =>
                {
                    b.HasOne("Soccernation.Models.Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Soccernation.Models.ResultRow", b =>
                {
                    b.HasOne("Soccernation.Models.Competition")
                        .WithMany("Results")
                        .HasForeignKey("CompetitionId");

                    b.HasOne("Soccernation.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Soccernation.Models.State", b =>
                {
                    b.HasOne("Soccernation.Models.Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Soccernation.Models.User", b =>
                {
                    b.HasOne("Soccernation.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Soccernation.Models.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("Soccernation.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}
