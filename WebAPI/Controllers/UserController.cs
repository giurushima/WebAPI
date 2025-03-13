using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces.Users;
using Application.Models.User;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize(Roles = "Admin,Supervisor")]
        [HttpGet("all")]
        public async Task<IActionResult> GetUsersAll()
        {
            var users = await _userRepository.GetUsersAll();
            return Ok(users);
        }

        [Authorize(Roles = "Admin,Supervisor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return NotFound("Usuario no encontrado");

            return Ok(user);
        }

        [Authorize(Roles = "Admin,Supervisor")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {
                Name = userDto.Name,
                UserName = userDto.UserName,
                Password = userDto.Password,
                Roles = userDto.Roles
            };

            await _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [Authorize(Roles = "Admin,Supervisor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto userDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return NotFound(new { message = $"El usuario con ID {id} no fue encontrado." });

            user.Name = userDto.Name ?? user.Name;
            user.UserName = userDto.UserName ?? user.UserName;
            user.Password = userDto.Password ?? user.Password;
            user.Roles = userDto.Roles;

            await _userRepository.UpdateUser(user);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
                return NotFound("Usuario no encontrado");

            await _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}