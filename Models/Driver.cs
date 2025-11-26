using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Driver
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; } = default!;

        [Required]
        [MaxLength(30)]
        public string Licencia { get; set; } = default!;

        // N:M con Vehiculo (lado Driver)
        public ICollection<DriverVehiculo>? DriverVehiculos { get; set; }
    }
}
