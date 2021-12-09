﻿// <auto-generated />
using System;
using EFCore.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.WebAPI.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20211208161950_remane_database")]
    partial class remane_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCore.WebAPI.Models.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<DateTime>("DtFinal")
                        .HasColumnType("datetime2")
                        .HasColumnName("final_date");

                    b.Property<DateTime>("DtStart")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("battle");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("hero");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.HeroBattle", b =>
                {
                    b.Property<int>("BattleId")
                        .HasColumnType("int")
                        .HasColumnName("battleid");

                    b.Property<int>("HeroId")
                        .HasColumnType("int")
                        .HasColumnName("heroid");

                    b.HasKey("BattleId", "HeroId");

                    b.HasIndex("HeroId");

                    b.ToTable("herobattle");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.SecretIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HeroId")
                        .HasColumnType("int")
                        .HasColumnName("heroid");

                    b.Property<int>("NameReal")
                        .HasColumnType("int")
                        .HasColumnName("namreal");

                    b.HasKey("Id");

                    b.HasIndex("HeroId")
                        .IsUnique();

                    b.ToTable("secretidentity");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HeroId")
                        .HasColumnType("int")
                        .HasColumnName("heroid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("weapon");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.HeroBattle", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Battle", "Battle")
                        .WithMany("HerosBattles")
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.WebAPI.Models.Hero", "Hero")
                        .WithMany("HeroesBattles")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Battle");

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.SecretIdentity", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Hero", "Hero")
                        .WithOne("Identity")
                        .HasForeignKey("EFCore.WebAPI.Models.SecretIdentity", "HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Weapon", b =>
                {
                    b.HasOne("EFCore.WebAPI.Models.Hero", "Hero")
                        .WithMany("Weapons")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Battle", b =>
                {
                    b.Navigation("HerosBattles");
                });

            modelBuilder.Entity("EFCore.WebAPI.Models.Hero", b =>
                {
                    b.Navigation("HeroesBattles");

                    b.Navigation("Identity")
                        .IsRequired();

                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
