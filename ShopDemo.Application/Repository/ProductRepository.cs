using ShopDemo.Application.Repository.IRepository;
using ShopDemo.Domain.Entities;
using ShopDemo.Infrastructure.Data;

namespace ShopDemo.Application.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _db;
    
    public ProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        _db.Products.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }
}