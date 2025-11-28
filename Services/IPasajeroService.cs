using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;

namespace ProyectoFinal.Services
{
    public interface IPasajeroService
    {
        //Authentication
        Task<string> RegisterAsync(RegisterPasajeroDto dto);

        //CRUD
        Task<Guid> CreateAsync(CreatePasajeroDto dto);
        Task<IEnumerable<Pasajero>> GetAll();
        Task<Pasajero> GetOne(Guid id);
        Task<Pasajero> UpdatePasajero(UpdatePasajeroDto dto, Guid id);
        Task DeletePasajero(Guid id);
    }
}
