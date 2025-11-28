using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories;

public class PassengerRepository : IPassengerRepository
{
    private readonly AppDbContext _context;

    public PassengerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Passenger>> GetAllAsync()
    {
        return await _context.Passengers.ToListAsync();
    }

    public async Task<Passenger?> GetByIdAsync(Guid id)
    {
        return await _context.Passengers.FindAsync(id);
    }

    public async Task<Passenger?> GetByEmailAsync(string email)
    {
        return await _context.Passengers.FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task AddAsync(Passenger passenger)
    {
        await _context.Passengers.AddAsync(passenger);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Passenger passenger)
    {
        _context.Passengers.Update(passenger);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Passenger passenger)
    {
        _context.Passengers.Remove(passenger);
        await _context.SaveChangesAsync();
    }
}