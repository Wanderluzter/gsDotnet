using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UsuarioGSModel : PageModel
{
    private readonly UsuarioGSService _service;

    public UsuarioGSModel(UsuarioGSService service)
    {
        _service = service;
    }

    [BindProperty]
    public UsuarioGSCreateDTO Usuario { get; set; } = new();

    [TempData]
    public string? MensagemErro { get; set; }

    [TempData]
    public string? MensagemSucesso { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            MensagemErro = "Dados inválidos.";
            return Page();
        }

        try
        {
            _service.Create(Usuario);
            MensagemSucesso = "Usuário criado com sucesso!";
            return RedirectToPage(); // Redireciona e mantém mensagem
        }
        catch (Exception ex)
        {
            MensagemErro = $"Erro ao criar usuário: {ex.Message}";
            return Page(); // Exibe erro sem redirecionar
        }
    }
}
