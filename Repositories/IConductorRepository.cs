using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IConductorRepository
    {
        Task<Conductor?> GetByEmailAddress(string email);
        Task<Conductor?> GetByRefreshToken(string refreshToken);
        Task AddAsync(Conductor conductor);
        Task UpdateAsync(Conductor conductor);


        Task<Conductor?> GetViajesAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
