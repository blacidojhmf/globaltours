﻿// <auto-generated />
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Datos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220330223634_InicialMigracion")]
    partial class InicialMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Core.Entidades.Lugar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("GastoAproximado")
                        .HasColumnType("double");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("PaisId");

                    b.ToTable("Lugar");
                });

            modelBuilder.Entity("Core.Entidades.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Core.Entidades.Lugar", b =>
                {
                    b.HasOne("Core.Entidades.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Pais");
                });
#pragma warning restore 612, 618
        }
    }
}
