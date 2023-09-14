using AutoMapper;
using MediatR;
using ShopDemo.Application.Commands.Product;
using ShopDemo.Application.Repository.IRepository;

namespace ShopDemo.Application.Handlers.Product;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, object>
{
    private readonly IProductRepository _db;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<object> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Entities.Product>(request);
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