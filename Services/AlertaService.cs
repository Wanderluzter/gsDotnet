public class AlertaService
{
    private readonly AppDbContext _context;

    public AlertaService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<AlertaReadDTO> GetAll()
    {
        return _context.Alertas
            .Select(a => new AlertaReadDTO
            {
                IdAlerta = a.IdAlerta,
                DataAlerta = a.DataAlerta,
                Descricao = a.Descricao,
                Latitude = a.Latitude,
                Longitude = a.Longitude
            })
            .ToList();
    }

    public IEnumerable<AlertaReadDTO> GetByUsuarioId(int idUsuario)
    {
        return _context.Alertas
            .Where(a => a.IdUsuario == idUsuario)
            .Select(a => new AlertaReadDTO
            {
                IdAlerta = a.IdAlerta,
                DataAlerta = a.DataAlerta,
                Descricao = a.Descricao,
                Latitude = a.Latitude,
                Longitude = a.Longitude
            })
            .ToList();
    }

    public void Create(AlertaCreateDTO dto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == dto.IdUsuario);
        if (usuario == null)
            throw new Exception("Usuário não encontrado.");

        var alerta = new Alerta
        {
            Descricao = dto.Descricao,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            DataAlerta = DateTime.UtcNow,
            IdUsuario = dto.IdUsuario
        };

        _context.Alertas.Add(alerta);
        _context.SaveChanges();
    }
}
