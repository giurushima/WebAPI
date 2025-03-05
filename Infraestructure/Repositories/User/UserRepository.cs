using Application.Models.Auth;
using Domain.Entities;
using Domain.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Context;

namespace Infraestructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
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