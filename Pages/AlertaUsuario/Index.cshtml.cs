using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly HttpClient _http;

    public IndexModel(IHttpClientFactory factory)
    {
        _http = factory.CreateClient();
    }

    public List<AlertaUsuario> Alertas { get; set; } = new();

    [BindProperty]
    public AlertaUsuario NovoAlerta { get; set; } = new();

    public async Task OnGetAsync()
    {
        var response = await _http.GetFromJsonAsync<List<AlertaUsuario>>("http://localhost:5218/api/AlertaUsuario");
        if (response != null)
            Alertas = response;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        NovoAlerta.DataAlerta = NovoAlerta.DataAlerta == default ? DateTime.Now : NovoAlerta.DataAlerta;
        await _http.PostAsJsonAsync("http://localhost:5218/api/AlertaUsuario", NovoAlerta);
        return RedirectToPage(); // Atualiza a lista
    }

    public async Task<IActionResult> OnPostDeleteAsync(int idAlerta)
    {
        await _http.DeleteAsync($"http://localhost:5218/api/AlertaUsuario/{idAlerta}");
        return RedirectToPage();
    }

}
