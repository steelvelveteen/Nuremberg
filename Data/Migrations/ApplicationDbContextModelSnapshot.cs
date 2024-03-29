﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nuremberg.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Nuremberg.Models.TestModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("TestModelName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TestModelOtherProp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TestModels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("382ef73d-e794-42a1-947c-01e6f25d8c12"),
                            TestModelName = "First name",
                            TestModelOtherProp = "Some other property name"
                        },
                        new
                        {
                            Id = new Guid("19fa43c7-1498-4803-8017-e4af79ef08da"),
                            TestModelName = "Sec name",
                            TestModelOtherProp = "Some sec property name"
                        },
                        new
                        {
                            Id = new Guid("c2300b30-d6bf-4e04-a6ac-2bb5beae3090"),
                            TestModelName = "Tres name",
                            TestModelOtherProp = "Some tres property name"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
