using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AlertaRepository
{
    private readonly AppDbContext _context;

    public AlertaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Alerta>> GetAllAsync()
    {
        return await _context.Alertas
            .Include(a => a.Usuario)
            .ToListAsync();
    }

    public async Task<IEnumerable<Alerta>> GetByUsuarioIdAsync(int idUsuario)
    {
        return await _context.Alertas
            .Where(a => a.IdUsuario == idUsuario)
            .ToListAsync();
    }

    public async Task<Alerta?> GetByIdAsync(int id)
    {
        return await _context.Alertas
            .Include(a => a.Usuario)
            .FirstOrDefaultAsync(a => a.IdAlerta == id);
    }

    public async Task AddAsync(Alerta alerta)
    {
        await _context.Alertas.AddAsync(alerta);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var alerta = await _context.Alertas.FindAsync(id);
        if (alerta != null)
        {
            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
        }
    }
}
