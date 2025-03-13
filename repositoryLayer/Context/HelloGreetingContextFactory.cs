using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace repositoryLayer.Context
{
    public class HelloGreetingContextFactory : IDesignTimeDbContextFactory<HelloGreetingContext>
    {
        public HelloGreetingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HelloGreetingContext>();

            // Hardcoded connection string
            var connectionString = "Server=localhost;Database=HelloGreetingDB;User Id=sa;Password=Sanskriti_3009;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);

            return new HelloGreetingContext(optionsBuilder.Options);
        }
    }
}
