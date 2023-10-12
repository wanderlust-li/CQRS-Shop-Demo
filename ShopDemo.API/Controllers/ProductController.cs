using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopDemo.Application.Features.Product.Queries.GetAllProduct;


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
        public async Task<List<ProductDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetAllProductQuery());
            return leaveTypes;
        }
      
    }
}