using Domain.Entities;
using Domain.Interfaces.Truck;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckerController : ControllerBase
    {
        private readonly ITruckerRepository _truckerRepository;

        public TruckerController(ITruckerRepository truckerRepository)
        {
            _truckerRepository = truckerRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<IEnumerable<Trucker>> GetAll()
        {
            return Ok(_truckerRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Trucker> GetById(int id)
        {
            var trucker = _truckerRepository.GetById(id);
            if (trucker == null)
                return NotFound();

            return Ok(trucker);
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody] Trucker trucker)
        {
            var id = _truckerRepository.Add(trucker);
            return CreatedAtAction(nameof(GetById), new { id }, trucker);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Trucker trucker)
        {
            var existingTrucker = _truckerRepository.GetById(id);
            if (existingTrucker == null)
                return NotFound();

            _truckerRepository.Update(id, trucker);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingTrucker = _truckerRepository.GetById(id);
            if (existingTrucker == null)
                return NotFound();

            _truckerRepository.Delete(id);
            return NoContent();
        }
    }
}
