namespace ProyectoFinal.Models.DTOS.Driver;

public class DriverResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string License { get; set; } = string.Empty;
}