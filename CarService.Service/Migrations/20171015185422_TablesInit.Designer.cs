﻿// <auto-generated />
using CarService.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CarService.Service.Migrations
{
    [DbContext(typeof(CarServiceContext))]
    [Migration("20171015185422_TablesInit")]
    partial class TablesInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarService.Service.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("CarService.Service.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Identification");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("CarService.Service.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Identification");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("CarService.Service.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int>("MechanicId");

                    b.Property<int>("PartnerId");

                    b.Property<DateTime>("Time");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("MechanicId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("TypeId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CarService.Service.ReservationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ReservationTypes");
                });

            modelBuilder.Entity("CarService.Service.Worksheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MechanicId");

                    b.Property<int>("PartnerId");

                    b.HasKey("Id");

                    b.HasIndex("MechanicId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Worksheets");
                });

            modelBuilder.Entity("CarService.Service.WorksheetMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaterialWorksheetId");

                    b.Property<int>("WorksheetMaterialId");

                    b.HasKey("Id");

                    b.HasIndex("MaterialWorksheetId");

                    b.HasIndex("WorksheetMaterialId");

                    b.ToTable("WorksheetMaterial");
                });

            modelBuilder.Entity("CarService.Service.Reservation", b =>
                {
                    b.HasOne("CarService.Service.Mechanic", "ReservationMechanic")
                        .WithMany("MechanicReservations")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarService.Service.Partner", "ReservationPartner")
                        .WithMany("PartnerReservations")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarService.Service.ReservationType", "Type")
                        .WithMany("TypeReservations")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarService.Service.Worksheet", b =>
                {
                    b.HasOne("CarService.Service.Mechanic", "WorksheetMechanic")
                        .WithMany("MechanicWorksheets")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarService.Service.Partner", "WorksheetPartner")
                        .WithMany("PartnerWorksheets")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarService.Service.WorksheetMaterial", b =>
                {
                    b.HasOne("CarService.Service.Material", "Material")
                        .WithMany("MaterialWorksheets")
                        .HasForeignKey("MaterialWorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarService.Service.Worksheet", "Worksheet")
                        .WithMany("WorksheetMaterials")
                        .HasForeignKey("WorksheetMaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
