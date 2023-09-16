using MediatR;
using ShopDemo.Application.Queries.Product;
using ShopDemo.Application.Repository.IRepository;

namespace ShopDemo.Application.Handlers.Product;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
{
    private readonly IProductRepository _db;
    
    public GetProductByIdQueryHandler(IProductRepository db)
    {
        _db = db;
    }

    public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _db.GetAsync(u => u.Id == request.Id);
    }
}