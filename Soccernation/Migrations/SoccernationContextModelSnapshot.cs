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
    partial class SoccernationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Soccernation.Models.Competition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Soccernation.Models.CompetitionsTeams", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompetitionId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("HasPaid");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Status");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("TeamId");

                    b.ToTable("CompetitionsTeams");
                });

            modelBuilder.Entity("Soccernation.Models.Fixture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompetitionId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("Round");

                    b.Property<string>("Status");

                    b.Property<Guid>("TeamHomeId");

                    b.Property<int>("TeamHomeScore");

                    b.Property<Guid>("TeamVisitorId");

                    b.Property<int>("TeamVisitorScore");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("TeamHomeId");

                    b.HasIndex("TeamVisitorId");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("Soccernation.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("AvatarLarge");

                    b.Property<string>("AvatarThumb");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Soccernation.Models.ResultRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompetitionId");

                    b.Property<int>("ConcedeForfeits");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("Draws");

                    b.Property<int>("Forfeits");

                    b.Property<int>("GoalsAgainst");

                    b.Property<int>("GoalsFor");

                    b.Property<int>("Loses");

                    b.Property<int>("Matches");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<short>("Position");

                    b.Property<string>("Status");

                    b.Property<Guid?>("TeamId");

                    b.Property<int>("Wins");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("TeamId");

                    b.ToTable("ResultRows");
                });

            modelBuilder.Entity("Soccernation.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("LogoImage");

                    b.Property<DateTime>("ModifiedOn");

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

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<Guid?>("PlayerId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Users");
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

            modelBuilder.Entity("Soccernation.Models.Fixture", b =>
                {
                    b.HasOne("Soccernation.Models.Competition")
                        .WithMany("Fixtures")
                        .HasForeignKey("CompetitionId");

                    b.HasOne("Soccernation.Models.Team", "TeamHome")
                        .WithMany()
                        .HasForeignKey("TeamHomeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Soccernation.Models.Team", "TeamVisitor")
                        .WithMany()
                        .HasForeignKey("TeamVisitorId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("Soccernation.Models.User", b =>
                {
                    b.HasOne("Soccernation.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}
