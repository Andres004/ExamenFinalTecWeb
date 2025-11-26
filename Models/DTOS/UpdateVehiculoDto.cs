namespace ProyectoFinal.Models.DTOS
{
    public class UpdateVehicleDto
    {
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Estado { get; set; }
        public int? Anio { get; set; }
    }
}