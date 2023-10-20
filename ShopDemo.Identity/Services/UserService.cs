using Microsoft.AspNetCore.Identity;
using ShopDemo.Application.Contracts.Identity;
using ShopDemo.Application.Models.Identity;
using ShopDemo.Identity.Models;

namespace ShopDemo.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Employee> GetEmployee(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);
        return new Employee
        {
            Email = employee.Email,
            Id = employee.Id,
            Firstname = employee.FirstName,
            Lastname = employee.LastName
        };
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Employee");
        return employees.Select(q => new Employee
        {
            Id = q.Id,
            Email = q.Email,
            Firstname = q.FirstName,
            Lastname = q.LastName
        }).ToList();
    }
}