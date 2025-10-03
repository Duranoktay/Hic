using MediatR;
using Microsoft.EntityFrameworkCore;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly WriteDbContext _writeContext;

    public CreateProductHandler(WriteDbContext writeContext)
    {
        _writeContext = writeContext;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        _writeContext.Products.Add(product);
        await _writeContext.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
