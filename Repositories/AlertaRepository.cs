using Microsoft.EntityFrameworkCore;

public class AlertaRepository
{
    private readonly AppDbContext _context;

    public AlertaRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Alerta> GetAll()
    {
        return _context.Alertas.Include(a => a.Usuario).ToList();
    }

    public IEnumerable<Alerta> GetByUsuarioId(int idUsuario)
    {
        return _context.Alertas.Where(a => a.IdUsuario == idUsuario).ToList();
    }

    public Alerta? GetById(int id)
    {
        return _context.Alertas.Include(a => a.Usuario).FirstOrDefault(a => a.IdAlerta == id);
    }

    public void Add(Alerta alerta)
    {
        _context.Alertas.Add(alerta);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var alerta = _context.Alertas.Find(id);
        if (alerta != null)
        {
            _context.Alertas.Remove(alerta);
            _context.SaveChanges();
        }
    }
}
