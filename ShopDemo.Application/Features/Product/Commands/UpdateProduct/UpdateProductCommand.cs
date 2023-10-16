using MediatR;

namespace ShopDemo.Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Unit>
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }
}