using ProyectoFinal.Models.DTOS.Passenger;

namespace ProyectoFinal.Services;

public interface IPassengerService
{
    Task<IEnumerable<PassengerResponseDto>> GetAllAsync();
    Task<PassengerResponseDto?> GetByIdAsync(Guid id);
    Task<PassengerResponseDto> UpdateAsync(Guid id, UpdatePassengerDto dto);
    Task DeleteAsync(Guid id);
}