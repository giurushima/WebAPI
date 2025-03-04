using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Trips
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetTripsByTruckerAsync(int truckerId);
        Task<Trip?> GetTripByTruckerAndTripIdAsync(int truckerId, int tripId);
        Task AddTripAsync(Trip trip);
        Task UpdateTripAsync(Trip trip);
        Task DeleteTripAsync(int id);
    }
}