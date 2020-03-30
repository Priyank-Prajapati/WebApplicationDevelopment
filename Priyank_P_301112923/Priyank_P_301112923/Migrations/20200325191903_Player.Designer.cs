﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Priyank_P_301112923.Models;
using System;

namespace Priyank_P_301112923.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200325191903_Player")]
    partial class Player
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Priyank_P_301112923.Models.Club", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<int>("MatchesPlayed");

                    b.Property<string>("Name");

                    b.Property<int>("NoPlayers");

                    b.Property<string>("Partners");

                    b.Property<string>("Website");

                    b.HasKey("ID");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Priyank_P_301112923.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Club");

                    b.Property<string>("Country");

                    b.Property<string>("FieldName");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
