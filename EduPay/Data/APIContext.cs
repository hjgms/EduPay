using EduPay.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Data;

public class APIContext : DbContext
{
    public APIContext(DbContextOptions<APIContext> options)
        : base(options) { }

    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Pagamento> Pagamentos => Set<Pagamento>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>()
            .HasDiscriminator<string>("CursoTipo")
            .HasValue<CursoPresencial>("Presencial")
            .HasValue<CursoOnline>("Online");

        base.OnModelCreating(modelBuilder);
    }
}