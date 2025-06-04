public class AlertaUsuario
{
    public int IdAlerta { get; set; }
    public DateTime? DataAlerta { get; set; }
    public string? Gravidade { get; set; }
    public int IdLocalizacao { get; set; }
    public int IdUsuario { get; set; }
    public int IdEvento { get; set; }
    public AlertaUsuario() { }
    public AlertaUsuario(int idAlerta, DateTime? dataAlerta, string gravidade, int idLocalizacao, int idUsuario, int idEvento)
    {
        IdAlerta = idAlerta;
        DataAlerta = dataAlerta;
        Gravidade = gravidade;
        IdLocalizacao = idLocalizacao;
        IdUsuario = idUsuario;
        IdEvento = idEvento;
    }
}