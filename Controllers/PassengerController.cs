using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.DTOS.Passenger;
using ProyectoFinal.Services;

namespace ProyectoFinal.Controllers;

[ApiController]
[Route("api/passengers")]
[Authorize]
public class PassengerController : ControllerBase
{
    private readonly IPassengerService _service;

    public PassengerController(IPassengerService service)
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
        var passenger = await _service.GetByIdAsync(id);
        if (passenger == null) return NotFound();
        return Ok(passenger);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePassengerDto dto)
    {
        try
        {
            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}