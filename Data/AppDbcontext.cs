using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<UsuarioGS> Usuarios { get; set; }
    public DbSet<Alerta> Alertas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioGS>()
        .HasKey(u => u.IdUsuario);

        modelBuilder.Entity<Alerta>()
            .HasKey(a => a.IdAlerta);

        modelBuilder.Entity<UsuarioGS>()
            .HasMany(u => u.Alertas)
            .WithOne(a => a.Usuario)
            .HasForeignKey(a => a.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
