using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Modelo
    {
        public Guid Id { get; set; }  

        [Required, MaxLength(80)]
        public string Marca { get; set; } = default!;   

        [Required, MaxLength(80)]
        public string Nombre { get; set; } = default!;  

        [Range(1980, 2100)]
        public int Anio { get; set; }


        public Vehiculo Vehiculo { get; set; } = default!;
    }
}
