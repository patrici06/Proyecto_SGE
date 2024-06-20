using Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace Repositorios;

    public class DataContext : DbContext
{

        public DataContext(){}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Tramite> Tramites { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlite($"Data Source=SGE.sqlite");
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tramite>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Contenido).IsRequired();
                entity.Property(t => t.FechaHoraCreacion).IsRequired();
                entity.Property(t => t.FechaHoraUltimaModificacion).IsRequired();
                entity.Property(t => t.ExpedienteId).IsRequired();
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Caratula).IsRequired();
                entity.Property(e => e.FechaCreacion).IsRequired();
                entity.Property(e => e.FechaModificacion).IsRequired();
                entity.Property(e => e.IdUsuarioModificacion).IsRequired();
                entity.Property(e => e.Estado).IsRequired();

                entity.HasMany<Tramite>()
                      .WithOne()
                      .HasForeignKey(t => t.ExpedienteId);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.nombre).IsRequired();
                entity.Property(u => u.apellido).IsRequired();
                entity.Property(u => u.correo).IsRequired();
                entity.Property(u => u.contrasena).IsRequired();
                entity.Property(u => u.permisos).IsRequired(false);
            });
        }
    }
