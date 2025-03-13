using Application.Models.Truck;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Truck;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebAPI.Controllers
{
    [Route("api/trucker")]
    [ApiController]
    public class TruckerController : ControllerBase
    {
        private readonly ITruckerRepository _truckerRepository;

        public TruckerController(ITruckerRepository truckerRepository)
        {
            _truckerRepository = truckerRepository;
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpGet("all")]
        public async Task<IActionResult> GetTruckersAll()
        {
            return Ok(await _truckerRepository.GetTruckersAll());
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTruckerById(int id)
        {
            var trucker = await _truckerRepository.GetTruckerById(id);
            if (trucker == null)
                return NotFound(new { message = $"No se encontró un camionero con el ID {id}." });

            return Ok(trucker);
        }

        [Authorize(Roles = "Admin,Supervisor")]
        [HttpGet("{id}/TotalKilometers")]
        public async Task<IActionResult> GetTruckerTotalKilometers(int id)
        {
            var trucker = await _truckerRepository.GetTruckerById(id);

            if (trucker == null)
            {
                return NotFound(new { message = $"No se encontró un camionero con el ID {id}." });
            }

            var totalKm = await _truckerRepository.GetTruckerTotalKilometers(id);

            if (totalKm == 0)
            {
                return Ok(new
                {
                    TruckerId = id,
                    Kilometers = totalKm,
                    Message = "El camionero no tiene kilometros recorridos en viajes completados."
                });
            }

            return Ok(new 
            {
                TruckerId = id,
                Kilometers = totalKm,
                Message = $"El camionero ha recorrido {totalKm} kilometros"
            });
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateTrucker([FromBody] CreateTruckDto truckDto)
        {
            var trucker = new Trucker
            {
                CompleteName = truckDto.CompleteName,
                TruckerType = truckDto.TruckerType,
                Roles = Domain.Enums.Roles.Trucker
            };

            var id = await _truckerRepository.CreateTrucker(trucker);
            return CreatedAtAction(nameof(GetTruckerById), new { id }, new { message = "Camionero creado con éxito." });
        }

        [Authorize(Roles = "Admin,Supervisor,Employeer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrucker(int id, [FromBody] UpdateTruckDto truckDto)
        {
            var existingTrucker = await _truckerRepository.GetTruckerById(id);
            if (existingTrucker == null)
                return NotFound(new { message = $"No se encontró un camionero con el ID {id}." });

            existingTrucker.CompleteName = truckDto.CompleteName ?? existingTrucker.CompleteName;
            existingTrucker.TruckerType = truckDto.TruckerType ?? existingTrucker.TruckerType;
            existingTrucker.Roles = Roles.Trucker;

            await _truckerRepository.UpdateTrucker(id, existingTrucker);

            return Ok(new
            {
                message = $"Camionero con ID {id} actualizado con éxito.",
                data = existingTrucker
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrucker(int id)
        {
            var trucker = await _truckerRepository.GetTruckerById(id);
            if (trucker == null)
                return NotFound(new { message = $"No se encontro un camionero con el ID {id}." });

            await _truckerRepository.DeleteTrucker(id);
            return Ok(new { message = $"Camionero con ID {id} eliminado con éxito." });
        }
    }
}
