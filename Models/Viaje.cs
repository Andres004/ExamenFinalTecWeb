using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Viaje
    {
        public Guid Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSalida { get; set; }

        //TODO: Relacion con Pasajero 1:M

        public int PasajeroId { get; set; }

        //public Pasajero Pasajero { get; set; } = default!;


    }
}
