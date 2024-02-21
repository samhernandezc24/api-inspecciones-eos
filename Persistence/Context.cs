using API.Inspecciones.Models;
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

            // INSPECCIONES
            modelBuilder.Entity<Inspeccion>().HasIndex(item => item.Folio).IsUnique();

            // INSPECCIONES CATEGORIAS
            modelBuilder.Entity<InspeccionCategoria>().HasOne(item => item.Inspeccion).WithMany(item => item.InspeccionesCategorias).HasForeignKey(item => item.IdInspeccion).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES CATEGORIAS ITEMS
            modelBuilder.Entity<InspeccionCategoriaItem>().HasOne(item => item.Inspeccion).WithMany(item => item.InspeccionesCategoriasItems).HasForeignKey(item => item.IdInspeccion).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InspeccionCategoriaItem>().HasOne(item => item.InspeccionCategoria).WithMany(item => item.InspeccionesCategoriasItems).HasForeignKey(item => item.IdInspeccionCategoria).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InspeccionCategoriaItem>().HasOne(item => item.FormularioTipo).WithMany(item => item.InspeccionesCategoriasItems).HasForeignKey(item => item.IdFormularioTipo).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES UNIDADES
            modelBuilder.Entity<InspeccionUnidad>().HasIndex(item => item.Folio).IsUnique();
            modelBuilder.Entity<InspeccionUnidad>().HasOne(item => item.Inspeccion).WithMany(item => item.InspeccionesUnidades).HasForeignKey(item => item.IdInspeccion).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InspeccionUnidad>().HasOne(item => item.InspeccionUnidadEstatus).WithMany(item => item.InspeccionesUnidades).HasForeignKey(item => item.IdInspeccionUnidadEstatus).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES UNIDADES CATEGORIAS
            modelBuilder.Entity<InspeccionUnidadCategoria>().HasOne(item => item.InspeccionUnidad).WithMany(item => item.InspeccionesUnidadesCategorias).HasForeignKey(item => item.IdInspeccionUnidad).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES UNIDADES CATEGORIAS ITEMS
            modelBuilder.Entity<InspeccionUnidadCategoriaItem>().HasOne(item => item.InspeccionUnidad).WithMany(item => item.InspeccionesUnidadesCategoriasItems).HasForeignKey(item => item.IdInspeccionUnidad).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InspeccionUnidadCategoriaItem>().HasOne(item => item.InspeccionUnidadCategoria).WithMany(item => item.InspeccionesUnidadesCategoriasItems).HasForeignKey(item => item.IdInspeccionUnidadCategoria).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InspeccionUnidadCategoriaItem>().HasOne(item => item.FormularioTipo).WithMany(item => item.InspeccionesUnidadesCategoriasItems).HasForeignKey(item => item.IdFormularioTipo).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES UNIDADES FICHEROS
            modelBuilder.Entity<InspeccionUnidadFichero>().HasOne(item => item.InspeccionUnidad).WithMany(item => item.InspeccionesUnidadesFicheros).HasForeignKey(item => item.IdInspeccionUnidad).OnDelete(DeleteBehavior.Restrict);

            // UNIDADES (TEMPORALES)
            modelBuilder.Entity<Unidad>().HasIndex(item => item.NumeroEconomico).IsUnique();
        }

        // F
        public virtual DbSet<FormularioTipo> FormulariosTipos {  get; set; }

        // I
        public virtual DbSet<Inspeccion> Inspecciones { get; set; }
        public virtual DbSet<InspeccionCategoria> InspeccionesCategorias { get; set; }
        public virtual DbSet<InspeccionCategoriaItem> InspeccionesCategoriasItems { get; set; }
        public virtual DbSet<InspeccionUnidad> InspeccionesUnidades { get; set; }
        public virtual DbSet<InspeccionUnidadCategoria> InspeccionesUnidadesCategorias { get; set; }
        public virtual DbSet<InspeccionUnidadCategoriaItem> InspeccionesUnidadesCategoriasItems { get; set; }
        public virtual DbSet<InspeccionUnidadEstatus> InspeccionesUnidadesEstatus { get; set; }
        public virtual DbSet<InspeccionUnidadFichero> InspeccionesUnidadesFicheros { get; set; }

        // U
        public virtual DbSet<Unidad> Unidades { get; set; }
    }
}
