using MediatR;
using ShopDemo.API.Models;

namespace ShopDemo.API.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
}