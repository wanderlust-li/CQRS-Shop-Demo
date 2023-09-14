using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopDemo.Application.Commands.Product;

namespace ShopDemo.API.Controllers;


[Route("api/Product")]
[ApiController]

public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}