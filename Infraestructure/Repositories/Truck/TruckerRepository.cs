using Domain.Entities;
using Domain.Interfaces.Truck;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using System.Collections.Generic;
using System.Linq;
using Application.Models.Truck;

namespace Infraestructure.Repositories.Truck
{
    public class TruckerRepository : ITruckerRepository
    {
        private readonly ApplicationContext _context;

        public TruckerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Trucker>> GetTruckersAll()
        {
            return await _context.Truckers.ToListAsync();
        }

        public async Task<int> GetTruckerTotalKilometers(int truckerId)
        {
            var totalKm = await _context.Trips
                .Where(t => t.TruckerId == truckerId)
                .SumAsync(t => t.Kilometers);

            return totalKm;
        }

        public async Task<Trucker?> GetTruckerById(int id)
        {
            return await _context.Truckers.Include(t => t.Trips).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<int> CreateTrucker(Trucker trucker)
        {
            _context.Truckers.Add(trucker);
            await _context.SaveChangesAsync();
            return trucker.Id;
        }

        public async Task UpdateTrucker(int id, Trucker trucker)
        {
            var existingTrucker = await _context.Truckers.FindAsync(id);
            if (existingTrucker == null) return;

            existingTrucker.CompleteName = trucker.CompleteName;
            existingTrucker.TruckerType = trucker.TruckerType;
            existingTrucker.Roles = trucker.Roles;
            existingTrucker.Trips = trucker.Trips;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrucker(int id)
        {
            var trucker = _context.Truckers.Find(id);
            if (trucker == null) return;

            _context.Truckers.Remove(trucker);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}