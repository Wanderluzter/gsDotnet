public interface IAlertaUsuarioService
{
    Task<List<AlertaUsuarioDto>> GetAllAsync();
    Task<AlertaUsuarioDto?> GetByIdAsync(int id);
    Task<AlertaUsuarioDto> CreateAsync(CreateAlertaUsuarioDto dto);
    Task<AlertaUsuarioDto?> UpdateAsync(int id, CreateAlertaUsuarioDto dto);
    Task<bool> DeleteAsync(int id);
}
