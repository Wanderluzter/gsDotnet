using Microsoft.EntityFrameworkCore;

public class UsuarioGSRepository
{
    private readonly AppDbContext _context;

    public UsuarioGSRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UsuarioGS>> GetAllAsync()
    {
        return await _context.Usuarios
            .Include(u => u.Alertas)
            .ToListAsync();
    }

    public async Task<UsuarioGS?> GetByIdAsync(int id)
    {
        return await _context.Usuarios
            .Include(u => u.Alertas)
            .FirstOrDefaultAsync(u => u.IdUsuario == id);
    }

    public async Task AddAsync(UsuarioGS usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UsuarioGS usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Usuarios.AnyAsync(u => u.Email == email);
    }
}
