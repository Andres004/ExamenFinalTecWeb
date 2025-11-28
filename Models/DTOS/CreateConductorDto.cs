using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.DTOS
{
    public class CreateConductorDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Licencia { get; set; } = string.Empty;
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = "Conductor";
    }
}
