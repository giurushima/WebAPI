using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Trips;
using WebAPI.Context;

namespace Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationContext _context;

        public TripRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTripsByTruckerAsync(int truckerId)
        {
            return await _context.Trips
                .Where(t => t.TruckerId == truckerId)
                .Include(t => t.Trucker)
                .ToListAsync();
        }

        public async Task<Trip?> GetTripByTruckerAndTripIdAsync(int truckerId, int tripId)
        {
            return await _context.Trips
                .Include(t => t.Trucker)
                .FirstOrDefaultAsync(t => t.TruckerId == truckerId && t.Id == tripId);
        }

        public async Task AddTripAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTripAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTripAsync(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }
        }
    }
}
