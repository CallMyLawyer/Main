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
    [Migration("20240123161318_BussAndPassenger")]
    partial class BussAndPassenger
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SetTypeOfBuss")
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

                    b.Property<int?>("BussId")
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

                    b.Property<string>("PassengersSeat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BussId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("MehdiRahimiProject1.Classes.Passenger", b =>
                {
                    b.HasOne("MehdiRahimiProject1.Classes.Buss", null)
                        .WithMany()
                        .HasForeignKey("BussId");
                });
#pragma warning restore 612, 618
        }
    }
}
