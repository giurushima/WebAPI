using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Context;

namespace Infraestructure.Repositories.Auth
{
    public class AuthenticationRepository
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
