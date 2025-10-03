using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Command
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(new { Id = id });
    }

    // Query
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var result = await _mediator.Send(new GetProductQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }
}
