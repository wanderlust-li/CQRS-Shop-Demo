using ShopDemo.Domain.Entities;

namespace ShopDemo.Application.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    Task<Product> UpdateAsync(Product entity);
}