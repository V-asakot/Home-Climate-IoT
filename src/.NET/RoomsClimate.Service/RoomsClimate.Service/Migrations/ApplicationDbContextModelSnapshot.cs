﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RoomsClimate.Service.Data;

#nullable disable

namespace RoomsClimate.Service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RoomsClimate.Service.Data.Entities.ClimateMeasurment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DeviceId")
                        .HasColumnType("integer");

                    b.Property<float>("Humidity")
                        .HasColumnType("real");

                    b.Property<DateTime>("MeasurmentTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Measurments");
                });

            modelBuilder.Entity("RoomsClimate.Service.Data.Entities.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("DeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DeviceType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("RoomsClimate.Service.Data.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RoomGuid")
                        .HasColumnType("uuid");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RoomsClimate.Service.Data.Entities.ThermostatSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("DeviceGuid")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ThermostatName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("ThermostatValue")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DeviceGuid")
                        .IsUnique();

                    b.ToTable("ThermostatsSettings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            ThermostatName = "Default",
                            ThermostatValue = 24f
                        });
                });

            modelBuilder.Entity("RoomsClimate.Service.Data.Entities.ClimateMeasurment", b =>
                {
                    b.HasOne("RoomsClimate.Service.Data.Entities.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("RoomsClimate.Service.Data.Entities.Device", b =>
                {
                    b.HasOne("RoomsClimate.Service.Data.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("RoomsClimate.Service.Data.Entities.ThermostatSettings", b =>
                {
                    b.HasOne("RoomsClimate.Service.Data.Entities.Device", "Device")
                        .WithOne("ThermostatSettings")
                        .HasForeignKey("RoomsClimate.Service.Data.Entities.ThermostatSettings", "DeviceGuid")
                        .HasPrincipalKey("RoomsClimate.Service.Data.Entities.Device", "DeviceGuid");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("RoomsClimate.Service.Data.Entities.Device", b =>
                {
                    b.Navigation("ThermostatSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
