using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ShopDemo.Application.Commands.Product;
using ShopDemo.Application.Repository.IRepository;

namespace ShopDemo.Application.Handlers.Product;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, object>
{
    private readonly IProductRepository _db;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(IProductRepository db, IMapper mapper,
        ILogger<CreateProductCommandHandler> logger)
    {
        _db = db;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<object> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);
            await _db.CreateAsync(product);

            _logger.LogInformation("Product created successfully: {ProductName}", product.Name);
            
            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating product: {ProductName}", request.Name);
            return new { error = ex.Message };
        }
    }
}