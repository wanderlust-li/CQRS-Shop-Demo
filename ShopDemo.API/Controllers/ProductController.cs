using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopDemo.API.Data;
using ShopDemo.API.Queries;

namespace ShopDemo.API.Controllers;


[Route("api/Product")]
[ApiController]
public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IMediator _mediator;

    public ProductController(ApplicationDbContext db, IMediator mediator)
    {
        _db = db;
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetProduct(int id)
    {
        if (id == 0)
        {
            return BadRequest(id);
        }
        
        var query = new GetProductByIdQuery { Id = id };
        var product = await _mediator.Send(query);

        if (product == null)
        {
            return NotFound($"Product with ID {id} was not found.");
        }

        return Ok(product);
    }
}