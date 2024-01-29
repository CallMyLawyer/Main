﻿// <auto-generated />
using System;
using MehdiRahimiProject1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MehdiRahimiProject1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240124091336_busses payment")]
    partial class bussespayment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MehdiRahimiProject1.Classes.Buss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BussType")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SetTypeOfBuss")
                        .HasColumnType("int");

                    b.Property<int>("SoldTicketCount")
                        .HasColumnType("int");

                    b.Property<int>("SoldTicketPrice")
                        .HasColumnType("int");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Buss");
                });

            modelBuilder.Entity("MehdiRahimiProject1.Classes.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BussId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PassengerType")
                        .HasColumnType("int");

                    b.Property<int>("PassengersSeat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BussId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("MehdiRahimiProject1.Classes.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChooseTicketType")
                        .HasColumnType("int");

                    b.Property<int?>("PassengerId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("TicketName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("MehdiRahimiProject1.Classes.Passenger", b =>
                {
                    b.HasOne("MehdiRahimiProject1.Classes.Buss", null)
                        .WithMany()
                        .HasForeignKey("BussId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MehdiRahimiProject1.Classes.Ticket", b =>
                {
                    b.HasOne("MehdiRahimiProject1.Classes.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengerId");
                });
#pragma warning restore 612, 618
        }
    }
}
