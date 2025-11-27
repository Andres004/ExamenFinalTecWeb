namespace ProyectoFinal.Models
{
    public class Modelo
    {
        public Guid Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Anio { get; set; }

        //relacion 1:1 Modelo -> Vehiculo
        public Vehiculo Vehiculo { get; set; } = default!;

    }
}
