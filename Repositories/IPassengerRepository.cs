using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories;

public interface IPassengerRepository
{
    Task<IEnumerable<Passenger>> GetAllAsync();
    Task<Passenger?> GetByIdAsync(Guid id);
    Task<Passenger?> GetByEmailAsync(string email);
    Task AddAsync(Passenger passenger);
    Task UpdateAsync(Passenger passenger);
    Task DeleteAsync(Passenger passenger);
} 