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
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<DriverVehiculo> DriverVehiculos => Set<DriverVehiculo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Origen).IsRequired().HasMaxLength(100);
                entity.Property(v => v.Destino).IsRequired().HasMaxLength(100);
                entity.Property(v => v.FechaSalida).IsRequired();
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
        }
    }
}
