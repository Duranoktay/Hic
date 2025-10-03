using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly ReadDbContext _readContext;

    public GetProductHandler(ReadDbContext readContext)
    {
        _readContext = readContext;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _readContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}
