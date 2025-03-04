﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Context;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250304232046_ThirdCreate")]
    partial class ThirdCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.30");

            modelBuilder.Entity("Domain.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Destiny")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TripStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TruckerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TruckerId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Viaje de ...",
                            Destiny = "CABA, Buenos Aires",
                            Source = "Rosario, Santa Fe",
                            TripStatus = 0,
                            TruckerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Viaje de ...",
                            Destiny = "Bariloche, Rio Negro",
                            Source = "Arroyo Seco, Buenos Aires",
                            TripStatus = 1,
                            TruckerId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Viaje de ...",
                            Destiny = "Carlos Paz, Cordoba",
                            Source = "Rosario, Santa Fe",
                            TripStatus = 2,
                            TruckerId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Trucker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompleteName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<int>("Roles")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TruckerType")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Truckers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompleteName = "Juan Gomez",
                            Roles = 3,
                            TruckerType = "Carga Seca"
                        },
                        new
                        {
                            Id = 2,
                            CompleteName = "Martin Suarez",
                            Roles = 3,
                            TruckerType = "Autos"
                        },
                        new
                        {
                            Id = 3,
                            CompleteName = "Agustin Ramirez",
                            Roles = 3,
                            TruckerType = "Ganaderia"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Roles")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gabriel",
                            Password = "1234",
                            Roles = 0,
                            UserName = "gabriel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fernando",
                            Password = "1234",
                            Roles = 1,
                            UserName = "fernando"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sara",
                            Password = "1234",
                            Roles = 2,
                            UserName = "sara"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Trip", b =>
                {
                    b.HasOne("Domain.Entities.Trucker", "Trucker")
                        .WithMany("Trips")
                        .HasForeignKey("TruckerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trucker");
                });

            modelBuilder.Entity("Domain.Entities.Trucker", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
