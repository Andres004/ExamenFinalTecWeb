using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/viaje")]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeService _service;
        public ViajeController(IViajeService service)
        {
            _service = service;
        }
        /*
        // POST: api/viaje
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateViajeDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetPasajero), new { id }, new { id });
        }

        
        // GET: api/viaje/{id}/lineup
        [HttpGet("{id:int}/pasajero")]
        public async Task<IActionResult> GetPasajero([FromRoute] int id)
        {
            var data = await _service.CreateAsync(id); // Note: This seems to be a placeholder. Replace with actual method to get pasajero.
            if (data == null) return NotFound();
            return Ok(data);
        }
        */


    }
}
