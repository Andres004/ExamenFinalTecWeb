using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.DTOS.Trip;

public class CreateTripDto
{
    [Required]
    public string Origin { get; set; } = string.Empty;

    [Required]
    public string Destination { get; set; } = string.Empty;

    [Required]
    public decimal EstimatedPrice { get; set; }

    [Required]
    public Guid PassengerId { get; set; }
}