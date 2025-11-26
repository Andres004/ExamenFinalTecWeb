using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly AppDbContext _ctx;
        public ViajeRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Viaje viaje) => await _ctx.Viajes.AddAsync(viaje);


        public Task<bool> ExistsAsync(Guid id) =>
            _ctx.Viajes.AnyAsync(s => s.Id == id);

        public Task<Viaje?> GetViajeAsync(Guid id) =>  
            _ctx.Viajes.FirstOrDefaultAsync(s => s.Id == id);

        public Task<bool> HasOverlapAsync(int pasajeroId, DateTime end) =>
            _ctx.Viajes.AnyAsync(t => t.PasajeroId == pasajeroId
                                  && end > t.FechaSalida);

        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();
    }
}
