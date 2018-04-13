using System.Threading.Tasks;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Amesc.Data.Identity;
using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio.Pessoas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoAberto> CursosAbertos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<ComoFicouSabendo> ComoFicouSabendo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>().OwnsOne(p => p.Endereco);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
