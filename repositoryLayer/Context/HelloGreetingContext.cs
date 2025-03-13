using Microsoft.EntityFrameworkCore;
using repositoryLayer.Entity;

public class HelloGreetingContext : DbContext
{
    public HelloGreetingContext(DbContextOptions<HelloGreetingContext> options)
        : base(options)
    {
    }

    public DbSet<HelloGreetingEntity> Greetings { get; set; }
}
