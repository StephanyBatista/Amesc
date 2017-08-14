using System.Threading.Tasks;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Amesc.Data.Identity;

namespace Amesc.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoAberto> CursosAbertos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Endereco>().ToTable("Contato");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<CursoAberto>().ToTable("CursoAberto");
            modelBuilder.Entity<PublicoAlvoParaCurso>().ToTable("PublicoAlvoParaCurso");
            modelBuilder.Entity<Matricula>().ToTable("Matricula");
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
