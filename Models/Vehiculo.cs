using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Vehiculo
    {
        public Guid Id { get; set; }  

        [Required]
        public string Placa { get; set; } = null!;

        [Required]
        public string Color { get; set; } = null!;

        [Required]
        public string Estado { get; set; } = null!;  

        // 1:1 con Modelo
        public Guid ModeloId { get; set; }
        public Modelo Modelo { get; set; } = null!;

        // 1:N con Conductor
        public Guid ConductorId { get; set; }
        public Conductor Conductor { get; set; } = null!;
    }
}
