using Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace Repositorios
{
    public class DataContext : DbContext
    {
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Tramite> Tramites { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string relativePath = Path.Combine("Repositorios", "SGE.sqlite");
            string absolutePath = Path.GetFullPath(relativePath);
            optionsBuilder.UseSqlite($"Data Source={absolutePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración adicional del modelo si es necesario
            modelBuilder.Entity<Tramite>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Contenido).IsRequired();
                entity.Property(t => t.FechaHoraCreacion).IsRequired();
                entity.Property(t => t.FechaHoraUltimaModificacion).IsRequired();
                entity.Property(t => t.ExpedienteId).IsRequired();

                entity.HasOne(t => t.Expediente)
                       .WithMany(e => e.Tramites)
                       .HasForeignKey(t => t.ExpedienteId);
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Caratula).IsRequired(false);
                entity.Property(e => e.FechaCreacion).IsRequired(false);
                entity.Property(e => e.FechaModificacion).IsRequired(false);
                entity.Property(e => e.IdUsuarioModificacion).IsRequired(false);
                entity.Property(e => e.Estado).IsRequired(false);

                entity.HasMany(e => e.Tramites)
                       .WithOne(t => t.Expediente)
                       .HasForeignKey(t => t.ExpedienteId);
             });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.id);
                entity.Property(u => u.nombre).IsRequired();
                entity.Property(u => u.apellido).IsRequired();
                entity.Property(u => u.correo).IsRequired();
                entity.Property(u => u.contraseñia).IsRequired();
                entity.Property(u => u.permisos).IsRequired();
            });
        }
    }
}
