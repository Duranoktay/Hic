using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class WriteDbContextFactory : IDesignTimeDbContextFactory<WriteDbContext>
{
    public WriteDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WriteDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=ecommerce_write;Username=postgres;Password=admin;Port=5432");

        return new WriteDbContext(optionsBuilder.Options);
    }
}
