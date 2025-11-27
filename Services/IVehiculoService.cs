using using ProyectoFinal.Models.DTOS;

namespace ProyectoFinal.Services
{
    public interface IVehiculoService
    {
        Task<int> CreateAsync(CreateVehiculoDto dto);
        Task<object?> GetByIdAsync(int id);
    }
}