using Microsoft.EntityFrameworkCore;

public class UsuarioGSRepository
{
    private readonly AppDbContext _context;

    public UsuarioGSRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<UsuarioGS> GetAll()
    {
        return _context.Usuarios.Include(u => u.Alertas).ToList();
    }

    public UsuarioGS? GetById(int id)
    {
        return _context.Usuarios.Include(u => u.Alertas).FirstOrDefault(u => u.IdUsuario == id);
    }

    public void Add(UsuarioGS usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Update(UsuarioGS usuario)
    {
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Usuarios.Any(u => u.Email == email);
    }
}
