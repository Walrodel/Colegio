using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Colegio.Infrastructure.Data
{
    public class ColegioContextFactory : IDesignTimeDbContextFactory<ColegioContext>
    {
        private const string ConnectionStringName = "Colegio";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public ColegioContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ColegioContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-5POPK1T\\SQLEXPRESS;Database=Colegio;Integrated Security = true");

            return new ColegioContext(optionsBuilder.Options);
        }
    }
}
