using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public class ConductorRepository : IConductorRepository
    {
        private readonly AppDbContext _ctx;
        public ConductorRepository(AppDbContext ctx) { _ctx = ctx; }

        public async Task AddAsync(Conductor conductor)
        {
            _ctx.Conductores.Add(conductor);
            await _ctx.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(Guid id) =>
            _ctx.Conductores.AnyAsync(s => s.Id == id);

        public Task<Conductor?> GetByEmailAddress(string email) =>
            _ctx.Conductores.FirstOrDefaultAsync(u => u.Email == email);

        public Task<Conductor?> GetByRefreshToken(string refreshToken) =>
            _ctx.Conductores.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

        public Task<Conductor?> GetViajesAsync(Guid id) =>
            _ctx.Conductores
                .Include(s => s.Viajes)
                .FirstOrDefaultAsync(s => s.Id == id);

        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();

        public async Task UpdateAsync(Conductor conductor)
        {
            _ctx.Conductores.Update(conductor);
            await _ctx.SaveChangesAsync();
        }
    }
}
