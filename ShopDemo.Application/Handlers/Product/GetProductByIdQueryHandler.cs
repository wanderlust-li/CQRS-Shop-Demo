using MediatR;
using Microsoft.Extensions.Logging;
using ShopDemo.Application.Queries.Product;
using ShopDemo.Application.Repository.IRepository;

namespace ShopDemo.Application.Handlers.Product;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
{
    private readonly IProductRepository _db;
    private readonly ILogger<GetProductByIdQueryHandler> _logger;

    public GetProductByIdQueryHandler(IProductRepository db, ILogger<GetProductByIdQueryHandler> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _db.GetAsync(u => u.Id == request.Id);
            if(product == null)
            {
                _logger.LogWarning("Product with ID {ProductId} not found", request.Id);
                throw new Exception($"Product with ID {request.Id} not found");
            }

            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching product by ID: {ProductId}", request.Id);
            throw;  
        }
    }
}