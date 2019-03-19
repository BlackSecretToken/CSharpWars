﻿// <auto-generated />
using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSharpWars.DataAccess.Migrations
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(CSharpWarsDbContext))]
    partial class CSharpWarsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview3.19153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSharpWars.Model.Bot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentHealth");

                    b.Property<int>("CurrentStamina");

                    b.Property<int>("FromX");

                    b.Property<int>("FromY");

                    b.Property<int>("LastAttackX");

                    b.Property<int>("LastAttackY");

                    b.Property<int>("MaximumHealth");

                    b.Property<int>("MaximumStamina");

                    b.Property<string>("Memory");

                    b.Property<int>("Move");

                    b.Property<string>("Name");

                    b.Property<int>("Orientation");

                    b.Property<Guid?>("PlayerId");

                    b.Property<int>("SysId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TimeOfDeath");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("PlayerId");

                    b.HasIndex("SysId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("BOTS");
                });

            modelBuilder.Entity("CSharpWars.Model.BotScript", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Script");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("BOTS");
                });

            modelBuilder.Entity("CSharpWars.Model.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hashed");

                    b.Property<string>("Name");

                    b.Property<string>("Salt");

                    b.Property<int>("SysId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("SysId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("PLAYERS");
                });

            modelBuilder.Entity("CSharpWars.Model.Bot", b =>
                {
                    b.HasOne("CSharpWars.Model.Player", "Player")
                        .WithMany("Bots")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("CSharpWars.Model.BotScript", b =>
                {
                    b.HasOne("CSharpWars.Model.Bot")
                        .WithOne()
                        .HasForeignKey("CSharpWars.Model.BotScript", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}