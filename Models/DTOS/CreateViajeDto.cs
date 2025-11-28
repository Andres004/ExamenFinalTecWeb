using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.DTOS
{
    public class CreateViajeDto
    {
        [Required]
        public string Origen { get; set; }
        [Required]
        public string Destino { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public DateTime FechaSolicitud { get; set; }
        [Required]
        public DateTime FechaFinalizacion { get; set; }
        [Required]
        public int PasajeroId { get; set; }
        [Required]
        public int ConductorId { get; set; }

    }
}
