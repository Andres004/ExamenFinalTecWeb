using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.DTOS.Vehicle;

public class CreateVehicleDto
{
    [Required]
    public string Plate { get; set; } = string.Empty;

    [Required]
    public string Color { get; set; } = string.Empty;

    public string Status { get; set; } = "Active";

    [Required]
    public Guid ModelId { get; set; }

    [Required]
    public Guid DriverId { get; set; }
}