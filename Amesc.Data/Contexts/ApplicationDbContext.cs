using System.Threading.Tasks;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoComMatriculaAberta> CursosComMatriculasAbertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Contato>().ToTable("Contato");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<CursoComMatriculaAberta>().ToTable("CursoComMatriculaAberta");
            modelBuilder.Entity<PublicoAlvoParaCurso>().ToTable("PublicoAlvoParaCurso");
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
