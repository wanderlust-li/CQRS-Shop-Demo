using MediatR;
using ShopDemo.Application.Commands.Product;
using ShopDemo.Application.Repository.IRepository;

namespace ShopDemo.Application.Handlers.Product;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, object>
{
    private readonly IProductRepository _db;

    public CreateProductCommandHandler(IProductRepository db)
    {
        _db = db;
    }

    public async Task<object> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity
        };

        try
        {
            await _db.CreateAsync(product);

            return product;
        }
        catch (Exception ex)
        {
            return new { error = ex.Message };
        }
    }
}