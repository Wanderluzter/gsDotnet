using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AlertaService
{
    private readonly AppDbContext _context;

    public AlertaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AlertaReadDTO>> GetAllAsync()
    {
        return await _context.Alertas
            .Select(a => new AlertaReadDTO
            {
                IdAlerta = a.IdAlerta,
                DataAlerta = a.DataAlerta,
                Descricao = a.Descricao,
                Latitude = a.Latitude,
                Longitude = a.Longitude
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<AlertaReadDTO>> GetByUsuarioIdAsync(int idUsuario)
    {
        return await _context.Alertas
            .Where(a => a.IdUsuario == idUsuario)
            .Select(a => new AlertaReadDTO
            {
                IdAlerta = a.IdAlerta,
                DataAlerta = a.DataAlerta,
                Descricao = a.Descricao,
                Latitude = a.Latitude,
                Longitude = a.Longitude
            })
            .ToListAsync();
    }

    public async Task CreateAsync(AlertaCreateDTO dto)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == dto.IdUsuario);
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

        await _context.Alertas.AddAsync(alerta);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, AlertaCreateDTO dto)
    {
        var alerta = await _context.Alertas.FindAsync(id);
        if (alerta == null)
            throw new Exception("Alerta não encontrado.");

        alerta.Descricao = dto.Descricao;
        alerta.Latitude = dto.Latitude;
        alerta.Longitude = dto.Longitude;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var alerta = await _context.Alertas.FindAsync(id);
        if (alerta == null)
            throw new Exception("Alerta não encontrado.");

        _context.Alertas.Remove(alerta);
        await _context.SaveChangesAsync();
    }
}
