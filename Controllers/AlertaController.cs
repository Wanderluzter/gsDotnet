using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AlertaController : ControllerBase
{
    private readonly AlertaService _service;

    public AlertaController(AlertaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alertas = await _service.GetAllAsync();
        return Ok(alertas);
    }

    [HttpGet("usuario/{idUsuario}")]
    public async Task<IActionResult> GetByUsuario(int idUsuario)
    {
        var alertas = await _service.GetByUsuarioIdAsync(idUsuario);
        return Ok(alertas);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AlertaCreateDTO dto)
    {
        try
        {
            await _service.CreateAsync(dto);
            return Created("", null);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] AlertaCreateDTO dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
