public class AlertaUsuarioService : IAlertaUsuarioService
{
    private readonly IAlertaUsuarioRepository _repository;

    public AlertaUsuarioService(IAlertaUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AlertaUsuarioDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return list.Select(a => new AlertaUsuarioDto
        {
            IdAlerta = a.IdAlerta,
            DataAlerta = a.DataAlerta,
            Gravidade = a.Gravidade,
            IdLocalizacao = a.IdLocalizacao,
            IdUsuario = a.IdUsuario,
            IdEvento = a.IdEvento
        }).ToList();
    }

    public async Task<AlertaUsuarioDto?> GetByIdAsync(int id)
    {
        var a = await _repository.GetByIdAsync(id);
        if (a == null) return null;

        return new AlertaUsuarioDto
        {
            IdAlerta = a.IdAlerta,
            DataAlerta = a.DataAlerta,
            Gravidade = a.Gravidade,
            IdLocalizacao = a.IdLocalizacao,
            IdUsuario = a.IdUsuario,
            IdEvento = a.IdEvento
        };
    }

    public async Task<AlertaUsuarioDto> CreateAsync(CreateAlertaUsuarioDto dto)
    {
        var alerta = new AlertaUsuario
        {
            DataAlerta = dto.DataAlerta,
            Gravidade = dto.Gravidade,
            IdLocalizacao = dto.IdLocalizacao,
            IdUsuario = dto.IdUsuario,
            IdEvento = dto.IdEvento
        };

        var created = await _repository.CreateAsync(alerta);

        return new AlertaUsuarioDto
        {
            IdAlerta = created.IdAlerta,
            DataAlerta = created.DataAlerta,
            Gravidade = created.Gravidade,
            IdLocalizacao = created.IdLocalizacao,
            IdUsuario = created.IdUsuario,
            IdEvento = created.IdEvento
        };
    }

    public async Task<AlertaUsuarioDto?> UpdateAsync(int id, CreateAlertaUsuarioDto dto)
    {
        var alerta = new AlertaUsuario
        {
            IdAlerta = id,
            DataAlerta = dto.DataAlerta,
            Gravidade = dto.Gravidade,
            IdLocalizacao = dto.IdLocalizacao,
            IdUsuario = dto.IdUsuario,
            IdEvento = dto.IdEvento
        };

        var updated = await _repository.UpdateAsync(id, alerta);
        if (updated == null) return null;

        return new AlertaUsuarioDto
        {
            IdAlerta = updated.IdAlerta,
            DataAlerta = updated.DataAlerta,
            Gravidade = updated.Gravidade,
            IdLocalizacao = updated.IdLocalizacao,
            IdUsuario = updated.IdUsuario,
            IdEvento = updated.IdEvento
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
