public interface IAlertaUsuarioRepository
{
    Task<List<AlertaUsuario>> GetAllAsync();
    Task<AlertaUsuario?> GetByIdAsync(int id);
    Task<AlertaUsuario> CreateAsync(AlertaUsuario alerta);
    Task<AlertaUsuario?> UpdateAsync(int id, AlertaUsuario alerta);
    Task<bool> DeleteAsync(int id);
}
