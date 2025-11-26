using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _viajes;

        public ViajeService(IViajeRepository viajes)
        {
            _viajes = viajes;
        }
        public async Task<int> CreateAsync(CreateViajeDto dto)
        {
            var endUtc = dto.FechaSalida.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dto.FechaSalida, DateTimeKind.Utc)
                : dto.FechaSalida.ToUniversalTime();

            var overlaps = await _viajes.HasOverlapAsync(dto.PasajeroId, endUtc);
            if (overlaps)
                throw new InvalidOperationException("The room already has a talk in this time range.");

            var viaje = new Viaje
            {
                Id = Guid.NewGuid(),
                Origen = dto.Origen,
                Destino = dto.Destino,
                FechaSalida = dto.FechaSalida,
                Precio = dto.Precio,
                Estado = dto.Estado
            };

            await _viajes.AddAsync(viaje);
            return await _viajes.SaveChangesAsync();
        }
    }
}
