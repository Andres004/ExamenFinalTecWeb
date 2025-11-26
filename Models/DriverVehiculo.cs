using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class DriverVehiculo
    {
        public Guid Id { get; set; }

        [Required]
        public Guid DriverId { get; set; }
        public Driver Driver { get; set; } = default!;

        [Required]
        public Guid VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; } = default!;

        public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
        public DateTime? FechaFin { get; set; }
    }
}