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

        public async Task<int> CreateAsync(CreateVehiculoDto dto)
        {
            // ejemplo simple: evitar placas repetidas
            var exists = await _vehiculos.PlacaExistsAsync(dto.Placa);
            if (exists)
                throw new InvalidOperationException("Ya existe un vehículo con esa placa.");

            var vehiculo = new Vehiculo
            {
                Placa = dto.Placa,
                Color = dto.Color,
                Estado = dto.Estado,
                ModeloId = dto.ModeloId,
                ConductorId = dto.ConductorId
            };

            await _vehiculos.AddAsync(vehiculo);
            await _vehiculos.SaveChangesAsync();
            return vehiculo.Id;
        }

        public async Task<object?> GetByIdAsync(int id)
        {
            var v = await _vehiculos.GetByIdAsync(id);
            if (v == null) return null;

            // puedes armar un DTO para la respuesta
            return new
            {
                v.Id,
                v.Placa,
                v.Color,
                v.Estado,
                Modelo = new
                {
                    v.Modelo.Id,
                    v.Modelo.Marca,
                    v.Modelo.Nombre,
                    v.Modelo.Año
                }
            };
        }
    }
}