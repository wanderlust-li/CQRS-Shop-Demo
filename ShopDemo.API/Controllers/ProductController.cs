using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopDemo.Application.Commands.Product;

namespace ShopDemo.API.Controllers;


[Route("api/Product")]
[ApiController]

public class ProductController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IMediator mediator, ILogger<ProductController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        try
        {
            _logger.LogInformation("Attempting to create a new product: {ProductName}", command.Name);

            var result = await _mediator.Send(command);
                
            _logger.LogInformation("Product created successfully: {ProductName}", command.Name);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating product: {ProductName}", command.Name);
            return BadRequest(ex.Message);
        }
    }
}