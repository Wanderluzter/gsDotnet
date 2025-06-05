using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("alerta_usuario")]
public class AlertaUsuario
{
    [Key]
    [Column("id_alerta")]
    public int IdAlerta { get; set; }

    [Column("data_alerta")]
    public DateTime? DataAlerta { get; set; }

    [Column("gravidade")]
    public string? Gravidade { get; set; }

    [Column("id_localizacao")]
    public int IdLocalizacao { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("id_evento")]
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
