using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Trips
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetTripsByTrucker(int truckerId);
        Task<Trip?> GetTripByTruckerAndTripId(int truckerId, int tripId);
        Task AddTrip(Trip trip);
        Task UpdateTrip(Trip trip);
        Task DeleteTrip(int id);
        Task<IEnumerable<Trip>> GetTripsByStatus(TripStatus status);
    }
}