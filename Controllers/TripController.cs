using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.DTOS.Trip;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers;

[ApiController]
[Route("api/trips")]
[Authorize]
public class TripController : ControllerBase
{
    private readonly ITripService _service;

    public TripController(ITripService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var trip = await _service.GetByIdAsync(id);
        if (trip == null) return NotFound();
        return Ok(trip);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTripDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
}