using ShopDemo.Application.Models.Identity;

namespace ShopDemo.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    
    Task<Employee> GetEmployee(string userId);
}