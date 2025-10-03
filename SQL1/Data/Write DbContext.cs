using Microsoft.EntityFrameworkCore;

public class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
