﻿using API.Inspecciones.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Inspecciones.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("inspeccion");

            // INSPECCIONES TIPOS
            modelBuilder.Entity<InspeccionTipo>().HasIndex(item => item.Folio).IsUnique();

            // CATEGORIAS
            modelBuilder.Entity<Categoria>().HasOne(item => item.InspeccionTipo).WithMany(item => item.Categorias).HasForeignKey(item => item.IdInspeccionTipo).OnDelete(DeleteBehavior.Restrict);

            // CATEGORIAS ITEMS
            modelBuilder.Entity<CategoriaItem>().HasOne(item => item.InspeccionTipo).WithMany(item => item.CategoriasItems).HasForeignKey(item => item.IdInspeccionTipo).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CategoriaItem>().HasOne(item => item.Categoria).WithMany(item => item.CategoriasItems).HasForeignKey(item => item.IdCategoria).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CategoriaItem>().HasOne(item => item.FormularioTipo).WithMany(item => item.CategoriasItems).HasForeignKey(item => item.IdFormularioTipo).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES
            modelBuilder.Entity<Inspeccion>().HasIndex(item => item.Folio).IsUnique();
            modelBuilder.Entity<Inspeccion>().HasOne(item => item.InspeccionTipo).WithMany(item => item.Inspecciones).HasForeignKey(item => item.IdInspeccionTipo).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Inspeccion>().HasOne(item => item.InspeccionEstatus).WithMany(item => item.Inspecciones).HasForeignKey(item => item.IdInspeccionEstatus).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES CATEGORIAS
            modelBuilder.Entity<InspeccionCategoria>().HasOne(item => item.Inspeccion).WithMany(item => item.InspeccionesCategorias).HasForeignKey(item => item.IdInspeccion).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES CATEGORIAS ITEMS
            modelBuilder.Entity<InspeccionCategoriaItem>().HasOne(item => item.InspeccionUnidad).WithMany(item => item.InspeccionesCategoriasItems).HasForeignKey(item => item.IdInspeccion).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InspeccionCategoriaItem>().HasOne(item => item.InspeccionCategoria).WithMany(item => item.InspeccionesCategoriasItems).HasForeignKey(item => item.IdInspeccionCategoria).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InspeccionCategoriaItem>().HasOne(item => item.FormularioTipo).WithMany(item => item.InspeccionesCategoriasItems).HasForeignKey(item => item.IdFormularioTipo).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES FICHEROS
            modelBuilder.Entity<InspeccionFichero>().HasOne(item => item.Inspeccion).WithMany(item => item.InspeccionesFicheros).HasForeignKey(item => item.IdInspeccion).OnDelete(DeleteBehavior.Restrict);

            // UNIDADES (TEMPORALES)
            modelBuilder.Entity<Unidad>().HasIndex(item => item.NumeroEconomico).IsUnique();
        }

        // F
        public virtual DbSet<FormularioTipo> FormulariosTipos {  get; set; }

        // I
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<CategoriaItem> CategoriasItems { get; set; }
        public virtual DbSet<Inspeccion> Inspecciones { get; set; }
        public virtual DbSet<InspeccionCategoria> InspeccionesCategorias { get; set; }
        public virtual DbSet<InspeccionCategoriaItem> InspeccionesCategoriasItems { get; set; }
        public virtual DbSet<InspeccionEstatus> InspeccionesEstatus { get; set; }
        public virtual DbSet<InspeccionFichero> InspeccionesFicheros { get; set; }
        public virtual DbSet<InspeccionTipo> InspeccionesTipos { get; set; }

        // U
        public virtual DbSet<Unidad> Unidades { get; set; }
    }
}
