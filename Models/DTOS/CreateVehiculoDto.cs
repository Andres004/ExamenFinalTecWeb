using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.DTOS
{
    public class CreateVehiculoDto
    {
        [Required]
        public string Placa { get; set; } = null!;

        [Required]
        public string Color { get; set; } = null!;

        [Required]
        public string Estado { get; set; } = "Activo";

        [Required]
        public int ModeloId { get; set; }

        [Required]
        public int ConductorId { get; set; }
    }
}