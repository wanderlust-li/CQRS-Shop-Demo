using Microsoft.EntityFrameworkCore;
using ShopDemo.Application.Contracts.ProductRepository;
using ShopDemo.Domain;
using ShopDemo.Infrastructure.DatabaseContext;

namespace ShopDemo.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ShopDatabaseContext context) : base(context)
    {
        
    }

    public async Task<bool> IsProductNameUnique(string name)
    {
        return await _context.Products.AnyAsync(u => u.Name == name) == false;
    }
}