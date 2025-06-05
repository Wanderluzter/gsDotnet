using Microsoft.EntityFrameworkCore;

public class AlertaUsuarioRepository : IAlertaUsuarioRepository
{
    private readonly AppDbContext _context;

    public AlertaUsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<AlertaUsuario>> GetAllAsync() =>
        await _context.Set<AlertaUsuario>().ToListAsync();

    public async Task<AlertaUsuario?> GetByIdAsync(int id) =>
        await _context.Set<AlertaUsuario>().FindAsync(id);

    public async Task<AlertaUsuario> CreateAsync(AlertaUsuario alerta)
    {
        _context.Add(alerta);
        await _context.SaveChangesAsync();
        return alerta;
    }

    public async Task<AlertaUsuario?> UpdateAsync(int id, AlertaUsuario alerta)
    {
        var existing = await _context.Set<AlertaUsuario>().FindAsync(id);
        if (existing == null) return null;

        existing.DataAlerta = alerta.DataAlerta;
        existing.Gravidade = alerta.Gravidade;
        existing.IdLocalizacao = alerta.IdLocalizacao;
        existing.IdUsuario = alerta.IdUsuario;
        existing.IdEvento = alerta.IdEvento;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.Set<AlertaUsuario>().FindAsync(id);
        if (existing == null) return false;

        _context.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
