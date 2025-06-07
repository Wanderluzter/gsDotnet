using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Conexão com banco Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Serviços da API
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// 3. Injeção de dependências – REPOSITORIES
builder.Services.AddScoped<UsuarioGSRepository>();
builder.Services.AddScoped<AlertaRepository>();

// 4. Injeção de dependências – SERVICES
builder.Services.AddScoped<UsuarioGSService>();
builder.Services.AddScoped<AlertaService>();

var app = builder.Build();

// 5. Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
