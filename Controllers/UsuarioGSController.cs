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
}
