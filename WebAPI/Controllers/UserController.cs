//using Domain.Entities;
//using Domain.Interfaces.Users;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Presentation.Controllers
//{
//    [ApiController]
//    [Route("api/users")]
//    public class UserController : ControllerBase
//    {
//        private readonly IUserRepository _infoUsersRepository;

//        public UserController(IUserRepository infoUsersRepository)
//        {
//            _infoUsersRepository = infoUsersRepository;
//        }

//        [HttpGet]
//        public ActionResult<IEnumerable<User>> GetUsers()
//        {
//            var users = _infoUsersRepository.Get();
//            return Ok(users);
//        }

//        [HttpGet("{id:int}")]
//        public ActionResult<User> GetUser(int id)
//        {
//            var user = _infoUsersRepository.GetUser(id);
//            if (user == null)
//                return NotFound(new { message = "Usuario no encontrado" });

//            return Ok(user);
//        }

//        [HttpPost]
//        public ActionResult<User> CreateUser([FromBody] User user)
//        {
//            if (user == null)
//                return BadRequest(new { message = "Datos inválidos" });

//            int newUserId = _infoUsersRepository.AddUser(user);
//            return CreatedAtAction(nameof(GetUser), new { name = user.UserName }, user);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateUser(int id, [FromBody] User user)
//        {
//            var existingUser = _infoUsersRepository.GetUser(id);
//            if (existingUser == null)
//                return NotFound(new { message = "Usuario no encontrado" });

//            _infoUsersRepository.UpdateUser(id, user);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteUser(int id)
//        {
//            var userToDelete = _infoUsersRepository.GetUser(id);
//            if (userToDelete == null)
//                return NotFound(new { message = "Usuario no encontrado" });

//            _infoUsersRepository.DeleteUser(id);
//            return NoContent();
//        }
//    }
//}
