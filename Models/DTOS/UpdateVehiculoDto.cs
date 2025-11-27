using System;

namespace ProyectoFinal.Models.DTOS
{
    public class UpdateVehicleDto
    {
        public string? Color { get; set; }
        public string? Estado { get; set; }
        public Guid? ModeloId { get; set; }
        public Guid? ConductorId { get; set; }
    }
}
