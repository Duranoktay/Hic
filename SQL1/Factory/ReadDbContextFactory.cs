using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ReadDbContextFactory : IDesignTimeDbContextFactory<ReadDbContext>
{
    public ReadDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ReadDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=ecommerce_write;Username=postgres;Password=admin;Port=5432");


        return new ReadDbContext(optionsBuilder.Options);
    }
}
