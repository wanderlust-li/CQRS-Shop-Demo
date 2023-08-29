using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopDemo.API.Data;
using ShopDemo.API.Models;

namespace ShopDemo.API.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly ApplicationDbContext _context;

    public GetProductByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
}