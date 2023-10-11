using ShopDemo.Domain;

namespace ShopDemo.Application.Repository.ProductRepository;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<bool> IsLeaveTypeUnique(string name);
}