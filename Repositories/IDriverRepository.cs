using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories;

public interface IDriverRepository
{
    Task<IEnumerable<Driver>> GetAllAsync();
    Task<Driver?> GetByIdAsync(Guid id);
    Task<Driver?> GetByEmailAsync(string email);
    Task AddAsync(Driver driver);
    Task UpdateAsync(Driver driver);
    Task DeleteAsync(Driver driver);
}