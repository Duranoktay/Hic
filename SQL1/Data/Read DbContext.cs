using Microsoft.EntityFrameworkCore;

public class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
