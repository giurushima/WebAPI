using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/business")]
    public class BusinessController : ControllerBase
    {
        [HttpGet("info")]
        public async Task<IActionResult> GetInfo()
        {
            var info = new
            {
                Name = "Transportes Trucking",
                Foundation = 2000,
                Mision = "Garantizar entregas seguras y con eficiencia.",
                Login = "Dirigirse a la parte superior para ingreso al sistema."
            };

            return await Task.FromResult(Ok(info));
        }
    }
}