public class CreateAlertaUsuarioDto
{
    public DateTime? DataAlerta { get; set; }
    public string? Gravidade { get; set; }
    public int IdLocalizacao { get; set; }
    public int IdUsuario { get; set; }
    public int IdEvento { get; set; }
}
