using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopDemo.Application.Features.Product.Commands.CreateProduct;
using ShopDemo.Application.Features.Product.Queries.GetAllProduct;
using ShopDemo.Application.Features.Product.Queries.GetProduct;


namespace ShopDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpGet]
        public async Task<List<ProductAllDto>> Get()
        {
            var productAll = await _mediator.Send(new GetAllProductQuery());
            return productAll;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductQuery(id));
            return product;
        }
      
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateProductCommand product)
        {
            var response = await _mediator.Send(product);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
    }
}