using ProyectoFinal.Models.DTOS.Vehicle;

namespace ProyectoFinal.Services;

public interface IVehicleService
{
    Task<IEnumerable<VehicleResponseDto>> GetAllAsync();
    Task<VehicleResponseDto?> GetByIdAsync(Guid id);
    Task<VehicleResponseDto> CreateAsync(CreateVehicleDto dto);
    Task<VehicleResponseDto> UpdateAsync(Guid id, UpdateVehicleDto dto);
    Task DeleteAsync(Guid id);
}