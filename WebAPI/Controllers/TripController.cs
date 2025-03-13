using Application.Models.Trip;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Trips;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpGet("{idTrucker}/trips")]
        public async Task<IActionResult> GetTripsByTrucker(int idTrucker)
        {
            var trips = await _tripRepository.GetTripsByTrucker(idTrucker);

            if (trips == null || !trips.Any())
                return NotFound(new { message = $"No se encontraron viajes para el camionero con ID {idTrucker}." });

            return Ok(new
            {
                message = $"Lista de viajes para el camionero con ID {idTrucker} obtenida con éxito.",
                data = trips
            });
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpGet("{idTrucker}/{idTrip}")]
        public async Task<IActionResult> GetTripByTrucker(int idTrucker, int idTrip)
        {
            var trip = await _tripRepository.GetTripByTruckerAndTripId(idTrucker, idTrip);

            if (trip == null)
                return NotFound(new { message = $"No se encontró un viaje con el ID {idTrip} para el camionero con ID {idTrucker}." });

            return Ok(new
            {
                message = $"Viaje con ID {idTrip} del camionero con ID {idTrucker} encontrado con éxito.",
                data = trip
            });
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpPost("{idTrucker}/trips")]
        public async Task<IActionResult> CreateTrip(int idTrucker, [FromBody] CreateTripDto tripDto)
        {
            var trucker = await _tripRepository.GetTruckerById(idTrucker);

            if (trucker == null)
                return NotFound(new { message = $"No se encontró un camionero con ID {idTrucker}." });

            var trip = new Trip
            {
                Source = tripDto.Source,
                Destiny = tripDto.Destiny,
                Kilometers = tripDto.Kilometers,
                Description = tripDto.Description,
                TripStatus = tripDto.TripStatus,
                TruckerId = idTrucker,
            };

            await _tripRepository.AddTrip(trip);

            return CreatedAtAction(nameof(GetTripByTrucker), new { idTrucker, idTrip = trip.Id }, trip);
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpPut("{idTrucker}/{idTrip}")]
        public async Task<IActionResult> UpdateTrip(int idTrucker, int idTrip, [FromBody] UpdateTripDto tripDto)
        {
            var existingTrip = await _tripRepository.GetTripByTruckerAndTripId(idTrucker, idTrip);

            if (existingTrip == null)
                return NotFound(new { message = $"No se encontro un viaje con el id {idTrip} para el camionero {idTrucker}." });

            existingTrip.Source = tripDto.Source;
            existingTrip.Destiny = tripDto.Destiny;
            existingTrip.Kilometers = tripDto.Kilometers;
            existingTrip.Description = tripDto.Description;
            existingTrip.TripStatus = tripDto.TripStatus;

            await _tripRepository.UpdateTrip(existingTrip);

            return Ok(new
            {
                message = $"Viaje con ID {idTrip} del camionero con ID {idTrucker} actualizado con exito.",
                data = existingTrip
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{idTrucker}/{idTrip}")]
        public async Task<IActionResult> DeleteTrip(int idTrucker, [FromRoute]int idTrip)
        {
            var existingTrip = await _tripRepository.GetTripByTruckerAndTripId(idTrucker, idTrip);

            if (existingTrip == null)
                return NotFound(new { message = $"No se encontró un viaje con el ID {idTrip} para el camionero con ID {idTrucker}." });

            await _tripRepository.DeleteTrip(idTrip);

            return Ok(new { message = $"Viaje con ID {idTrip} del camionero con ID {idTrucker} eliminado con éxito." });
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpPost("{truckerId}/{tripId}/status")]
        public async Task<IActionResult> UpdateTripStatus(int truckerId, [FromRoute]int tripId, [FromBody] UpdateStatusTripDto statusDto)
        {
            var trip = await _tripRepository.GetTripByTruckerAndTripId(truckerId, tripId);

            if (trip == null)
                return NotFound(new { message = $"No se encontró el viaje con ID {tripId} para el camionero {truckerId}." });

            trip.TripStatus = statusDto.TripStatus;

            await _tripRepository.UpdateTrip(trip);

            return Ok(new { message = "Estado del viaje actualizado exitosamente.", trip });
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpGet("Completed")]
        public async Task<IActionResult> GetCompletedTrips()
        {
            var CompletedTrips = await _tripRepository.GetTripsByStatus(TripStatus.Completado);

            if (!CompletedTrips.Any())
            {
                return NotFound(new { message = "No hay viajes completados en este momento." });
            }

            return Ok(CompletedTrips);
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpGet("Progress")]
        public async Task<IActionResult> GetInProgressTrips()
        {
            var ProgressTrips = await _tripRepository.GetTripsByStatus(TripStatus.EnProgreso);

            if (!ProgressTrips.Any())
            {
                return NotFound(new { message = "No hay viajes en progreso en este momento." });
            }

            return Ok(ProgressTrips);
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpGet("Pending")]
        public async Task<IActionResult> GetPendingTrips()
        {
            var PendingTrips = await _tripRepository.GetTripsByStatus(TripStatus.Pendiente);

            if (!PendingTrips.Any())
            {
                return NotFound(new { message = "No hay viajes pendientes en este momento." });
            }

            return Ok(PendingTrips);
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpGet("Cancelled")]
        public async Task<IActionResult> GetCancelledTrips()
        {
            var CancelledTrips = await _tripRepository.GetTripsByStatus(TripStatus.Cancelado);

            if (!CancelledTrips.Any())
            {
                return NotFound(new { message = "No hay viajes cancelados en este momento." });
            }

            return Ok(CancelledTrips);
        }
    }
}
