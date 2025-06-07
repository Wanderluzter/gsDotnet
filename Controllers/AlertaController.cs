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
    public IActionResult GetAll()
    {
        var alertas = _service.GetAll();
        return Ok(alertas);
    }

    [HttpGet("usuario/{idUsuario}")]
    public IActionResult GetByUsuario(int idUsuario)
    {
        var alertas = _service.GetByUsuarioId(idUsuario);
        return Ok(alertas);
    }

    [HttpPost]
    public IActionResult Create([FromBody] AlertaCreateDTO dto)
    {
        try
        {
            _service.Create(dto);
            return Created("", null);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
