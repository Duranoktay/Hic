using Quartz;
using Microsoft.EntityFrameworkCore;

[DisallowConcurrentExecution]
public class DataSyncJob : IJob
{
    private readonly WriteDbContext _writeContext;
    private readonly ReadDbContext _readContext;

    public DataSyncJob(WriteDbContext writeContext, ReadDbContext readContext)
    {
        _writeContext = writeContext;
        _readContext = readContext;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var writeProducts = await _writeContext.Products.AsNoTracking().ToListAsync();

      
        _readContext.Products.RemoveRange(_readContext.Products);
        await _readContext.SaveChangesAsync();

        foreach (var product in writeProducts)
        {
            _readContext.Products.Add(new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                IsActive = product.IsActive
            });
        }

        await _readContext.SaveChangesAsync();
    }
}
