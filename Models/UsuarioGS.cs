public class UsuarioGS
{
    public int IdUsuario { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string TelefoneEmergencia { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public ICollection<Alerta> Alertas { get; set; } = new List<Alerta>();
}

