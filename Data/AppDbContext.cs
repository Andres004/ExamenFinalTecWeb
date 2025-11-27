using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Viaje> Viajes => Set<Viaje>();
        public DbSet<Conductor> Conductores => Set<Conductor>();
        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
        public DbSet<Modelo> Modelos => Set<Modelo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Origen).IsRequired().HasMaxLength(100);
                entity.Property(v => v.Destino).IsRequired().HasMaxLength(100);
                entity.Property(v => v.FechaSolicitud).IsRequired();
                entity.Property(v => v.FechaFinalizacion).IsRequired();
                entity.Property(v => v.Precio).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(v => v.Estado).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Licencia).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Telefono).IsRequired().HasMaxLength(15);
            });

           
            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Marca).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Placa).IsRequired().HasMaxLength(20);
                entity.Property(v => v.Color).IsRequired().HasMaxLength(30);
                entity.Property(v => v.Estado).IsRequired().HasMaxLength(30);
            });

            // 1:N Conductor -> Viajes
            modelBuilder.Entity<Viaje>()
                .HasOne(v => v.Conductor)
                .WithMany(c => c.Viajes)
                .HasForeignKey(v => v.ConductorId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N Conductor -> Vehiculos
            modelBuilder.Entity<Conductor>()
                .HasMany(c => c.Vehiculos)
                .WithOne(v => v.Conductor)
                .HasForeignKey(v => v.ConductorId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:1 Modelo -> Vehiculo (un modelo, un vehículo)
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Modelo)
                .WithOne(m => m.Vehiculo)
                .HasForeignKey<Vehiculo>(v => v.ModeloId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
