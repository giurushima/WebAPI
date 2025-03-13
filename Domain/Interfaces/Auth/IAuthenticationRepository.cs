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

// El metodo recibe un nombre de usuario y una contraseña
// y devuelve el objeto USER si las credenciales son correctas.