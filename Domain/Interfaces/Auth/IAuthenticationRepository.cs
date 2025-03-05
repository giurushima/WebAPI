using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Users
{
    public interface IAuthenticationRepository
    {
        User? Authenticate(string username, string password);
    }
}