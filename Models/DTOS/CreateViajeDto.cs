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
        public string Estado { get; set; }
        public DateTime FechaSalida { get; set; }
        public int PasajeroId { get; set; }

    }
}
