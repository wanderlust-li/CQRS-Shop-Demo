namespace ShopDemo.Application.Features.Product.Queries.GetAllProduct;

public class ProductAllDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }
}