﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkLookupAPI.Models;

namespace ParkLookupAPI.Migrations
{
    [DbContext(typeof(ParkLookupAPIContext))]
    [Migration("20220610154847_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ParkLookupAPI.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Jurisdiction")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Jurisdiction = "National",
                            Location = "Califonria",
                            Name = "Yosemite"
                        },
                        new
                        {
                            ParkId = 2,
                            Jurisdiction = "State",
                            Location = "Califonria",
                            Name = "Bidwell"
                        },
                        new
                        {
                            ParkId = 3,
                            Jurisdiction = "National",
                            Location = "Idaho & Wyoming",
                            Name = "YellowStone"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
