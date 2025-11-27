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
            // 1:N Conductor -> Viajes (FK requerida, cascade)
            modelBuilder.Entity<Viaje>()
                .HasOne(v => v.Conductor)
                .WithMany(c => c.Viajes)
                .HasForeignKey(v => v.ConductorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Conductor>()
                .HasMany(c => c.Vehiculos)
                .WithOne(v => v.Conductor)
                .HasForeignKey(v => v.ConductorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehiculo>()
                .HasOne(v => v.Modelo)
                .WithOne()
                .HasForeignKey<Vehiculo>(v => v.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Modelo>()
                .HasOne(m => m.Vehiculo)
                .WithOne(v => v.Modelo)
                .HasForeignKey<Vehiculo>(v => v.ModeloId);
        }
    }
}
