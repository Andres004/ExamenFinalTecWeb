using ProyectoFinal.Models.DTOS.Driver;

namespace ProyectoFinal.Services;

public interface IDriverService
{
    Task<IEnumerable<DriverResponseDto>> GetAllAsync();
    Task<DriverResponseDto?> GetByIdAsync(Guid id);
    Task<DriverResponseDto> UpdateAsync(Guid id, UpdateDriverDto dto);
    Task DeleteAsync(Guid id);
}