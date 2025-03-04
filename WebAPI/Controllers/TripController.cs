using Domain.Entities;
using Domain.Interfaces.Trips;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/trips")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;

        public TripController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        // GET: /api/trips/{idTrucker}/trips
        [HttpGet("{idTrucker}/trips")]
        public async Task<IActionResult> GetTripsByTrucker(int idTrucker)
        {
            var trips = await _tripRepository.GetTripsByTruckerAsync(idTrucker);
            if (trips == null) return NotFound();
            return Ok(trips);
        }

        // GET: /api/trips/{idTrucker}/trips/{idTrip}
        [HttpGet("{idTrucker}/trips/{idTrip}")]
        public async Task<IActionResult> GetTripByTrucker(int idTrucker, int idTrip)
        {
            var trip = await _tripRepository.GetTripByTruckerAndTripIdAsync(idTrucker, idTrip);
            if (trip == null) return NotFound();
            return Ok(trip);
        }


        // POST: /api/trips/{idTrucker}/trips
        [HttpPost("{idTrucker}/trips")]
        public async Task<IActionResult> CreateTrip(int idTrucker, [FromBody] Trip trip)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            trip.TruckerId = idTrucker;
            await _tripRepository.AddTripAsync(trip);
            return CreatedAtAction(nameof(GetTripByTrucker), new { idTrucker, idTrip = trip.Id }, trip);
        }

        // PUT: /api/trips/{idTrucker}/trips/{idTrip}
        [HttpPut("{idTrucker}/trips/{idTrip}")]
        public async Task<IActionResult> UpdateTrip(int idTrucker, int idTrip, [FromBody] Trip trip)
        {
            if (idTrip != trip.Id || idTrucker != trip.TruckerId) return BadRequest("ID mismatch");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingTrip = await _tripRepository.GetTripByTruckerAndTripIdAsync(idTrucker, idTrip);
            if (existingTrip == null) return NotFound();

            await _tripRepository.UpdateTripAsync(trip);
            return NoContent();
        }

        // DELETE: /api/trips/{idTrucker}/trips/{idTrip}
        [HttpDelete("{idTrucker}/trips/{idTrip}")]
        public async Task<IActionResult> DeleteTrip(int idTrucker, int idTrip)
        {
            var existingTrip = await _tripRepository.GetTripByTruckerAndTripIdAsync(idTrucker, idTrip);
            if (existingTrip == null) return NotFound();

            await _tripRepository.DeleteTripAsync(idTrip);
            return NoContent();
        }
    }
}
