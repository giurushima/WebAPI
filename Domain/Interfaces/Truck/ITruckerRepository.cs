using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Truck
{
    public interface ITruckerRepository
    {
        Task<List<Trucker>> GetTruckersAll();
        Task<Trucker?> GetTruckerById(int id);
        Task<int> CreateTrucker(Trucker trucker);
        Task UpdateTrucker(int id, Trucker trucker);
        Task DeleteTrucker(int id);
        Task SaveChangesAsync();
        Task<int> GetTruckerTotalKilometers(int truckerId);
    }
}