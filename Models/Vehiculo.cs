using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Vehiculo
    {
        public Guid Id { get; set; }
       
        [Required]
        [MaxLength(15)]
        public string Placa { get; set; } = default!;
       [Required, MaxLength(30)]
        public string Color { get; set; } = default!;
       [Required]
        [MaxLength(20)]
        public string Estado { get; set; } = "Activo"; // Activo / Inactivo

        // Relacion 1:1 Vehiculo -> Modelo
        [Required]
        public Guid ModeloId { get; set; }
        public Modelo Modelo { get; set; } = default!;

        // Relación N:M Vehiculo -> Conductor
        public Guid ConductorId { get; set; }
        public Conductor Conductor { get; set; } = default!;

        

    }
}
