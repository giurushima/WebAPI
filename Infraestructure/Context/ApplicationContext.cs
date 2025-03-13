using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Emit;

namespace WebAPI.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Trucker> Truckers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; } // Recibe una clase y es accesible para demas recursos.

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var truckers = new Trucker[5]
            {

                new()
                {
                    Id = 1,
                    CompleteName = "Juan Gomez",
                    TruckerType = "Carga Seca",
                    Roles = Roles.Trucker,
                },
                new()
                {
                    Id = 2,
                    CompleteName = "Martin Suarez",
                    TruckerType = "Automoviles",
                    Roles = Roles.Trucker,
                },
                new()
                {
                    Id = 3,
                    CompleteName = "Agustin Ramirez",
                    TruckerType = "Ganaderia",
                    Roles = Roles.Trucker,
                },
                new()
                {
                    Id = 4,
                    CompleteName = "Benjamin Perez",
                    TruckerType = "Combustibles",
                    Roles = Roles.Trucker,
                },
                new()
                {
                    Id = 5,
                    CompleteName = "Thiago Mendez",
                    TruckerType = "Explosivos",
                    Roles = Roles.Trucker,
                }

            };
            modelBuilder.Entity<Trucker>().HasData(truckers);

            var trips = new Trip[3]
            {

                new()
                {
                    Id = 1,
                    Source = "Rosario, Santa Fe",
                    Destiny = "CABA, Buenos Aires",
                    Description = "Viaje de ...",
                    Kilometers = 250,
                    TripStatus = TripStatus.Pendiente,
                    TruckerId = truckers[0].Id,
                },
                new()
                {
                    Id = 2,
                    Source = "Arroyo Seco, Buenos Aires",
                    Destiny = "Bariloche, Rio Negro",
                    Description = "Viaje de ...",
                    Kilometers = 1400,
                    TripStatus = TripStatus.EnProgreso,
                    TruckerId = truckers[2].Id,
                },
                new()
                {
                    Id = 3,
                    Source = "Rosario, Santa Fe",
                    Destiny = "Carlos Paz, Cordoba",
                    Description = "Viaje de ...",
                    Kilometers = 400,
                    TripStatus = TripStatus.Completado,
                    TruckerId = truckers[1].Id,
                }
            };

            modelBuilder.Entity<Trip>().HasData(trips);

            var users = new User[3]
            {
                new()
                {
                    Id = 1,
                    Name = "Gabriel",
                    UserName = "gabriel",
                    Password = "1234",
                    Roles = Roles.Admin,
                },
                new()
                {
                    Id = 2,
                    Name = "Fernando",
                    UserName = "fernando",
                    Password = "1234",
                    Roles = Roles.Supervisor,
                },
                new()
                {
                    Id = 3,
                    Name = "Sara",
                    UserName = "sara",
                    Password = "1234",
                    Roles = Roles.Employeer,
                }
            };

            modelBuilder.Entity<User>().HasData(users);

            base.OnModelCreating(modelBuilder);
        }
    }
}