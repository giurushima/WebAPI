using Application.Models.Auth;
using Application.Models.User;
using Domain.Entities;
using Domain.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationRepository _userRepository; // Variable de lectura que almacena la instacnia del repositorio de auth.
        private readonly IConfiguration _config; // Almacena la config de la app. incluye datos sensibles o virables que pueden cambiar segun el entorno.
        public AuthenticateController(IAuthenticationRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _config = configuration;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationRequestBody credentials)
        {
            Domain.Entities.User? userAuthenticated = _userRepository.Authenticate(credentials.UserName, credentials.Password); // se pasa nombre y user, el metodo authenticate busca en la db y retorna un objeto User si las credenciales coinciden o null si no se encuentra.
            if (userAuthenticated is not null)
            {


                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

                SigningCredentials signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256); // Con la clave de seguridad, se crean credenciales de firma usando el algoritmo HmacSha256, garantizando que sea seguro y no sea manipulable.

                //Los claims son datos en clave->valor que nos permite guardar data del usuario.
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", userAuthenticated.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
                claimsForToken.Add(new Claim("given_name", userAuthenticated.UserName)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
                claimsForToken.Add(new Claim(ClaimTypes.Role, userAuthenticated.Roles.ToString()));

                var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                  _config["Authentication:Issuer"],
                  _config["Authentication:Audience"],
                  claimsForToken,
                  DateTime.UtcNow,
                  DateTime.UtcNow.AddHours(1),
                  signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                return Ok(tokenToReturn);
            }
            return Unauthorized();
        }
    }
}
