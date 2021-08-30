﻿// <auto-generated />
using System;
using Condominio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Condominio.API.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210830000845_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Condominio.Domain.Entities.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Condominio.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8c7d9894-c8a6-4f68-8f6a-fe4093792e54"),
                            Name = "Renzo"
                        },
                        new
                        {
                            Id = new Guid("b7a26d73-50b1-4acd-acd2-e353502024d6"),
                            Name = "Rodrigo"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
