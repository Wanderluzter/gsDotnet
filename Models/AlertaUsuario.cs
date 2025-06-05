using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ALERTA_USUARIO")]
public class AlertaUsuario
{
    [Key]
    [Column("ID_ALERTA")]
    public int IdAlerta { get; set; }

    [Column("DATA_ALERTA")]
    public DateTime? DataAlerta { get; set; }

    [Column("GRAVIDADE")]
    public string? Gravidade { get; set; }

    [Column("ID_LOCALIZACAO")]
    public int IdLocalizacao { get; set; }

    [Column("ID_USUARIO")]
    public int IdUsuario { get; set; }

    [Column("ID_EVENTO")]
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
