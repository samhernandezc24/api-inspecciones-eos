﻿// <auto-generated />
using System;
using API.Inspecciones.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Inspecciones.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("inspeccion")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Inspecciones.Models.FormularioTipo", b =>
                {
                    b.Property<string>("IdFormularioTipo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.HasKey("IdFormularioTipo");

                    b.ToTable("FormulariosTipos", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.Inspeccion", b =>
                {
                    b.Property<string>("IdInspeccion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Folio")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInspeccion");

                    b.HasIndex("Folio")
                        .IsUnique()
                        .HasFilter("[Folio] IS NOT NULL");

                    b.ToTable("Inspecciones", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionCategoria", b =>
                {
                    b.Property<string>("IdInspeccionCategoria")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdInspeccion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionFolio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInspeccionCategoria");

                    b.HasIndex("IdInspeccion");

                    b.ToTable("InspeccionesCategorias", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionCategoriaItem", b =>
                {
                    b.Property<string>("IdInspeccionCategoriaItem")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormularioTipoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormularioValor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdFormularioTipo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdInspeccion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdInspeccionCategoria")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionCategoriaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInspeccionCategoriaItem");

                    b.HasIndex("IdFormularioTipo");

                    b.HasIndex("IdInspeccion");

                    b.HasIndex("IdInspeccionCategoria");

                    b.ToTable("InspeccionesCategoriasItems", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidad", b =>
                {
                    b.Property<string>("IdInspeccionUnidad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnioEquipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Capacidad")
                        .HasColumnType("decimal(15,3)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInspeccionFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInspeccionFinalUpdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInspeccionInicial")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInspeccionInicialUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirmaOperador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirmaVerificador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Folio")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Horometro")
                        .HasColumnType("int");

                    b.Property<string>("IdBase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdInspeccion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdInspeccionUnidadEstatus")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdRequerimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUnidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUnidadMarca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUnidadPlacaTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUserInspeccionFinal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUserInspeccionInicial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionFolio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionUnidadEstatusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUnidadTemporal")
                        .HasColumnType("bit");

                    b.Property<string>("Locacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Odometro")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequerimientoFolio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPlataforma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadMarcaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadNumeroEconomico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadPlacaTipoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserInspeccionFinalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserInspeccionInicialName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInspeccionUnidad");

                    b.HasIndex("Folio")
                        .IsUnique()
                        .HasFilter("[Folio] IS NOT NULL");

                    b.HasIndex("IdInspeccion");

                    b.HasIndex("IdInspeccionUnidadEstatus");

                    b.ToTable("InspeccionesUnidades", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadCategoria", b =>
                {
                    b.Property<string>("IdInspeccionUnidadCategoria")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdInspeccionUnidad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionUnidadFolio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInspeccionUnidadCategoria");

                    b.HasIndex("IdInspeccionUnidad");

                    b.ToTable("InspeccionesUnidadesCategorias", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadCategoriaItem", b =>
                {
                    b.Property<string>("IdInspeccionUnidadCategoriaItem")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormularioTipoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormularioValor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdFormularioTipo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdInspeccionUnidad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdInspeccionUnidadCategoria")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionUnidadCategoriaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionUnidadFolio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInspeccionUnidadCategoriaItem");

                    b.HasIndex("IdFormularioTipo");

                    b.HasIndex("IdInspeccionUnidad");

                    b.HasIndex("IdInspeccionUnidadCategoria");

                    b.ToTable("InspeccionesUnidadesCategoriasItems", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadEstatus", b =>
                {
                    b.Property<string>("IdInspeccionUnidadEstatus")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.HasKey("IdInspeccionUnidadEstatus");

                    b.ToTable("InspeccionesUnidadesEstatus", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadFichero", b =>
                {
                    b.Property<string>("IdInspeccionUnidadFichero")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdInspeccionUnidad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspeccionUnidadFolio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInspeccionUnidadFichero");

                    b.HasIndex("IdInspeccionUnidad");

                    b.ToTable("InspeccionesUnidadesFicheros", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.Unidad", b =>
                {
                    b.Property<string>("IdUnidad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnioEquipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Capacidad")
                        .HasColumnType("decimal(15,3)");

                    b.Property<DateTime>("CreatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Horometro")
                        .HasColumnType("int");

                    b.Property<string>("IdBase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUnidadMarca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUnidadPlacaTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUnidadTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroEconomico")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Odometro")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadMarcaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadPlacaTipoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadTipoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUnidad");

                    b.HasIndex("NumeroEconomico")
                        .IsUnique()
                        .HasFilter("[NumeroEconomico] IS NOT NULL");

                    b.ToTable("Unidades", "inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionCategoria", b =>
                {
                    b.HasOne("API.Inspecciones.Models.Inspeccion", "Inspeccion")
                        .WithMany("InspeccionesCategorias")
                        .HasForeignKey("IdInspeccion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Inspeccion");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionCategoriaItem", b =>
                {
                    b.HasOne("API.Inspecciones.Models.FormularioTipo", "FormularioTipo")
                        .WithMany("InspeccionesCategoriasItems")
                        .HasForeignKey("IdFormularioTipo")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("API.Inspecciones.Models.Inspeccion", "Inspeccion")
                        .WithMany("InspeccionesCategoriasItems")
                        .HasForeignKey("IdInspeccion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("API.Inspecciones.Models.InspeccionCategoria", "InspeccionCategoria")
                        .WithMany("InspeccionesCategoriasItems")
                        .HasForeignKey("IdInspeccionCategoria")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FormularioTipo");

                    b.Navigation("Inspeccion");

                    b.Navigation("InspeccionCategoria");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidad", b =>
                {
                    b.HasOne("API.Inspecciones.Models.Inspeccion", "Inspeccion")
                        .WithMany("InspeccionesUnidades")
                        .HasForeignKey("IdInspeccion")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("API.Inspecciones.Models.InspeccionUnidadEstatus", "InspeccionUnidadEstatus")
                        .WithMany("InspeccionesUnidades")
                        .HasForeignKey("IdInspeccionUnidadEstatus")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Inspeccion");

                    b.Navigation("InspeccionUnidadEstatus");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadCategoria", b =>
                {
                    b.HasOne("API.Inspecciones.Models.InspeccionUnidad", "InspeccionUnidad")
                        .WithMany("InspeccionesUnidadesCategorias")
                        .HasForeignKey("IdInspeccionUnidad")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("InspeccionUnidad");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadCategoriaItem", b =>
                {
                    b.HasOne("API.Inspecciones.Models.FormularioTipo", "FormularioTipo")
                        .WithMany("InspeccionesUnidadesCategoriasItems")
                        .HasForeignKey("IdFormularioTipo")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("API.Inspecciones.Models.InspeccionUnidad", "InspeccionUnidad")
                        .WithMany("InspeccionesUnidadesCategoriasItems")
                        .HasForeignKey("IdInspeccionUnidad")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("API.Inspecciones.Models.InspeccionUnidadCategoria", "InspeccionUnidadCategoria")
                        .WithMany("InspeccionesUnidadesCategoriasItems")
                        .HasForeignKey("IdInspeccionUnidadCategoria")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FormularioTipo");

                    b.Navigation("InspeccionUnidad");

                    b.Navigation("InspeccionUnidadCategoria");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadFichero", b =>
                {
                    b.HasOne("API.Inspecciones.Models.InspeccionUnidad", "InspeccionUnidad")
                        .WithMany("InspeccionesUnidadesFicheros")
                        .HasForeignKey("IdInspeccionUnidad")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("InspeccionUnidad");
                });

            modelBuilder.Entity("API.Inspecciones.Models.FormularioTipo", b =>
                {
                    b.Navigation("InspeccionesCategoriasItems");

                    b.Navigation("InspeccionesUnidadesCategoriasItems");
                });

            modelBuilder.Entity("API.Inspecciones.Models.Inspeccion", b =>
                {
                    b.Navigation("InspeccionesCategorias");

                    b.Navigation("InspeccionesCategoriasItems");

                    b.Navigation("InspeccionesUnidades");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionCategoria", b =>
                {
                    b.Navigation("InspeccionesCategoriasItems");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidad", b =>
                {
                    b.Navigation("InspeccionesUnidadesCategorias");

                    b.Navigation("InspeccionesUnidadesCategoriasItems");

                    b.Navigation("InspeccionesUnidadesFicheros");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadCategoria", b =>
                {
                    b.Navigation("InspeccionesUnidadesCategoriasItems");
                });

            modelBuilder.Entity("API.Inspecciones.Models.InspeccionUnidadEstatus", b =>
                {
                    b.Navigation("InspeccionesUnidades");
                });
#pragma warning restore 612, 618
        }
    }
}
