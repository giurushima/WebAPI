using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.Trips;
using WebAPI.Context;
using Domain.Enums;

namespace Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationContext _context;

        public TripRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTripsByTrucker(int truckerId)
        {
            return await _context.Trips
                .Where(t => t.TruckerId == truckerId)
                .Include(t => t.Trucker)
                .ToListAsync();
        }

        public async Task<Trip?> GetTripByTruckerAndTripId(int truckerId, int tripId)
        {
            return await _context.Trips
                .Include(t => t.Trucker)
                .FirstOrDefaultAsync(t => t.TruckerId == truckerId && t.Id == tripId);
        }

        public async Task AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTrip(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrip(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Trip>> GetTripsByStatus(TripStatus status)
        {
            return await _context.Trips
            .Where(trip => trip.TripStatus == status)
            .Include(t => t.Trucker)
            .ToListAsync();
        }
        public async Task<Trucker?> GetTruckerById(int truckerId)
        {
            return await _context.Truckers.FirstOrDefaultAsync(t => t.Id == truckerId);
        }

    }
}
