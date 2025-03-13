using Domain.Entities;
using Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Context;

namespace Infraestructure.Repositories.Auth
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationContext _context;
        public AuthenticationRepository(ApplicationContext context)
        {
            _context = context;
        }
        public User? Authenticate(string username, string password)
        {
            User? userToAuthenticate = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            return userToAuthenticate;
        }
    }
}

// La clase AuthenticationRepository implementa la interfaz IAuthenticationRepository.
// Utiliza el dbcontext de entity framework para acceder a la tabla de usuarios.
// Se usa LINQ para buscar el primer usuario cuya propiedad username y pass coincidan con las credenciales proporcionadas, si lo encuentra lo retorna si no null.