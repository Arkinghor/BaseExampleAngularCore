﻿// <auto-generated />
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DataAccess.Migrations
{
    [DbContext(typeof(TripDBContext))]
    partial class TripDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssetValue");

                    b.Property<int>("TripId");

                    b.HasKey("AssetId");

                    b.HasIndex("TripId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("DataAccess.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Date");

                    b.Property<string>("HotelName");

                    b.Property<int>("HowLong");

                    b.Property<string>("Price");

                    b.Property<string>("Region");

                    b.HasKey("TripId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("DataAccess.Models.Asset", b =>
                {
                    b.HasOne("DataAccess.Models.Trip", "Trip")
                        .WithMany("Assets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
