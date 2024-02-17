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
            modelBuilder.Entity<InspeccionCategoria>().HasOne(item => item.Inspeccion).WithMany(item => item.InspeccionesCategorias).HasForeignKey(x => x.IdInspeccion).OnDelete(DeleteBehavior.Restrict);

            // INSPECCIONES CATEGORIAS ITEMS
            modelBuilder.Entity<InspeccionCategoriaItem>().HasOne(item => item.Inspeccion).WithMany(item => item.InspeccionesCategoriasItems).HasForeignKey(x => x.IdInspeccion).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InspeccionCategoriaItem>().HasOne(item => item.InspeccionCategoria).WithMany(item => item.InspeccionesCategoriasItems).HasForeignKey(x => x.IdInspeccionCategoria).OnDelete(DeleteBehavior.Restrict);
        }

        // I
        public virtual DbSet<Inspeccion> Inspecciones { get; set; }
        public virtual DbSet<InspeccionCategoria> InspeccionesCategorias { get; set; }
        public virtual DbSet<InspeccionCategoriaItem> InspeccionesCategoriasItems { get; set; }

        // U
        public virtual DbSet<Unidad> Unidades { get; set; }
        public virtual DbSet<UnidadRegistro> UnidadesRegistros { get; set; }
    }
}
