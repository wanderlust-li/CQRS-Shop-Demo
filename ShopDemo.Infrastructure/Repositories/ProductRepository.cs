using ShopDemo.Application.Contracts.ProductRepository;
using ShopDemo.Domain;

namespace ShopDemo.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<IReadOnlyList<Product>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsLeaveTypeUnique(string name)
    {
        throw new NotImplementedException();
    }
}