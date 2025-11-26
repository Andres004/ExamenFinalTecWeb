using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Vehiculo
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Marca { get; set; } = default!;

        [Required]
        [MaxLength(80)]
        public string Modelo { get; set; } = default!;

        [Required]
        [MaxLength(15)]
        public string Placa { get; set; } = default!;

        [Range(1980, 2100)]
        public int Anio { get; set; }

        [Required]
        [MaxLength(20)]
        public string Estado { get; set; } = "Activo"; // Activo / Inactivo

        // Relación N:M con Driver (lado Vehiculo)
        public ICollection<DriverVehiculo>? DriverVehiculos { get; set; }
    }
}