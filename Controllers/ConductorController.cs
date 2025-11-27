using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("api/conductor")]
    public class ConductorController : ControllerBase
    {
        private readonly IConductorService _service;
        private readonly IViajeService _viajes;
        public ConductorController(IConductorService service, IViajeService viajes)
        {
            _service = service;
            _viajes = viajes;
        }
        // POST: api/conductor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConductorDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return Created($"api/v1/speakers/{id}", new { id });
        }

        // GET: api/conductor/{id}/viajes
        [HttpGet("{id:int}/viajes")]
        public async Task<IActionResult> GetViajes(int id)
        {
            var data = await _service.GetViajesAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // POST: api/conductor/talks
        [HttpPost("talks")]
        public async Task<IActionResult> AddViaje([FromBody] CreateConductorDto dto)
        {
            await _viajes.AddViajeAsync(dto);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterConductorDto dto)
        {
            var id = await _service.RegisterAsync(dto);
            return CreatedAtAction(nameof(Register), new { id }, null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var (ok, response) = await _service.LoginAsync(dto);
            if (!ok || response is null) return Unauthorized();
            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto dto)
        {
            var (ok, response) = await _service.RefreshAsync(dto);
            if (!ok || response is null) return Unauthorized();
            return Ok(response);
        }
    }
}
