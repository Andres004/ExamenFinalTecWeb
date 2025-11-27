using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Modelo
    {
        public Guid Id { get; set; }   

        [Required]
        public string Marca { get; set; } = null!;

        [Required]
        public string Nombre { get; set; } = null!;

        public int Año { get; set; }

        // Relación 1:1 con Vehiculo
        public Vehiculo? Vehiculo { get; set; }
    }
}
