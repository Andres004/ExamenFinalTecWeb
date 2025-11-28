using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculos;

        public VehiculoService(IVehiculoRepository vehiculos)
        {
            _vehiculos = vehiculos;
        }

        public async Task<Guid> CreateAsync(CreateVehiculoDto dto)
        {
            // ejemplo simple: evitar placas repetidas
            var exists = await _vehiculos.PlacaExistsAsync(dto.Placa);
            if (exists)
                throw new InvalidOperationException("Ya existe un vehículo con esa placa.");

           
            var entity = new Vehiculo { Placa = dto.Placa, Color = dto.Color, Estado = dto.Estado, ModeloId = dto.ModeloId };
            await _vehiculos.AddAsync(entity);
            await _vehiculos.SaveChangesAsync();
            return entity.Id;

        }

        public async Task DeleteAsync(Guid id)
        {
            Vehiculo? vehiculo = (await GetAll()).FirstOrDefault(h => h.Id == id);
            if (vehiculo == null) return;
            await _vehiculos.Delete(vehiculo);
        }

        public async Task<IEnumerable<Vehiculo>> GetAll()
        {
            return await _vehiculos.GetAll();
        }

        public async Task<Vehiculo> GetByIdAsync(Guid id)
        {
            return await _vehiculos.GetByIdAsync(id);
        }

        public async Task<Vehiculo> UpdateAsync(UpdateVehicleDto dto, Guid id)
        {
            Vehiculo? vehiculo = await GetByIdAsync(id);
            if (vehiculo == null) throw new Exception("Vehiculo doesnt exist.");

            vehiculo.Color = dto.Color;
            vehiculo.Estado = dto.Estado;
            vehiculo.ModeloId = dto.ModeloId;
            vehiculo.ConductorId = dto.ConductorId;

            await _vehiculos.Update(vehiculo);
            return vehiculo;
        }
    }
}