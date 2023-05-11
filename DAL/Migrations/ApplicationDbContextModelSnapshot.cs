﻿// <auto-generated />
using System;
using DAL.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Doman.Models.Category.BreakFast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BreakFasts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7dd9f4ab-7200-45fb-8c2d-aa6b48bb2932"),
                            Create = new DateTime(2023, 5, 11, 14, 43, 54, 996, DateTimeKind.Local).AddTicks(3942),
                            Description = "ssss",
                            Name = "sssss"
                        });
                });

            modelBuilder.Entity("DAL.Doman.Models.Category.Dessert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Desserts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("584bc7ec-551a-432c-9903-0ea7607dabc2"),
                            Create = new DateTime(2023, 5, 11, 14, 43, 54, 996, DateTimeKind.Local).AddTicks(3958),
                            Description = "ssss",
                            Name = "sssss"
                        });
                });

            modelBuilder.Entity("DAL.Doman.Models.Category.Dinner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Dinner");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8440829d-ab09-4746-9e41-a44bf90d39ab"),
                            Created = new DateTime(2023, 5, 11, 14, 43, 54, 996, DateTimeKind.Local).AddTicks(3768),
                            Discription = " ssss",
                            Name = "dd"
                        });
                });

            modelBuilder.Entity("DAL.Doman.Models.Category.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("451cb4b3-4a25-4902-a5ad-2622afb1d09d"),
                            Name = "sssss",
                            Size = "10"
                        });
                });

            modelBuilder.Entity("DAL.Doman.Models.Category.Lunch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create")
                        .HasColumnType("datetime2");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Lunch");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d8d698e1-a0c0-4966-8d32-0d583caa2c0b"),
                            Create = new DateTime(2023, 5, 11, 14, 43, 54, 996, DateTimeKind.Local).AddTicks(3913),
                            Discription = "ssss",
                            Name = "sssss"
                        });
                });

            modelBuilder.Entity("DAL.Doman.Models.Category.Soda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sodas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e1ac0d7-32d0-45a9-b039-7f92c358800e"),
                            Name = "sssss",
                            Size = "10"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
