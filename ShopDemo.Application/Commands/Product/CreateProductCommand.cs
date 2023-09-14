using MediatR;

namespace ShopDemo.Application.Commands.Product;

public class CreateProductCommand : IRequest<object>
{
    // public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }
}