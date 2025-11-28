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
        private readonly IPasajeroService _pasajero;
        private readonly IConductorService _conductor;

        public ViajeController(IViajeService service, IPasajeroService pasajero, IConductorService conductor)
        {
            _service = service;
            _pasajero = pasajero;
            _conductor = conductor;
        }
        
        // POST: api/viaje
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateViajeDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetPasajero), new { id }, new { id });
        }

        
        // GET: api/viaje/{id}/pasajero
        [HttpGet("{id:Guid}/pasajero")]
        public async Task<IActionResult> GetPasajero([FromRoute] Guid id)
        {
            var data = await _pasajero.GetOne(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // GET: api/viaje/{id}/conductor
        [HttpGet("{id:Guid}/conductor")]
        public async Task<IActionResult> GetConductor([FromRoute] Guid id)
        {
            var data = await _conductor.GetOne(id);
            if (data == null) return NotFound();
            return Ok(data);
        }



    }
}
