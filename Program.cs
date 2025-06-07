using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add conexão com banco Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Add serviços de API (controllers, swagger, etc.)
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// 3. Add dependências (caso esteja usando services e repositories)
builder.Services.AddScoped<IAlertaUsuarioRepository, AlertaUsuarioRepository>();
builder.Services.AddScoped<IAlertaUsuarioService, AlertaUsuarioService>();

var app = builder.Build();

// 4. Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
