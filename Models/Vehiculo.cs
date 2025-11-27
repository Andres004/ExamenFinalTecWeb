using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Vehiculo
    {
        public Guid Id { get; set; }  

        [Required, MaxLength(15)]
        public string Placa { get; set; } = default!;

        [Required, MaxLength(30)]
        public string Color { get; set; } = default!;

        [Required, MaxLength(20)]
        public string Estado { get; set; } = "Activo";

        [Required]
        public Guid ModeloId { get; set; }
        public Modelo Modelo { get; set; } = default!;

        public ICollection<DriverVehiculo>? DriverVehiculos { get; set; }
    }
}
