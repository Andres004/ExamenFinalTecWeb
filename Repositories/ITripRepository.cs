using ProyectoFinal.Models;
namespace ProyectoFinal.Repositories;

public interface ITripRepository
{
    Task<IEnumerable<Trip>> GetAllAsync();
    Task<Trip?> GetByIdAsync(Guid id);
    Task AddAsync(Trip trip);
    Task UpdateAsync(Trip trip);
    Task DeleteAsync(Trip trip);
}