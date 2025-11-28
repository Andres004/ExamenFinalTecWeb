using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Viaje> Viajes => Set<Viaje>();
        public DbSet<Conductor> Conductores => Set<Conductor>();
        public DbSet<Pasajero> Pasajeros => Set<Pasajero>();
        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
        public DbSet<Modelo> Modelos => Set<Modelo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Viaje - Conductor (N:1)
            modelBuilder.Entity<Viaje>()
            .HasOne(v => v.Conductor)
            .WithMany(c => c.Viajes)
            .HasForeignKey(v => v.ConductorId)
            .IsRequired()   // Un viaje debe tener si o si un conductor
            .OnDelete(DeleteBehavior.Restrict);

            // Relación Viaje - Pasajero (N:1)
            modelBuilder.Entity<Viaje>()
                .HasOne(v => v.Pasajero)
                .WithMany(p => p.Viajes)
                .HasForeignKey(v => v.PasajeroId)
                .IsRequired()   // Un viaje debe tener si o si un pasajero
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Conductor - Vehículo (1:N)
            modelBuilder.Entity<Conductor>()
                .HasMany(c => c.Vehiculos)
                .WithOne(v => v.Conductor)
                .HasForeignKey(v => v.ConductorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            // Relación  Vehículo - Modelo (1:1)
            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Modelo)
                .WithOne(m => m.Vehiculo)
                .HasForeignKey<Vehiculo>(v => v.ModeloId)
                .IsRequired() // vehículo debe tener SI O SI un modelo
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
