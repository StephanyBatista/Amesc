using System.Threading.Tasks;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Amesc.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Aluno>().OwnsOne(p => p.Endereco);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
