using ProyectoFinal.Models.DTOS.Trip;

namespace ProyectoFinal.Services;

public interface ITripService
{
    Task<IEnumerable<TripResponseDto>> GetAllAsync();
    Task<TripResponseDto?> GetByIdAsync(Guid id);
    Task<TripResponseDto> CreateAsync(CreateTripDto dto);
}