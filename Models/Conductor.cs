namespace ProyectoFinal.Models
{
    public class Conductor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "Conductor";//"Pasajero" | "Conductor"
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }
        public DateTime? RefreshTokenRevokedAt { get; set; }
        public string? CurrentJwtId { get; set; }



        // 1:N Conductor -> Viajes
        public ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();

        // N:M Conductor <-> Vehiculos
    }
}
