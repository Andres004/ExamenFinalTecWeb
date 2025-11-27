using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IVehiculoRepository
    {
        Task AddAsync(Vehiculo vehiculo);
        Task<Vehiculo?> GetByIdAsync(int id);
        Task<bool> PlacaExistsAsync(string placa);
        Task<int> SaveChangesAsync();
    }
}