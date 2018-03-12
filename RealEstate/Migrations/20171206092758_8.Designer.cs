﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RealEstate.Data;
using RealEstate.Models;
using System;

namespace RealEstate.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    [Migration("20171206092758_8")]
    partial class _8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealEstate.Models.Advertisement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("AirConditioner");

                    b.Property<bool?>("Animals");

                    b.Property<int>("Apartment");

                    b.Property<bool>("Balcony");

                    b.Property<double?>("CeilingHeight");

                    b.Property<string>("City");

                    b.Property<int?>("ConstructionYear");

                    b.Property<int>("Cost");

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("Decoration");

                    b.Property<string>("Description");

                    b.Property<string>("District");

                    b.Property<DateTime>("EditDate");

                    b.Property<bool>("Elevator");

                    b.Property<int>("Floor");

                    b.Property<bool?>("Fridge");

                    b.Property<bool?>("Furniture");

                    b.Property<int>("House");

                    b.Property<string>("Housing");

                    b.Property<bool?>("Internet");

                    b.Property<double>("KitchenArea");

                    b.Property<bool?>("KitchenFurniture");

                    b.Property<double>("LivingArea");

                    b.Property<string>("Phone");

                    b.Property<string>("Region");

                    b.Property<int>("RoomsNumber");

                    b.Property<bool?>("Stove");

                    b.Property<string>("Street");

                    b.Property<bool?>("Students");

                    b.Property<bool?>("TV");

                    b.Property<double>("TotalArea");

                    b.Property<int>("TotalFloors");

                    b.Property<int>("Type");

                    b.Property<int>("UserID");

                    b.Property<int?>("WC");

                    b.Property<int?>("WallMaterial");

                    b.Property<bool?>("WashingMachine");

                    b.HasKey("ID");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("RealEstate.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Area");

                    b.Property<string>("Name");

                    b.Property<string>("Region");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RealEstate.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
