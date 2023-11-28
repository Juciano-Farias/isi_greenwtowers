using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
{
    public MyContext CreateDbContext(string[] args)
    {
        // Usado para criar Migrations
        var connectionString = "Host=localhost;Port=5432;Database=pa;Username=postgres;Password=postgres";
        var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new MyContext(optionsBuilder.Options);
    }
}
