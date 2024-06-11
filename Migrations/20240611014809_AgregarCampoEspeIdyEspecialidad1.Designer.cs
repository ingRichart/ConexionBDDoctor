﻿// <auto-generated />
using System;
using CRUD_Students2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUD_Students2.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240611014809_AgregarCampoEspeIdyEspecialidad1")]
    partial class AgregarCampoEspeIdyEspecialidad1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRUD_Students2.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<Guid?>("EspecialidadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("CRUD_Students2.Entities.Especialidad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Especialidad1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Operacion")
                        .HasColumnType("int");

                    b.Property<int>("TiempoOpera")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("CRUD_Students2.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Carrera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CRUD_Students2.Entities.Doctor", b =>
                {
                    b.HasOne("CRUD_Students2.Entities.Especialidad", "Especialidad")
                        .WithMany("Doctors")
                        .HasForeignKey("EspecialidadId");

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("CRUD_Students2.Entities.Especialidad", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}