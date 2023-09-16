using MediatR;

namespace ShopDemo.Application.Queries.Product;

public class GetProductByIdQuery : IRequest<Domain.Entities.Product>
{
    public int Id { get; set; }
    
}