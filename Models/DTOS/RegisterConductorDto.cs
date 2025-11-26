namespace ProyectoFinal.Models.DTOS
{
    public class RegisterConductorDto
    {
            public string Nombre { get; init; }
            public string Email { get; init; }
            public string Password { get; init; }
            public string Role { get; set; } = "Conductor";
    }
}

