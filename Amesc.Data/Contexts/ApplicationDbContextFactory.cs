using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Amesc.Data.Contexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=tcp:lackr48t1l.database.windows.net,1433;Initial Catalog=amesc-staging;Persist Security Info=False;User ID=user_flashcard;Password=@#tTbanco_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
