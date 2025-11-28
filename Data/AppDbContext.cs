using CleanTransportAPI.Models;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace CleanTransportAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Trip> Trips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Passenger)
            .WithMany(p => p.Trips)
            .HasForeignKey(t => t.PassengerId)
            .OnDelete(DeleteBehavior.Restrict); 

        
        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Driver)
            .WithMany(d => d.Trips)
            .HasForeignKey(t => t.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

      
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Driver)
            .WithMany(d => d.Vehicles)
            .HasForeignKey(v => v.DriverId)
            .OnDelete(DeleteBehavior.Cascade); 

       
        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.Model)
            .WithMany(m => m.Vehicles)
            .HasForeignKey(v => v.ModelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}