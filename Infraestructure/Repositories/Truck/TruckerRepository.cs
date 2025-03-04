using Domain.Entities;
using Domain.Interfaces.Truck;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using System.Collections.Generic;
using System.Linq;

namespace Infraestructure.Repositories.Truck
{
    public class TruckerRepository : ITruckerRepository
    {
        private readonly ApplicationContext _context;

        public TruckerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Trucker> GetAll()
        {
            return _context.Truckers.Include(t => t.Trips).ToList();
        }

        public Trucker? GetById(int id)
        {
            return _context.Truckers.Include(t => t.Trips).FirstOrDefault(t => t.Id == id);
        }

        public int Add(Trucker trucker)
        {
            _context.Truckers.Add(trucker);
            _context.SaveChanges();
            return trucker.Id;
        }

        public void Update(int id, Trucker trucker)
        {
            var existingTrucker = _context.Truckers.Find(id);
            if (existingTrucker == null) return;

            // Asignación manual de valores
            existingTrucker.CompleteName = trucker.CompleteName;
            existingTrucker.TruckerType = trucker.TruckerType;
            existingTrucker.Roles = trucker.Roles;
            existingTrucker.Trips = trucker.Trips;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var trucker = _context.Truckers.Find(id);
            if (trucker == null) return;

            _context.Truckers.Remove(trucker);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}