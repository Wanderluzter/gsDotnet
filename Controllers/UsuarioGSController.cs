using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioGSController : ControllerBase
{
    private readonly UsuarioGSService _service;

    public UsuarioGSController(UsuarioGSService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpPost]
    public IActionResult Create([FromBody] UsuarioGSCreateDTO dto)
    {
        _service.Create(dto);
        return CreatedAtAction(nameof(GetAll), null);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UsuarioGSCreateDTO dto)
    {
        try
        {
            _service.Update(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _service.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
