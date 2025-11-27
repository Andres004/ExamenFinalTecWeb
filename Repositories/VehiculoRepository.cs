// Repositories/VehiculoRepository.cs
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly AppDbContext _ctx;
        public VehiculoRepository(AppDbContext ctx) => _ctx = ctx;

        public Task<Vehiculo?> GetByIdAsync(int id) =>
            _ctx.Vehiculos
                .Include(v => v.Modelo)
                .FirstOrDefaultAsync(v => v.Id == id);

        public async Task AddAsync(Vehiculo vehiculo) =>
            await _ctx.Vehiculos.AddAsync(vehiculo);

        public Task<bool> PlacaExistsAsync(string placa) =>
            _ctx.Vehiculos.AnyAsync(v => v.Placa == placa);

        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();
    }
}
