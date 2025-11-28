using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoFinal.Models;

public class Vehicle
{
    [Key]
    public Guid Id { get; set; }
    public string Plate { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Status { get; set; } = "Active";

    public Guid ModelId { get; set; }
    [ForeignKey("ModelId")]
    public Model? Model { get; set; }

    public Guid DriverId { get; set; }
    [ForeignKey("DriverId")]
    [JsonIgnore]
    public Driver? Driver { get; set; }
}