﻿// <auto-generated />
using System;
using LogisticsAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogisticsAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240505140836_addedcolumns")]
    partial class addedcolumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogisticsAPI.Models.JobDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdviceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CraftName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PilotCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ServiceRequestTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TugLetGoLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TugPickUpLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VesselName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobDetails");
                });

            modelBuilder.Entity("LogisticsAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("ShiftDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LogisticsAPI.Models.Vessel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Beam")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Callsign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Draft")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GrossTonnage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("LengthOverall")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VesselId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VesselName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vessels");
                });
#pragma warning restore 612, 618
        }
    }
}
