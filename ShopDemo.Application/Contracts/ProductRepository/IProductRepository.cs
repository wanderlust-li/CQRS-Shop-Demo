using ShopDemo.Domain;

namespace ShopDemo.Application.Contracts.ProductRepository;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<bool> IsLeaveTypeUnique(string name);
}