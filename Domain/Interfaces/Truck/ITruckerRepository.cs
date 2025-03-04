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
        List<Trucker> GetAll();
        Trucker? GetById(int id);
        int Add(Trucker trucker);
        void Update(int id, Trucker trucker);
        void Delete(int id);
        void SaveChanges();
    }
}