namespace ProyectoFinal.Models.DTOS
{
    public class CreateVehicleDto
    {
        public string Marca { get; set; } = default!;
        public string Modelo { get; set; } = default!;
        public string Placa { get; set; } = default!;
        public int Anio { get; set; }
    }
}